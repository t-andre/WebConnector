// <copyright file="CollectingSink.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the collecting sink class</summary>
using System.Collections.Generic;
using System.Linq;
using Serilog.Core;
using Serilog.Events;

namespace TSoft.Library.Logging.Sinks
{
    /// <summary> A collecting sink. </summary>
    /// <seealso cref="T:Serilog.Core.ILogEventSink"/>
    public class CollectingSink : ILogEventSink
    {
        #region [Public properties]
        /// <summary> Gets the events. </summary>
        /// <value> The events. </value>
        public List<LogEvent> Events { get; } = new List<LogEvent>();

        /// <summary> Gets the single event. </summary>
        /// <value> The single event. </value>
        public LogEvent SingleEvent { get { return this.Events.Single(); } }
        #endregion

        #region [Public methods]
        /// <summary> Emit the provided log event to the sink. </summary>
        /// <param name="logEvent"> The log event to write. </param>
        /// <seealso cref="M:Serilog.Core.ILogEventSink.Emit(LogEvent)"/>
        public void Emit(LogEvent logEvent)
        {
            this.Events.Add(logEvent);
        }
        #endregion
    }
}
