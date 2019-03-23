// <copyright file="Response.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>09.03.2019</date>
// <summary>Implements the base response class</summary>
using System;

namespace WebConnector.Kanboard.Entities
{
    /// <summary> A response. </summary>
    public abstract class Response
    {
        #region [Public properties]

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int id { get; set; }

        /// <summary> Gets or sets the jsonrpc. </summary>
        /// <value> The jsonrpc. </value>
        public string jsonrpc { get; set; } = "2.0";

        /// <summary> Gets or sets the result. </summary>
        /// <value> The result. </value>
        public dynamic result { get; set; }
        #endregion
    }
}
