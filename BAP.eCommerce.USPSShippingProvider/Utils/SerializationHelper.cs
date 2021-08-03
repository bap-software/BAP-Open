// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="SerializationHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Xml;

namespace BAP.eCommerce.USPSShippingProvider.Utils
{
    /// <summary>
    /// Class SerializationHelper.
    /// </summary>
    class SerializationHelper
    {
        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>XmlDocument.</returns>
        public static XmlDocument SerializeObj(Object obj)
        {
            var xmlDoc = new XmlDocument();
            try
            {
                using (var myStream = new MemoryStream())
                {
                    var xmlSer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                    xmlSer.Serialize(myStream, obj);
                    myStream.Position = 0;
                    xmlDoc.Load(myStream);
                }
            }
            catch (Exception)
            {
                // ignored - empty document is returned in this case
            }

            return xmlDoc;
        }

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="type">The type.</param>
        /// <returns>Object.</returns>
        public static Object DeserializeObj(string xml, Type type)
        {
            try
            {
                using (var reader = new StringReader(xml))
                {
                    var xmlSer = new System.Xml.Serialization.XmlSerializer(type);
                    return xmlSer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                // ignored - just return null
            }

            return null;
        }
    }
}
