// <copyright file="ILogger.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Declares the ILogger interface</summary>
using System;

namespace TSoft.Library.Core.Logging
{
    /// <summary> Interface for logger. </summary>
	public interface ILogger
    {
        #region [Properties Implementation]
        /// <summary> Gets or sets the log template. </summary>
        /// <value> The log template. </value>
        string LogTemplate { get; set; }

        /// <summary> Gets or sets the log template header. </summary>
        /// <value> The log template header. </value>
		string LogTemplateHeader { get; set; }
        #endregion

        #region [Methods Implementation]
        /// <summary> Debugs. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        void Debug(string messageTemplate, params object[] propertyValues);

        /// <summary> Debugs. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Debug(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Errors. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Error(string messageTemplate, params object[] propertyValues);

        /// <summary> Errors. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Error(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Fatals. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Fatal(string messageTemplate, params object[] propertyValues);

        /// <summary> Fatals. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Fatal(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Gets log provider. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns> The log provider. </returns>
		T GetLogProvider<T>();

        /// <summary> Gets log provider. </summary>
        /// <returns> The log provider. </returns>
		object GetLogProvider();

        /// <summary> Informations. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Information(string messageTemplate, params object[] propertyValues);

        /// <summary> Informations. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Information(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Query if 'level' is enabled. </summary>
        /// <param name="level"> The level. </param>
        /// <returns> True if enabled, false if not. </returns>
		bool IsEnabled(LogLevel level);

        /// <summary> Executes the log event action. </summary>
        /// <param name="e"> A LogItem to process. </param>
		void OnLogEvent(LogItem e);

        /// <summary> Subscrib event log. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns> An ILogger. </returns>
		ILogger SubscribEventLog<T>() where T : class;

        /// <summary> Subscrib event log. </summary>
        /// <param name="name"> The name. </param>
        /// <returns> An ILogger. </returns>
		ILogger SubscribEventLog(string name);

        /// <summary> Subscrib event log. </summary>
        /// <param name="name">  The name. </param>
        /// <param name="value"> The value. </param>
        /// <returns> An ILogger. </returns>
		ILogger SubscribEventLog(string name, object value);

        /// <summary> Verboses. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Verbose(string messageTemplate, params object[] propertyValues);

        /// <summary> Verboses. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Verbose(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Warnings. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Warning(string messageTemplate, params object[] propertyValues);

        /// <summary> Warnings. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Warning(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary> Writes. </summary>
        /// <param name="level">           The level. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Write(LogLevel level, string messageTemplate, params object[] propertyValues);

        /// <summary> Writes. </summary>
        /// <param name="level">           The level. </param>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
		void Write(LogLevel level, Exception exception, string messageTemplate, params object[] propertyValues);
        #endregion

        #region [Events]
        /// <summary> Occurs when log. </summary>
        event LogEventHandler LogEvent;
        #endregion
    }
}
