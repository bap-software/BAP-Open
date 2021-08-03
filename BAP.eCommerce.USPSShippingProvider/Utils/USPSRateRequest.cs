// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="USPSRateRequest.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Net;
using System.Text;
using BAP.eCommerce.USPSShippingProvider.Request;

namespace BAP.eCommerce.USPSShippingProvider.Utils
{
    /// <summary>
    /// Class USPSRateRequest.
    /// </summary>
    public class USPSRateRequest
    {
        /// <summary>
        /// The rate service URL
        /// </summary>
        public const string RateServiceUrl = "https://www.ups.com/ups.app/xml/Rate";

        /// <summary>
        /// Gets the specified acc request.
        /// </summary>
        /// <param name="accRequest">The acc request.</param>
        /// <param name="rssRequest">The RSS request.</param>
        /// <returns>System.String.</returns>
        public string Get(AccessRequest accRequest, RatingServiceSelectionRequest rssRequest)
        {
            var requestString = SerializationHelper.SerializeObj(accRequest).InnerXml +
                                SerializationHelper.SerializeObj(rssRequest).InnerXml;
            return CreateRateRequest(RateServiceUrl, requestString);
        }

        /// <summary>
        /// Creates the rate request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="requestText">The request text.</param>
        /// <returns>System.String.</returns>
        private static string CreateRateRequest(string url, string requestText)
        {
            string result;

            var encodedData = new ASCIIEncoding();
            byte[] byteArray = encodedData.GetBytes(requestText);

            // open up
            var wr = (HttpWebRequest)WebRequest.Create(url);
            wr.Method = "POST";
            wr.KeepAlive = false;
            wr.UserAgent = "Benz";
            wr.ContentType = "application/x-www-form-urlencoded";
            wr.ContentLength = byteArray.Length;
            try
            {
                // send xml data
                Stream sendStream = wr.GetRequestStream();
                sendStream.Write(byteArray, 0, byteArray.Length);
                sendStream.Close();

                // get da response
                var webResp = (HttpWebResponse)wr.GetResponse();
                using (var sr = new StreamReader(webResp.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                }

                webResp.Close();
            }
            catch (Exception ex)
            {
                // Unhandled exception occur
                result = ex.Message;
            }

            return result;
        }
    }
}
