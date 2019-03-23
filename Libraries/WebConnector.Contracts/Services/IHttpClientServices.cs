// <copyright file="IHttpClientServices.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>08.03.2019</date>
// <summary>Declares the IHttpClientServices interface</summary>
using System;
using System.Net;
using System.Threading.Tasks;
using WebConnector.Contracts.Enums;

namespace WebConnector.Contracts.Services
{
    /// <summary> Interface for HTTP client services. </summary>
    public interface IHttpClientServices
    {
        #region [Properties Implementation]

        /// <summary> Gets or sets a value indicating whether the client initialized. </summary>
        /// <value> True if client initialized, false if not. </value>
        bool ClientInitialized { get; set; }

        /// <summary> Gets the network credential. </summary>
        /// <value> The network credential. </value>
        NetworkCredential NetworkCredential { get; }

        /// <summary> Gets or sets the password or token. </summary>
        /// <value> The password or token. </value>
        string PasswordOrToken { get; set; }

        /// <summary> Gets or sets a value indicating whether the requires authentication. </summary>
        /// <value> True if requires authentication, false if not. </value>
        bool RequiresAuthentication { get; set; }

        /// <summary> Gets the serializer. </summary>
        /// <value> The serializer. </value>
        ISerializerServices Serializer { get; }

        /// <summary> Gets or sets URL of the document. </summary>
        /// <value> The URL. </value>
        string Url { get; set; }

        /// <summary> Gets or sets the name of the user. </summary>
        /// <value> The name of the user. </value>
        string UserName { get; set; }
        #endregion

        #region [Methods Implementation]
        /// <summary> Initializes this HttpClientServices. </summary>
        void Initialize();

        /// <summary> Initializes this HttpClientServices. </summary>
        /// <param name="url">             The URL. </param>
        /// <param name="userName">        The name of the user. </param>
        /// <param name="passwordOrToken"> The password or token. </param>
        void Initialize(string url, string userName, string passwordOrToken);

        /// <summary> Resets this IHttpClientServices. </summary>
        void Reset();

        /// <summary> Gets stream asynchronous. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data">           The data. </param>
        /// <param name="serializerType"> Type of the serializer. </param>
        /// <returns> An asynchronous result that yields the async&lt; t&gt; </returns>
        Task<string> GetAsync<T>(T data, SerializerType serializerType);

        /// <summary> Posts stream asynchronous. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data">           The data. </param>
        /// <param name="serializerType"> Type of the serializer. </param>
        /// <returns> A string. </returns>
        Task<string> PostAsync<T>(T data, SerializerType serializerType);

        #endregion
    }
}
