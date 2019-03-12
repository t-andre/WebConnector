// <copyright file="Request.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>09.03.2019</date>
// <summary>Implements the base request class</summary>
using System;
using System.Collections.Generic;
using System.Text;

namespace WebConnector.Kanboard.Entities
{

    /// <summary> A request. </summary>
    public class Request
    {
        #region [Constructors]

        /// <summary> Initializes a new instance of the WebConnector.Kanboard.Entities.Request class. </summary>
        public Request()
        {

        }

        /// <summary> Initializes a new instance of the WebConnector.Kanboard.Entities.Request class. </summary>
        /// <param name="method">     The method. </param>
        /// <param name="id">         The identifier. </param>
        /// <param name="parameters"> (Optional) Options for controlling the operation. </param>
        public Request(string method, int id, object parameters = null)
        {
            this.method = method;
            this.id = id;
            this.@params = parameters;
        }
        #endregion

        #region [Public properties]

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int id { get; set; }

        /// <summary> Gets or sets the jsonrpc. </summary>
        /// <value> The jsonrpc. </value>
        public string jsonrpc { get; set; } = "2.0";

        /// <summary> Gets or sets the method. </summary>
        /// <value> The method. </value>
        public string method { get; set; }

        /// <summary> Gets or sets options for controlling the operation. </summary>
        /// <value> The parameters. </value>
        public dynamic @params { get; set; }
        #endregion

        #region [Public methods]

        /// <summary> Creates a new Request. </summary>
        /// <param name="method">     The method. </param>
        /// <param name="id">         The identifier. </param>
        /// <param name="parameters"> (Optional) Options for controlling the operation. </param>
        /// <returns> A Request. </returns>
        public static Request Create(string method, int id, dynamic parameters = null)
        {
            return new Request
            {
                method = method,
                id = id,
                @params = parameters
            };
        }
        #endregion
    }
}
