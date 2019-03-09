// <copyright file="DelegatingSink.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the delegating sink class</summary>
using System;
using Serilog.Core;
using Serilog.Events;
using Serilog;

namespace TSoft.Library.Logging.Sinks
{
    /// <summary> A delegating sink. </summary>
    /// <seealso cref="T:Serilog.Core.ILogEventSink"/>
    public class DelegatingSink : ILogEventSink
    {
        #region [Constructors]
        /// <summary> Initializes a new instance of the TSoft.Library.Logging.Sinks.DelegatingSink class. </summary>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null. </exception>
        /// <param name="write"> The write. </param>
        public DelegatingSink(Action<LogEvent> write)
        {
            this.write = write ?? throw new ArgumentNullException(nameof(write));
        }
        #endregion

        #region [Fields]
        /// <summary> The write. </summary>
        private readonly Action<LogEvent> write;
        #endregion

        #region [Public methods]
        /// <summary> Emit the provided log event to the sink. </summary>
        /// <param name="logEvent"> The log event to write. </param>
        /// <seealso cref="M:Serilog.Core.ILogEventSink.Emit(LogEvent)"/>
        public void Emit(LogEvent logEvent)
        {
            this.write(logEvent);
        }

        /// <summary> Gets log event. </summary>
        /// <param name="writeAction"> The write action. </param>
        /// <returns> The log event. </returns>
        public static LogEvent GetLogEvent(Action<Serilog.ILogger> writeAction)
        {
            LogEvent result = null;
            var l = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Sink(new DelegatingSink(le => result = le))
                .CreateLogger();

            writeAction(l);
            return result;
        }
        #endregion
    }
}
