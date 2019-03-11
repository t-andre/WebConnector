// <copyright file="BaseRequest.cs" company="Tavares Software Developement">
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
    /// <summary> A base request. </summary>
    public class BaseRequest
    {
        #region [Constructors]
        /// <summary> Initializes a new instance of the WebConnector.Kanboard.Entities.BaseRequest class. </summary>
        public BaseRequest()
        {

        }

        /// <summary> Initializes a new instance of the WebConnector.Kanboard.Entities.BaseRequest class. </summary>
        /// <param name="method">     The method. </param>
        /// <param name="id">         The identifier. </param>
        /// <param name="parameters"> (Optional) Options for controlling the operation. </param>
        public BaseRequest(string method, int id, object parameters = null)
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
        /// <summary> Creates a new BaseRequest. </summary>
        /// <param name="method">     The method. </param>
        /// <param name="id">         The identifier. </param>
        /// <param name="parameters"> (Optional) Options for controlling the operation. </param>
        /// <returns> A BaseRequest. </returns>
        public static BaseRequest Create(string method, int id, dynamic parameters = null)
        {
            return new BaseRequest
            {
                method = method,
                id = id,
                @params = parameters
            };
        }
        #endregion
    }
}
