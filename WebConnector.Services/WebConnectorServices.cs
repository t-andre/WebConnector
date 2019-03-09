// <copyright file="WebConnectorServices.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>08.03.2019</date>
// <summary>Implements the web connector services class</summary>
using System;
using System.Collections.Generic;
using System.Text;
using TSoft.Library.Core.Logging;
using TSoft.Library.Logging;
using WebConnector.Contracts.Services;
using WebConnector.Services.Serialization;
using WebConnector.Services.Web;

namespace WebConnector.Services
{
    /// <summary> A web connector services. </summary>
    /// <seealso cref="T:WebConnector.Services.IWebConnectorServices"/>
    public class WebConnectorServices : IWebConnectorServices
    {
        #region [Constructors]
        /// <summary> Initializes a new instance of the WebConnector.Services.WebConnectorServices class. </summary>
        public WebConnectorServices()
        {
            this.InitializeLogger();
            this.Initialize();
        }

        /// <summary> Initializes a new instance of the WebConnector.Services.WebConnectorServices class. </summary>
        /// <param name="logger"> The logger. </param>
        public WebConnectorServices(ILogger logger)
        {
            this.Logger = logger;
            this.Initialize();
            this.Serializer = new SerializerServices(this.Logger);
            this.HttpClient = new HttpClientServices(this.Logger, this.Serializer);
        }

        /// <summary> Initializes a new instance of the WebConnector.Services.WebConnectorServices class. </summary>
        /// <param name="logger">     The logger. </param>
        /// <param name="serializer"> The serializer services. </param>
        /// <param name="httpClient"> The HTTP client. </param>
        public WebConnectorServices(ILogger logger, ISerializerServices serializer, IHttpClientServices httpClient)
        {
            this.Logger = logger;
            this.Initialize();
            this.Serializer = serializer;
            this.HttpClient = httpClient;
        }
        #endregion

        #region [Public properties]
        /// <summary> Gets or sets the logger. </summary>
        /// <value> The logger. </value>
        /// <seealso cref="P:WebConnector.Services.IWebConnectorServices.Logger"/>
        public ILogger Logger { get; set; }

        /// <summary> Gets the serializer services. </summary>
        /// <value> The serializer services. </value>
        /// <seealso cref="P:WebConnector.Services.IWebConnectorServices.Serializer"/>
        public ISerializerServices Serializer { get; }

        /// <summary> Gets the HTTP client. </summary>
        /// <value> The HTTP client. </value>
        public IHttpClientServices HttpClient { get; }

        #endregion

        #region [Private methods]
        /// <summary> Initializes the logger. </summary>
        private void InitializeLogger()
        {
            this.Logger = new SerilogLogger();
        }

        /// <summary> Initializes this WebConnectorServices. </summary>
        private void Initialize()
        {
            this.Logger = this.Logger.SubscribEventLog(nameof(WebConnectorServices));
            this.Logger.Information($"Initializing {nameof(WebConnectorServices)}");
        }
        #endregion
    }
}
