// <copyright file="LoggerBase.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the logger base class</summary>
using System;
using System.Collections.Generic;

namespace TSoft.Library.Core.Logging
{
    /// <summary> A logger base. </summary>
    /// <seealso cref="T:TSoft.Library.Core.Logging.ILogger"/>
	public abstract class LoggerBase : ILogger
    {
        #region [Fields]
        /// <summary> The log event delegates. </summary>
        private readonly List<LogEventHandler> logEventDelegates = new List<LogEventHandler>();
        #endregion

        #region [Events]
        /// <summary> Occurs when Log. </summary>
        private event LogEventHandler logEvent;

        /// <summary> Occurs when log. </summary>
		public virtual event LogEventHandler LogEvent
        {
            add
            {
                this.logEvent += value;
                this.logEventDelegates.Add(value);
            }
            remove
            {
                this.logEvent -= value;
                this.logEventDelegates.Remove(value);
            }
        }
        #endregion

        #region [Public properties]
        /// <summary> Gets or sets the log template. </summary>
        /// <value> The log template. </value>
        /// <seealso cref="P:TSoft.Library.Core.Logging.ILogger.LogTemplate"/>
        public string LogTemplate { get; set; }

        /// <summary> Gets or sets the log template header. </summary>
        /// <value> The log template header. </value>
        /// <seealso cref="P:TSoft.Library.Core.Logging.ILogger.LogTemplateHeader"/>
		public string LogTemplateHeader { get; set; }
        #endregion

        #region [Public methods]
        /// <summary> Debugs. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Debug(string,params object[])"/>
        public abstract void Debug(string messageTemplate, params object[] propertyValues);

        /// <summary> Debugs. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Debug(Exception,string,params object[])"/>
		public abstract void Debug(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Errors. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Error(string,params object[])"/>
		public abstract void Error(string messageTemplate, params object[] propertyValues);

        /// <summary> Errors. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Error(Exception,string,params object[])"/>
		public abstract void Error(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Fatals. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Fatal(string,params object[])"/>
		public abstract void Fatal(string messageTemplate, params object[] propertyValues);

        /// <summary> Fatals. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Fatal(Exception,string,params object[])"/>
		public abstract void Fatal(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Gets log provider. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns> The log provider. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.GetLogProvider{T}()"/>
		public virtual T GetLogProvider<T>()
        {
            return (T)GetLogProvider();
        }

        /// <summary> Gets log provider. </summary>
        /// <returns> The log provider. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.GetLogProvider()"/>
		public virtual object GetLogProvider()
        {
            return this;
        }

        /// <summary> Informations. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Information(string,params object[])"/>
		public abstract void Information(string messageTemplate, params object[] propertyValues);

        /// <summary> Informations. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Information(Exception,string,params object[])"/>
		public abstract void Information(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Query if 'level' is enabled. </summary>
        /// <param name="level"> The level. </param>
        /// <returns> True if enabled, false if not. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.IsEnabled(LogLevel)"/>
		public abstract bool IsEnabled(LogLevel level);

        /// <summary> Executes the log event action. </summary>
        /// <param name="e"> A LogItem to process. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.OnLogEvent(LogItem)"/>
		public virtual void OnLogEvent(LogItem e)
        {
            if (this.logEvent != null && e != null)
                this.logEvent(e);
        }

        /// <summary> Subscrib event log. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns> An ILogger. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.SubscribEventLog{T}()"/>
		public abstract ILogger SubscribEventLog<T>()
            where T : class;

        /// <summary> Subscrib event log. </summary>
        /// <param name="name"> The name. </param>
        /// <returns> An ILogger. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.SubscribEventLog(string)"/>
		public abstract ILogger SubscribEventLog(string name);

        /// <summary> Subscrib event log. </summary>
        /// <param name="name">  The name. </param>
        /// <param name="value"> The value. </param>
        /// <returns> An ILogger. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.SubscribEventLog(string,object)"/>
		public abstract ILogger SubscribEventLog(string name, object value);

        /// <summary> Verboses. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Verbose(string,params object[])"/>
		public abstract void Verbose(string messageTemplate, params object[] propertyValues);

        /// <summary> Verboses. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Verbose(Exception,string,params object[])"/>
		public abstract void Verbose(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Warnings. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Warning(string,params object[])"/>
		public abstract void Warning(string messageTemplate, params object[] propertyValues);

        /// <summary> Warnings. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Warning(Exception,string,params object[])"/>
		public abstract void Warning(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Writes. </summary>
        /// <param name="level">           The level. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Write(LogLevel,string,params object[])"/>
		public abstract void Write(LogLevel level, string messageTemplate, params object[] propertyValues);

        /// <summary> Writes. </summary>
        /// <param name="level">           The level. </param>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.ILogger.Write(LogLevel,Exception,string,params object[])"/>
		public abstract void Write(LogLevel level, Exception exception, string messageTemplate, params object[] propertyValues);
        #endregion
    }
}
