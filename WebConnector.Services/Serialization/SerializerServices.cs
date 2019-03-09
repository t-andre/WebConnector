// <copyright file="SerializerServices.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>07.03.2019</date>
// <summary>Implements the serializer services class</summary>
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TSoft.Library.Core.Logging;
using WebConnector.Contracts;
using WebConnector.Contracts.Enums;
using WebConnector.Contracts.Services;

namespace WebConnector.Services.Serialization
{
    /// <summary> A serializer services. </summary>
    /// <seealso cref="T:WebConnector.Services.BaseServices"/>
    /// <seealso cref="T:WebConnector.Services.Serialization.ISerializerServices"/>
    public class SerializerServices : BaseServices, ISerializerServices
    {
        #region [Constructors]

        /// <summary> Initializes a new instance of the WebConnector.Services.SerializerServices class. </summary>
        /// <param name="logger"> The logger. </param>
        public SerializerServices(ILogger logger) : base(logger)
        {
            this.Logger = logger.SubscribEventLog(nameof(SerializerServices));
            this.Logger.Information($"Initializing {nameof(SerializerServices)}");
        }
        #endregion

        #region [Fields]
        /// <summary> The serializer cache. </summary>
        private readonly ConcurrentDictionary<string, XmlSerializer> serializerCache = new ConcurrentDictionary<string, XmlSerializer>();
        #endregion

        #region [Public methods]

        /// <summary> Serialize this ISerializerServices to the given stream. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data">           The data. </param>
        /// <param name="serializerType"> Type of the serializer. </param>
        /// <returns> A string. </returns>
        /// <seealso cref="M:WebConnector.Services.Serialization.ISerializerServices.Serialize{T}(T,SerializerType)"/>
        public string Serialize<T>(T data, SerializerType serializerType)
        {
            switch (serializerType)
            {
                case SerializerType.Xml:
                    return this.XmlSerialize<T>(data);
                case SerializerType.Json:
                    return this.JsonSerialize<T>(data);
                default:
                    return string.Empty;
            }
        }

        /// <summary> Deserialize this ISerializerServices to the given stream. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data">           The data. </param>
        /// <param name="serializerType"> Type of the serializer. </param>
        /// <returns> A T. </returns>
        /// <seealso cref="M:WebConnector.Services.Serialization.ISerializerServices.Deserialize{T}(string,SerializerType)"/>
        public T Deserialize<T>(string data, SerializerType serializerType)
        {
            switch (serializerType)
            {
                case SerializerType.Xml:
                    return this.XmlDeserialize<T>(data);
                case SerializerType.Json:
                    return this.JsonDeserialize<T>(data);
                default:
                    return default(T);
            }
        }

        /// <summary> JSON deserialize. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data"> The data. </param>
        /// <returns> A T. </returns>
        /// <seealso cref="M:WebConnector.Services.Serialization.ISerializerServices.JsonDeserialize{T}(string)"/>
        public T JsonDeserialize<T>(string data)
        {
            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    return JsonConvert.DeserializeObject<T>(data);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                this.Logger.Fatal("Cannot deserialize Json Data : {0}", ex, data);
                return default(T);
            }
        }

        /// <summary> JSON serialize. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data"> The data. </param>
        /// <returns> A string. </returns>
        /// <seealso cref="M:WebConnector.Services.Serialization.ISerializerServices.JsonSerialize{T}(T)"/>
        public string JsonSerialize<T>(T data)
        {
            try
            {
                return JsonConvert.SerializeObject(data);

            }
            catch (Exception ex)
            {
                this.Logger.Fatal("Cannot serialize Json Data :", ex);
                return string.Empty;
            }
        }

        /// <summary> XML deserialize. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="xml"> The XML. </param>
        /// <returns> A T. </returns>
        /// <seealso cref="M:WebConnector.Services.Serialization.ISerializerServices.XmlDeserialize{T}(string)"/>
        public T XmlDeserialize<T>(string xml)
        {
            try
            {
                if (!string.IsNullOrEmpty(xml))
                {
                    using (var stringReader = new StringReader(xml))
                    {
                        using (var reader = new XmlTextReader(stringReader))
                        {
                            reader.Namespaces = false;
                            //var serializer = this.GetSerializer(typeof(valueType));
                            XmlSerializer serializer = new XmlSerializer(typeof(T));
                            object serializerDeserialize = serializer.Deserialize(reader);
                            return (T)serializerDeserialize;
                        }
                    }
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                this.Logger.Fatal("Cannot deserialize Data : {0}", ex, xml);
                return default(T);
            }
        }

        /// <summary> XML serialize. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data"> The data. </param>
        /// <returns> A string. </returns>
        /// <seealso cref="M:WebConnector.Services.Serialization.ISerializerServices.XmlSerialize{T}(T)"/>
        public string XmlSerialize<T>(T data)
        {
            try
            {
                using (var writer = new StringWriter())
                {
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    var serializer = this.GetXmlSerializer(typeof(T));
                    serializer.Serialize(writer, data);

                    return writer.ToString();
                }
            }
            catch (Exception ex)
            {
                this.Logger.Fatal("Cannot serialize Xml Data :", ex);
                return string.Empty;
            }
        }
        #endregion

        #region [Private methods]

        /// <summary> Gets XML serializer. </summary>
        /// <param name="type"> The type. </param>
        /// <returns> The XML serializer. </returns>
        private XmlSerializer GetXmlSerializer(Type type)
        {
            var key = type.FullName;
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            return this.serializerCache.GetOrAdd(key, k => xmlSerializer);
        }
        #endregion

        #region [Nested Class]

        /// <summary> A namespace ignorant XML text reader. </summary>
        /// <seealso cref="T:System.Xml.XmlTextReader"/>
        public class NamespaceIgnorantXmlTextReader : XmlTextReader
        {
            #region [Constructors]

            /// <summary> Initializes a new instance of the WebConnector.Services.SerializerServices.NamespaceIgnorantXmlTextReader class. </summary>
            /// <param name="reader"> The reader. </param>
            public NamespaceIgnorantXmlTextReader(System.IO.TextReader reader) : base(reader) { }
            #endregion

            #region [Public properties]

            /// <summary> Gets the namespace URI (as defined in the W3C Namespace specification) of the node on which the reader is positioned. </summary>
            /// <value> The namespace URI of the current node; otherwise an empty string. </value>
            /// <seealso cref="P:System.Xml.XmlTextReader.NamespaceURI"/>
            public override string NamespaceURI
            {
                get { return ""; }
            }
            #endregion
        }
        #endregion
    }
}
