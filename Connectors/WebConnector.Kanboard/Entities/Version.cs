// <copyright file="Version.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>09.03.2019</date>
// <summary>Implements the version class</summary>
using System;

namespace WebConnector.Kanboard.Entities
{
    /// <summary> A version. </summary>
    /// <seealso cref="T:WebConnector.Kanboard.Entities.BaseResponse"/>
    public class Version : BaseResponse
    {
        #region [Public properties]
        /// <summary> Gets or sets the result. </summary>
        /// <value> The result. </value>
        public string result { get; set; }
        #endregion
    }
}
