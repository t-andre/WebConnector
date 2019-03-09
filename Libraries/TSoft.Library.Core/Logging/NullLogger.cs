// <copyright file="NullLogger.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the null logger class</summary>
using System;

namespace TSoft.Library.Core.Logging
{
    /// <summary> A null logger. </summary>
    /// <seealso cref="T:TSoft.Library.Core.Logging.LoggerBase"/>
    /// <seealso cref="T:TSoft.Library.Core.Logging.ILogger"/>
    public class NullLogger : LoggerBase, ILogger
    {
        #region [Constructors]
        /// <summary> Initializes a new instance of the TSoft.Library.Core.Logging.NullLogger class. </summary>
        public NullLogger()
        {
        }
        #endregion

        #region [Events]
        /// <summary> Occurs when log. </summary>
        public override event LogEventHandler LogEvent;
        #endregion

        #region [Public methods]
        /// <summary> Debugs. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Debug(string,params object[])"/>
        public override void Debug(string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Debugs. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Debug(Exception,string,params object[])"/>
        public override void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Errors. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Error(string,params object[])"/>
        public override void Error(string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Errors. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Error(Exception,string,params object[])"/>
        public override void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Fatals. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Fatal(string,params object[])"/>
        public override void Fatal(string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Fatals. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Fatal(Exception,string,params object[])"/>
        public override void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Gets log provider. </summary>
        /// <typeparam name="NullLogger"> Type of the null logger. </typeparam>
        /// <returns> The log provider. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.NullLogger.GetLogProvider{NullLogger}()"/>
		public override NullLogger GetLogProvider<NullLogger>()
        {
            return (NullLogger)GetLogProvider();
        }

        /// <summary> Gets log provider. </summary>
        /// <returns> The log provider. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.GetLogProvider()"/>
		public override object GetLogProvider()
        {
            return this;
        }

        /// <summary> Informations. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Information(string,params object[])"/>
        public override void Information(string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Informations. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Information(Exception,string,params object[])"/>
        public override void Information(Exception exception, string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Query if 'level' is enabled. </summary>
        /// <param name="level"> The level. </param>
        /// <returns> True if enabled, false if not. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.IsEnabled(LogLevel)"/>
        public override bool IsEnabled(LogLevel level)
        {
            return true;
        }

        /// <summary> Executes the log event action. </summary>
        /// <param name="e"> A LogItem to process. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.OnLogEvent(LogItem)"/>
        public override void OnLogEvent(LogItem e)
        {
        }

        /// <summary> Subscrib event log. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns> An ILogger. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.SubscribEventLog{T}()"/>
        public override ILogger SubscribEventLog<T>()
        {
            return new NullLogger();
        }

        /// <summary> Subscrib event log. </summary>
        /// <param name="name"> The name. </param>
        /// <returns> An ILogger. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.SubscribEventLog(string)"/>
        public override ILogger SubscribEventLog(string name)
        {
            return new NullLogger();
        }

        /// <summary> Subscrib event log. </summary>
        /// <param name="name">  The name. </param>
        /// <param name="value"> The value. </param>
        /// <returns> An ILogger. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.SubscribEventLog(string,object)"/>
        public override ILogger SubscribEventLog(string name, object value)
        {
            return new NullLogger();
        }

        /// <summary> Verboses. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Verbose(string,params object[])"/>
        public override void Verbose(string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Verboses. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Verbose(Exception,string,params object[])"/>
        public override void Verbose(Exception exception, string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Warnings. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Warning(string,params object[])"/>
        public override void Warning(string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Warnings. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Warning(Exception,string,params object[])"/>
        public override void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Writes. </summary>
        /// <param name="level">           The level. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Write(LogLevel,string,params object[])"/>
        public override void Write(LogLevel level, string messageTemplate, params object[] propertyValues)
        {
        }

        /// <summary> Writes. </summary>
        /// <param name="level">           The level. </param>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Write(LogLevel,Exception,string,params object[])"/>
        public override void Write(LogLevel level, Exception exception, string messageTemplate, params object[] propertyValues)
        {
        }
        #endregion
    }
}
