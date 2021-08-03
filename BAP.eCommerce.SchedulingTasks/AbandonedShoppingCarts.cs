// ***********************************************************************
// Assembly         : BAP.eCommerce.SchedulingTasks
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="AbandonedShoppingCarts.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Newtonsoft.Json;

using BAP.BL.Tasks;
using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.eCommerce.BL;
using BAP.eCommerce.DAL.Entities;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;

namespace BAP.eCommerce.SchedulingTasks
{
    /// <summary>
    /// Class AbandonedShoppingCarts.
    /// Implements the <see cref="BAP.Common.BAPBaseClassWithLogging" />
    /// Implements the <see cref="BAP.BL.Tasks.IBAPScheduledTask" />
    /// </summary>
    /// <seealso cref="BAP.Common.BAPBaseClassWithLogging" />
    /// <seealso cref="BAP.BL.Tasks.IBAPScheduledTask" />
    public class AbandonedShoppingCarts : BAPBaseClassWithLogging, IBAPScheduledTask
    {
        /// <summary>
        /// The cart saving period days
        /// </summary>
        private const int _cartSavingPeriodDays = 30;
        /// <summary>
        /// The lookup engine
        /// </summary>
        private readonly ILookupEngine _lookupEngine;
        /// <summary>
        /// The file proc
        /// </summary>
        private readonly IFileProcessor _fileProc;
        /// <summary>
        /// The configuration helper
        /// </summary>
        private readonly IConfigHelper _configHelper;
        /// <summary>
        /// The context
        /// </summary>
        private readonly IAuthorizationContext _context;
        /// <summary>
        /// The shopping cart bl
        /// </summary>
        private readonly IShoppingCartBL _shoppingCartBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbandonedShoppingCarts"/> class.
        /// </summary>
        public AbandonedShoppingCarts() : base(DependencyResolver.Current.GetService<ILogger>())
        {
            _lookupEngine = DependencyResolver.Current.GetService<ILookupEngine>();
            _fileProc = DependencyResolver.Current.GetService<IFileProcessor>();
            _configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            _context = DependencyResolver.Current.GetService<IAuthorizationContext>();
            _shoppingCartBL = new eCommerceBusinessLayer(_lookupEngine, _fileProc, _configHelper, _context, _logger);
        }

        /// <summary>
        /// Gets the custom data json example.
        /// </summary>
        /// <value>The custom data json example.</value>
        public string CustomDataJsonExample
        {
            get
            {
                var obj = new AbandonedShoppingCartsData() { DaysToKeepShoppingCarts = _cartSavingPeriodDays };
                return JsonConvert.SerializeObject(obj);
            }
        }

        /// <summary>
        /// Runs the task.
        /// </summary>
        /// <param name="taskInfo">The task information.</param>
        /// <returns>ScheduledTaskResult.</returns>
        public ScheduledTaskResult RunTask(ScheduledTask taskInfo)
        {
            ScheduledTaskResult result = new ScheduledTaskResult
            {
                Success = true,
                Message = ""
            };

            try
            {
                var data = JsonConvert.DeserializeObject<AbandonedShoppingCartsData>(taskInfo.JobData);
                int days = data.DaysToKeepShoppingCarts > 0 ? data.DaysToKeepShoppingCarts : _cartSavingPeriodDays;
                var carts = _shoppingCartBL.GetShoppingCartsOlderThan(days);                
                if (carts != null && carts.Any())
                {
                    _shoppingCartBL.RemoveShoppingCart(carts.ToArray());
                    result.Message = $"Task finished with success, {carts.Count} shopping carts found to delete";
                }
                else
                {
                    result.Message = "Task finished with success, but no shopping carts found to delete";
                }
                    
            }
            catch(Exception exc)
            {
                LogException(exc);
                result.Success = false;
                result.Message = "Exception occured during running task: " + exc.Message;
            }
            return result;
        }
    }
}