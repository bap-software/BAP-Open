// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ITalkingEntity.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Common
{
    /// <summary>
    /// Interface which which identifies whether entity can say something about it state during run time
    /// </summary>
    public interface ITalkingEntity
    {
        /// <summary>
        /// Gets a value indicating whether this instance has message.
        /// </summary>
        /// <value><c>true</c> if this instance has message; otherwise, <c>false</c>.</value>
        bool HasMessage { get; }
        /// <summary>
        /// Gets the message added at.
        /// </summary>
        /// <value>The message added at.</value>
        DateTime MessageAddedAt { get; }
        /// <summary>
        /// Gets the notification message.
        /// </summary>
        /// <value>The notification message.</value>
        string NotificationMessage { get; }
        /// <summary>
        /// Adds the message.
        /// </summary>
        /// <param name="message">The message.</param>
        void AddMessage(string message);
    }
}
