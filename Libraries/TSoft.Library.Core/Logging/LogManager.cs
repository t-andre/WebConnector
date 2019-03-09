// <copyright file="LogManager.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the log manager class</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSoft.Library.Core.Logging
{
    /// <summary> Manager for logs. </summary>
    public class LogManager
    {
        #region [Constructors]
        /// <summary> Initializes a new instance of the TSoft.Library.Core.Logging.LogManager class. </summary>
        /// <param name="logger"> The logger. </param>
        public LogManager(ILogger logger)
        {
            log = logger;
        }
        #endregion

        #region [Fields]
        /// <summary> The log. </summary>
        private static ILogger log = new NullLogger();
        #endregion

        #region [Public properties]
        /// <summary> Gets the log. </summary>
        /// <value> The log. </value>
        public static ILogger Log
        {
            get { return log; }
        }

        /// <summary> Gets the logger. </summary>
        /// <value> The logger. </value>
        public ILogger Logger
        {
            get { return log; }
        }
        #endregion

        #region [Public methods]
        /// <summary> Subscrib event log. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns> An ILogger. </returns>
        public static ILogger SubscribEventLog<T>()
            where T : class
        {
            return log.SubscribEventLog<T>();
        }

        /// <summary> Subscrib event log. </summary>
        /// <param name="name"> The name. </param>
        /// <returns> An ILogger. </returns>
        public static ILogger SubscribEventLog(string name)
        {
            return log.SubscribEventLog(name);
        }

        /// <summary> Subscrib event log. </summary>
        /// <param name="name">  The name. </param>
        /// <param name="value"> The value. </param>
        /// <returns> An ILogger. </returns>
        public static ILogger SubscribEventLog(string name, object value)
        {
            return log.SubscribEventLog(name, value);
        }
        #endregion
    }
}
