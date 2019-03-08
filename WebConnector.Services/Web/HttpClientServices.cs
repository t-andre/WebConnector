// <copyright file="HttpClientServices.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>07.03.2019</date>
// <summary>Implements the HTTP client services class</summary>
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TSoft.Library.Core.Logging;
using WebConnector.Services.Serialization;

namespace WebConnector.Services.Web
{
    /// <summary> A HTTP client base. </summary>
    /// <seealso cref="T:WebConnector.Services.BaseServices"/>
    /// <seealso cref="T:WebConnector.Services.Web.IHttpClientServices"/>
    public class HttpClientServices : BaseServices, IHttpClientServices
    {
        #region [Constructors]

        /// <summary> Initializes a new instance of the WebConnector.Services.Web.HttpClientServices class. </summary>
        /// <param name="logger">     The logger. </param>
        /// <param name="serializer"> The serializer. </param>
        public HttpClientServices(ILogger logger, ISerializerServices serializer) : base(logger)
        {
            this.Logger = logger.SubscribEventLog(nameof(HttpClientServices));
            this.Logger.Information($"Initializing {nameof(HttpClientServices)}");
            this.Serializer = serializer;
        }
        #endregion

        #region [Public properties]

        /// <summary> Gets or sets a value indicating whether the client initialized. </summary>
        /// <value> True if client initialized, false if not. </value>
        /// <seealso cref="P:WebConnector.Services.Web.IHttpClientServices.ClientInitialized"/>
        public bool ClientInitialized { get; set; }

        /// <summary> Gets the network credential. </summary>
        /// <value> The network credential. </value>
        /// <seealso cref="P:WebConnector.Services.Web.IHttpClientServices.NetworkCredential"/>
        public NetworkCredential NetworkCredential { get; private set; }

        /// <summary> Gets or sets the password or token. </summary>
        /// <value> The password or token. </value>
        /// <seealso cref="P:WebConnector.Services.Web.IHttpClientServices.PasswordOrToken"/>
        public string PasswordOrToken { get; set; }

        /// <summary> Gets or sets a value indicating whether the requires authentication. </summary>
        /// <value> True if requires authentication, false if not. </value>
        /// <seealso cref="P:WebConnector.Services.Web.IHttpClientServices.RequiresAuthentication"/>
        public bool RequiresAuthentication { get; set; }

        /// <summary> Gets the serializer. </summary>
        /// <value> The serializer. </value>
        /// <seealso cref="P:WebConnector.Services.Web.IHttpClientServices.Serializer"/>
        public ISerializerServices Serializer { get; }

        /// <summary> Gets or sets URL of the document. </summary>
        /// <value> The URL. </value>
        /// <seealso cref="P:WebConnector.Services.Web.IHttpClientServices.Url"/>
        public string Url { get; set; }

        /// <summary> Gets or sets the name of the user. </summary>
        /// <value> The name of the user. </value>
        /// <seealso cref="P:WebConnector.Services.Web.IHttpClientServices.UserName"/>
        public string UserName { get; set; }
        #endregion

        #region [Public methods]

        /// <summary> Initializes this HttpClientServices. </summary>
        /// <seealso cref="M:WebConnector.Services.Web.IHttpClientServices.Initialize()"/>
        public void Initialize()
        {
            if (!this.ClientInitialized)
            {
                if (this.RequiresAuthentication)
                {
                    this.NetworkCredential = new NetworkCredential(this.UserName, this.PasswordOrToken);
                }
            }
        }

        /// <summary> Initializes this HttpClientServices. </summary>
        /// <param name="url">             The URL. </param>
        /// <param name="userName">        The name of the user. </param>
        /// <param name="passwordOrToken"> The password or token. </param>
        /// <seealso cref="M:WebConnector.Services.Web.IHttpClientServices.Initialize(string,string,string)"/>
        public void Initialize(string url, string userName, string passwordOrToken)
        {
            this.Url = url;
            this.UserName = userName;
            this.PasswordOrToken = passwordOrToken;
            this.RequiresAuthentication = (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(passwordOrToken)) || !string.IsNullOrEmpty(passwordOrToken);

            if (!this.ClientInitialized)
            {
                if (this.RequiresAuthentication)
                {
                    this.NetworkCredential = new NetworkCredential(this.UserName, this.PasswordOrToken);
                }
            }
        }

        /// <summary> Resets this HttpClientServices. </summary>
        /// <seealso cref="M:WebConnector.Services.Web.IHttpClientServices.Reset()"/>
        public void Reset()
        {
            this.NetworkCredential = null;
            this.ClientInitialized = false;
            this.RequiresAuthentication = false;
        }

        /// <summary> Gets the asynchronous. </summary>
        /// <returns> The asynchronous. </returns>
        /// <seealso cref="M:WebConnector.Services.Web.IHttpClientServices.GetAsync()"/>
        public string GetAsync()
        {
            return string.Empty;
        }

        /// <summary> Posts data asynchronous. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data">           The data. </param>
        /// <param name="serializerType"> Type of the serializer. </param>
        /// <returns> A string. </returns>
        /// <seealso cref="M:WebConnector.Services.Web.IHttpClientServices.PostAsync{T}(T,SerializerType)"/>
        /// <seealso cref="M:WebConnector.Services.Web.IHttpClientServices.PostJsonAsync{T}(T)"/>
        public string PostAsync<T>(T data, SerializerType serializerType)
        {
            try
            {
                using (WebClient httpClient = new WebClient())
                {
                    if (this.RequiresAuthentication)
                    {
                        httpClient.UseDefaultCredentials = true;
                        httpClient.Credentials = this.NetworkCredential;
                    }

                    var json = this.Serializer.Serialize<T>(data, serializerType);
                    var postData = httpClient.UploadString(this.Url, "POST", json);
                    return postData;
                }
            }
            catch (Exception ex)
            {
                this.Logger.Fatal("Cannot Post Data : {0}", ex);
                return string.Empty;
            }
        }
        #endregion
    }
}
