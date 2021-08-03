// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="DataWizardResponseModel.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.eCommerce.DataWizards.Models.Interfaces;

namespace BAP.eCommerce.DataWizards.Models
{
    /// <summary>
    /// Class DataWizardResponseModel.
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Models.Interfaces.IDataWizardResponseModel" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Models.Interfaces.IDataWizardResponseModel" />
    public class DataWizardResponseModel : IDataWizardResponseModel
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="DataWizardResponseModel"/> class from being created.
        /// </summary>
        private DataWizardResponseModel()
        {

        }
        /// <summary>
        /// The instance
        /// </summary>
        private static DataWizardResponseModel _instance;
        /// <summary>
        /// The synqlock
        /// </summary>
        private static object _synqlock = new object();
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>DataWizardResponseModel.</returns>
        public static DataWizardResponseModel GetInstance()
        {
            
            if(_instance==null)
            {
                lock(_synqlock)
                {
                    if(_instance==null)
                    {
                        _instance = new DataWizardResponseModel();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value><c>true</c> if this instance is success; otherwise, <c>false</c>.</value>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>The event identifier.</value>
        public int EventId { get; set; }
    }
}
