// <copyright file="Url.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>09.03.2019</date>
// <summary>Implements the URL class</summary>
using System;

namespace WebConnector.Kanboard.Entities
{
    /// <summary> An url. </summary>
    public class Url
    {
        #region [Public properties]
        /// <summary> Gets or sets the board. </summary>
        /// <value> The board. </value>
        public string board { get; set; }

        /// <summary> Gets or sets the calendar. </summary>
        /// <value> The calendar. </value>
        public string calendar { get; set; }

        /// <summary> Gets or sets the list. </summary>
        /// <value> The list. </value>
        public string list { get; set; }
        #endregion
    }
}
