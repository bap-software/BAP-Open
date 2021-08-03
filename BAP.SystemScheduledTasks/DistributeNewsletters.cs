// ***********************************************************************
// Assembly         : BAP.SystemScheduledTasks
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="DistributeNewsletters.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using BAP.BL;
using BAP.DAL;
using BAP.Log;
using BAP.Common;
using BAP.BL.Tasks;
using BAP.DAL.Entities;
using BAP.Email;

namespace BAP.SystemScheduledTasks
{
    /// <summary>
    /// Class DistributeNewsletters.
    /// Implements the <see cref="BAP.Common.BAPBaseClassWithLogging" />
    /// Implements the <see cref="BAP.BL.Tasks.IBAPScheduledTask" />
    /// </summary>
    /// <seealso cref="BAP.Common.BAPBaseClassWithLogging" />
    /// <seealso cref="BAP.BL.Tasks.IBAPScheduledTask" />
    public class DistributeNewsletters : BAPBaseClassWithLogging, IBAPScheduledTask
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        private readonly IConfigHelper _configHelper;
        /// <summary>
        /// The authentication helper
        /// </summary>
        private readonly IAuthorizationContext _authHelper;
        /// <summary>
        /// The scheduled task bl
        /// </summary>
        private readonly IScheduledTaskBL _scheduledTaskBL;
        /// <summary>
        /// The news letter bl
        /// </summary>
        private readonly INewsLetterBL _newsLetterBL;
        /// <summary>
        /// The subscriber bl
        /// </summary>
        private readonly ISubscriberBL _subscriberBL;
        /// <summary>
        /// The mailer
        /// </summary>
        private readonly IMailer _mailer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributeNewsletters"/> class.
        /// </summary>
        public DistributeNewsletters() : base(DependencyResolver.Current.GetService<ILogger>())
        {
            _configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            _authHelper = DependencyResolver.Current.GetService<IAuthorizationContext>();
            _scheduledTaskBL = new BusinessLayer(_configHelper, _authHelper, _logger);
            _newsLetterBL = (INewsLetterBL)_scheduledTaskBL;
            _subscriberBL = (ISubscriberBL)_scheduledTaskBL;
            _mailer = DependencyResolver.Current.GetService<IMailer>();
        }

        /// <summary>
        /// Gets the custom data json example.
        /// </summary>
        /// <value>The custom data json example.</value>
        public string CustomDataJsonExample => "";

        /// <summary>
        /// Runs the task.
        /// </summary>
        /// <param name="taskInfo">The task information.</param>
        /// <returns>ScheduledTaskResult.</returns>
        public ScheduledTaskResult RunTask(ScheduledTask taskInfo)
        {
            var result = new ScheduledTaskResult
            {
                Success = true,
                Message = ""
            };
            try
            {
                var newsLetters = _newsLetterBL.GetRecentNewsLetters();
                var subscribers = _subscriberBL.GetActiveSubscribers();
                if(newsLetters != null && newsLetters.Count > 0 && subscribers != null && subscribers.Count > 0)
                {
                    var lettersToUpdate = new List<NewsLetter>();
                    for (int i = 0; i < newsLetters.Count; i++)
                    {
                        var newsLetter = newsLetters[i];
                        //Simple logic as of now - assuming that Letter Id will increase and newer one will have greater value of Id
                        var subscribersToSend = subscribers.Where(a => !a.LastNewsletterIdReceived.HasValue || a.LastNewsletterIdReceived.Value < newsLetter.Id);
                        foreach (var subscriber in subscribersToSend)
                        {
                            _mailer.SendEmail(_mailer.DefaultFromAddress, subscriber.Email, newsLetter.Subtitle, newsLetter.TextHtml, true);
                            subscriber.LastNewsletterIdReceived = newsLetter.Id;
                        }
                        _subscriberBL.UpdateSubscriber(subscribersToSend.ToArray());
                        subscribers = _subscriberBL.GetActiveSubscribers();

                        if (i < newsLetters.Count - 1)
                        {
                            newsLetter.Published = true;
                            lettersToUpdate.Add(newsLetter);
                        }
                    }
                    if(lettersToUpdate.Count > 0)
                    {
                        _newsLetterBL.UpdateNewsLetter(lettersToUpdate.ToArray());
                    }

                    result.Message = $"Successfully sent {newsLetters.Count} letters to {subscribers.Count} subscribers.";
                }                
            }
            catch(Exception exc)
            {
                LogException(exc);
                result.Success = false;
                result.Message = $"Failed to execute task with message: '" + exc.Message + "'. See more details in log.";
            }

            return result;
        }
    }
}
