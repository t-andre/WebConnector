// <copyright file="BaseServices.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>07.03.2019</date>
// <summary>Implements the base services class</summary>
using System;
using System.Collections.Generic;
using System.Text;
using TSoft.Library.Core.Logging;

namespace WebConnector.Services
{
    /// <summary> A base services. </summary>
    public class BaseServices
    {
        #region [Constructors]

        /// <summary> Initializes a new instance of the WebConnector.Services.BaseServices class. </summary>
        /// <param name="logger"> The logger. </param>
        public BaseServices(ILogger logger)
        {
            this.Logger = logger;
        }
        #endregion

        #region [Protected properties]

        /// <summary> Gets or sets the logger. </summary>
        /// <value> The logger. </value>
        protected ILogger Logger { get; set; }
        #endregion
    }
}
