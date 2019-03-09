// <copyright file="LogItem.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the log item class</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSoft.Library.Core.Logging
{
    /// <summary> A log item. </summary>
    public class LogItem
    {
        #region [Constructors]
        /// <summary> Initializes a new instance of the TSoft.Library.Core.Logging.LogItem class. </summary>
        public LogItem()
        {
            Title = String.Empty;
            Message = String.Empty;
            LogLevel = LogLevel.Information;
            LoggerName = String.Empty;

            Parameter1 = string.Empty;
            Parameter2 = string.Empty;

            Timestamp = DateTimeOffset.Now;
        }
        #endregion

        #region [Public properties]
        /// <summary> Gets or sets the identifier of the event. </summary>
        /// <value> The identifier of the event. </value>
        public int? EventId { get; set; }

        /// <summary> Gets or sets the exception. </summary>
        /// <value> The exception. </value>
        public Exception Exception { get; set; }

        /// <summary> Gets or sets the name of the logger. </summary>
        /// <value> The name of the logger. </value>
        public string LoggerName { get; set; }

        /// <summary> Gets or sets the log level. </summary>
        /// <value> The log level. </value>
        public LogLevel LogLevel { get; set; }

        /// <summary> Gets or sets the message. </summary>
        /// <value> The message. </value>
        public string Message { get; set; }

        /// <summary> Gets or sets the parameter 1. </summary>
        /// <value> The parameter 1. </value>
        public string Parameter1 { get; set; }

        /// <summary> Gets or sets the parameter 2. </summary>
        /// <value> The parameter 2. </value>
        public string Parameter2 { get; set; }

        /// <summary> Gets or sets the timestamp. </summary>
        /// <value> The timestamp. </value>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary> Gets or sets the title. </summary>
        /// <value> The title. </value>
        public string Title { get; set; }
        #endregion

        #region [Public methods]
        /// <summary> Makes a deep copy of this LogItem. </summary>
        /// <returns> A copy of this LogItem. </returns>
        public LogItem Clone()
        {
            LogItem clone = new LogItem
            {
                Title = Title,
                Message = Message,
                Exception = Exception,
                EventId = EventId,
                LogLevel = LogLevel,
                Timestamp = Timestamp,
                LoggerName = LoggerName,
                Parameter1 = Parameter1,
                Parameter2 = Parameter2
            };
            return clone;
        }

        /// <summary> Returns a string that represents the current object. </summary>
        /// <returns> A string that represents the current object. </returns>
        /// <seealso cref="M:System.Object.ToString()"/>
        public override string ToString()
        {
            return string.Format("{0:g} [ {1,-6:}] {3} {2}", this.Timestamp, this.LogLevel, this.Message, this.LoggerName);
        }
        #endregion
    }
}
