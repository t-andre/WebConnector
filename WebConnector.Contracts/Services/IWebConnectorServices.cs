// <copyright file="IWebConnectorServices.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>08.03.2019</date>
// <summary>Declares the IWebConnectorServices interface</summary>
using System;
using TSoft.Library.Core.Logging;

namespace WebConnector.Contracts.Services
{
    /// <summary> Interface for web connector services. </summary>
    public interface IWebConnectorServices
    {
        #region [Properties Implementation]
        /// <summary> Gets or sets the logger. </summary>
        /// <value> The logger. </value>
        ILogger Logger { get; set; }

        /// <summary> Gets the serializer services. </summary>
        /// <value> The serializer services. </value>
        ISerializerServices Serializer { get; }
        #endregion
    }
}
