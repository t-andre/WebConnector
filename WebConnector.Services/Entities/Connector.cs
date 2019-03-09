// <copyright file="Connector.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>09.03.2019</date>
// <summary>Implements the connector class</summary>
using System;
using System.Collections.Generic;
using System.Text;

namespace WebConnector.Services.Entities
{
    /// <summary> A connector. </summary>
    public class Connector
    {
        #region [Public properties]

        /// <summary> Gets or sets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary> Gets or sets a unique identifier. </summary>
        /// <value> The identifier of the unique. </value>
        public string UniqueIdentifier { get; set; }

        /// <summary> Gets or sets the description. </summary>
        /// <value> The description. </value>
        public string Description { get; set; }

        /// <summary> Gets or sets a value indicating whether the active. </summary>
        /// <value> True if active, false if not. </value>
        public bool Active { get; set; }
        #endregion
    }
}
