// <copyright file="KanboardConnector.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>09.03.2019</date>
// <summary>Implements the kanboard connector class</summary>
using System;
using TSoft.Library.Core.Logging;
using WebConnector.Contracts;
using WebConnector.Contracts.Services;

namespace WebConnector.Kanboard
{
    /// <summary> A kanboard connector. </summary>
    /// <seealso cref="T:WebConnector.Contracts.BaseServices"/>
    public class KanboardConnector : BaseServices
    {
        #region [Constructors]
        /// <summary> Initializes a new instance of the WebConnector.Kanboard.KanboardConnector class. </summary>
        /// <param name="logger">             The logger. </param>
        /// <param name="httpClientServices"> The HTTP client services. </param>
        public KanboardConnector(ILogger logger, IHttpClientServices httpClient) : base(logger)
        {
            this.HttpClient = httpClient;
        }
        #endregion

        #region [Protected properties]
        protected IHttpClientServices HttpClient { get; }
        #endregion
    }
}
