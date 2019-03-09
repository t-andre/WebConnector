// <copyright file="SerilogLogger.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the serilog logger class</summary>
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Display;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TSoft.Library.Core.Logging;
using TSoft.Library.Logging.Sinks;
using ILogger = TSoft.Library.Core.Logging.ILogger;

namespace TSoft.Library.Logging
{
    /// <summary> A serilog logger. </summary>
    /// <typeparam name="T"> Generic type parameter. </typeparam>
    /// <seealso cref="T:TSoft.Library.Logging.SerilogLogger"/>
    public class SerilogLogger<T> : SerilogLogger
    {
        #region [Constructors]
        /// <summary> Initializes a new instance of the TSoft.Library.Logging.SerilogLogger&lt;T&gt; class. </summary>
        /// <param name="loggerConfiguration"> (Optional) The logger configuration. </param>
        public SerilogLogger(Func<LoggerConfiguration, LoggerConfiguration> loggerConfiguration = null)
        {
            this.LogTemplate = SerilogConfiguration.Template;
            this.LogTemplateHeader = SerilogConfiguration.TemplateHeader;

            if (!initialised)
            {
                Serilog.Debugging.SelfLog.Enable(Console.Out);
                var configuration = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    //.Enrich.WithThreadId()
                    //.Enrich.WithEnvironmentUserName()
                    //.Enrich.WithProperty("Version", "1.0.0")
                    .WriteTo.Sink(new DelegatingSink(LogHandler));

                if (loggerConfiguration != null)
                {
                    configuration = loggerConfiguration(configuration);
                }
                else
                {
                    configuration
                        .WriteToConsole()
                        .WriteToRollingFile();
                }

                log = configuration
                    .CreateLogger()
                    .ForContext<T>();
                Log.Logger = log;
                initialised = true;
            }
            else
            {
                log = Log.ForContext<T>();
            }
        }

        /// <summary> Initializes a new instance of the TSoft.Library.Logging.SerilogLogger&lt;T&gt; class. </summary>
        /// <param name="context">             The context. </param>
        /// <param name="loggerConfiguration"> (Optional) The logger configuration. </param>
        public SerilogLogger(string context, Func<LoggerConfiguration, LoggerConfiguration> loggerConfiguration = null) : base(context, loggerConfiguration)
        {

        }

        /// <summary> Initializes a new instance of the TSoft.Library.Logging.SerilogLogger&lt;T&gt; class. </summary>
        /// <param name="context">             The context. </param>
        /// <param name="value">               The value. </param>
        /// <param name="loggerConfiguration"> (Optional) The logger configuration. </param>
        public SerilogLogger(string context, object value, Func<LoggerConfiguration, LoggerConfiguration> loggerConfiguration = null) : base(context, value, loggerConfiguration)
        {

        }
        #endregion
    }

    /// <summary> A serilog logger. </summary>
    /// <seealso cref="T:TSoft.Library.Core.Logging.LoggerBase"/>
    public class SerilogLogger : LoggerBase
    {
        #region [Constructors]
        /// <summary> Initializes a new instance of the TSoft.Library.Logging.SerilogLogger class. </summary>
        /// <param name="loggerConfiguration"> (Optional) The logger configuration. </param>
        public SerilogLogger(Func<LoggerConfiguration, LoggerConfiguration> loggerConfiguration = null) : this("Main", loggerConfiguration)
        {
        }

        /// <summary> Initializes a new instance of the TSoft.Library.Logging.SerilogLogger class. </summary>
        /// <param name="context">             The context. </param>
        /// <param name="loggerConfiguration"> (Optional) The logger configuration. </param>
        public SerilogLogger(string context, Func<LoggerConfiguration, LoggerConfiguration> loggerConfiguration = null) : this("LogContext", context, loggerConfiguration)
        {
        }

        /// <summary> Initializes a new instance of the TSoft.Library.Logging.SerilogLogger class. </summary>
        /// <param name="context">             The context. </param>
        /// <param name="value">               The value. </param>
        /// <param name="loggerConfiguration"> (Optional) The logger configuration. </param>
        public SerilogLogger(string context, object value, Func<LoggerConfiguration, LoggerConfiguration> loggerConfiguration = null)
        {
            this.LogTemplate = SerilogConfiguration.Template;
            this.LogTemplateHeader = SerilogConfiguration.TemplateHeader;

            if (!initialised)
            {
                Serilog.Debugging.SelfLog.Enable(Console.Out);
                var configuration = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .Enrich.WithProperty("Version", "1.0.0")
                    .WriteTo.Sink(new DelegatingSink(LogHandler));

                if (loggerConfiguration != null)
                {
                    configuration = loggerConfiguration(configuration);
                }
                else
                {
                    configuration
                        .WriteToConsole()
                        .WriteToRollingFile();
                }

                log = configuration
                    .CreateLogger()
                    .ForContext(context, value, true);
                Log.Logger = log;
                initialised = true;
            }
            else
            {
                log = Log.ForContext(context, value, true);
            }

        }
        #endregion

        #region [Fields]
        /// <summary> True once initialisation is complete. </summary>
        protected static bool initialised;

        /// <summary> The log. </summary>
        protected Serilog.ILogger log;
        #endregion

        #region [Public properties]
        /// <summary> Gets the serilog core. </summary>
        /// <value> The serilog core. </value>
        public Serilog.ILogger SerilogCore { get => log; }
        #endregion

        #region [Public methods]
        /// <summary> Debugs. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Debug(string,params object[])"/>
        public override void Debug(string messageTemplate, params object[] propertyValues)
        {
            log.Debug(messageTemplate, propertyValues);
        }

        /// <summary> Debugs. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Debug(Exception,string,params object[])"/>
        public override void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            log.Debug(exception, messageTemplate, propertyValues);
        }

        /// <summary> Errors. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Error(string,params object[])"/>
        public override void Error(string messageTemplate, params object[] propertyValues)
        {
            log.Error(messageTemplate, propertyValues);
        }

        /// <summary> Errors. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Error(Exception,string,params object[])"/>
        public override void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            log.Error(exception, messageTemplate, propertyValues);
        }

        /// <summary> Fatals. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Fatal(string,params object[])"/>
        public override void Fatal(string messageTemplate, params object[] propertyValues)
        {
            log.Fatal(messageTemplate, propertyValues);
        }

        /// <summary> Fatals. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Fatal(Exception,string,params object[])"/>
        public override void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            log.Fatal(exception, messageTemplate, propertyValues);
        }

        /// <summary> For context. </summary>
        /// <typeparam name="TSource"> Type of the source. </typeparam>
        /// <returns> A Serilog.ILogger. </returns>
        public Serilog.ILogger ForContext<TSource>()
        {
            return log.ForContext<TSource>();
        }

        /// <summary> For context. </summary>
        /// <param name="enrichers"> The enrichers. </param>
        /// <returns> A Serilog.ILogger. </returns>
        public Serilog.ILogger ForContext(IEnumerable<ILogEventEnricher> enrichers)
        {
            return log.ForContext(enrichers);
        }

        /// <summary> For context. </summary>
        /// <param name="source"> Source for the. </param>
        /// <returns> A Serilog.ILogger. </returns>
        public Serilog.ILogger ForContext(Type source)
        {
            return log.ForContext(source);
        }

        /// <summary> For context. </summary>
        /// <param name="propertyName">       Name of the property. </param>
        /// <param name="value">              The value. </param>
        /// <param name="destructureObjects"> (Optional) True to destructure objects. </param>
        /// <returns> A Serilog.ILogger. </returns>
        public Serilog.ILogger ForContext(string propertyName, object value, bool destructureObjects = false)
        {
            return log.ForContext(propertyName, value, destructureObjects);
        }

        /// <summary> Gets log provider. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns> The log provider. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.GetLogProvider{T}()"/>
        public override T GetLogProvider<T>()
        {
            return (T)GetLogProvider();
        }

        /// <summary> Gets log provider. </summary>
        /// <returns> The log provider. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.GetLogProvider()"/>
        public override object GetLogProvider()
        {
            return this.SerilogCore;
        }

        /// <summary> Informations. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Information(string,params object[])"/>
        public override void Information(string messageTemplate, params object[] propertyValues)
        {
            log.Information(messageTemplate, propertyValues);
        }

        /// <summary> Informations. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Information(Exception,string,params object[])"/>
        public override void Information(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            log.Information(exception, messageTemplate, propertyValues);
        }

        /// <summary> Query if 'level' is enabled. </summary>
        /// <param name="level"> The level. </param>
        /// <returns> True if enabled, false if not. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.IsEnabled(LogLevel)"/>
        public override bool IsEnabled(LogLevel level)
        {
            return log.IsEnabled((Serilog.Events.LogEventLevel)level);
        }

        /// <summary> Subscrib event log. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns> An ILogger. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.SubscribEventLog{T}()"/>
        public override ILogger SubscribEventLog<T>()
        {
            return new SerilogLogger<T>();
        }

        /// <summary> Subscrib event log. </summary>
        /// <param name="name"> The name. </param>
        /// <returns> An ILogger. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.SubscribEventLog(string)"/>
        public override ILogger SubscribEventLog(string name)
        {
            return new SerilogLogger(name);
        }

        /// <summary> Subscrib event log. </summary>
        /// <param name="name">  The name. </param>
        /// <param name="value"> The value. </param>
        /// <returns> An ILogger. </returns>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.SubscribEventLog(string,object)"/>
        public override ILogger SubscribEventLog(string name, object value)
        {
            return new SerilogLogger(name, value);
        }

        /// <summary> Verboses. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Verbose(string,params object[])"/>
        public override void Verbose(string messageTemplate, params object[] propertyValues)
        {
            log.Verbose(messageTemplate, propertyValues);
        }

        /// <summary> Verboses. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Verbose(Exception,string,params object[])"/>
        public override void Verbose(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            log.Verbose(exception, messageTemplate, propertyValues);
        }

        /// <summary> Warnings. </summary>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Warning(string,params object[])"/>
        public override void Warning(string messageTemplate, params object[] propertyValues)
        {
            log.Warning(messageTemplate, propertyValues);
        }

        /// <summary> Warnings. </summary>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Warning(Exception,string,params object[])"/>
        public override void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            log.Warning(exception, messageTemplate, propertyValues);
        }

        /// <summary> Writes. </summary>
        /// <param name="level">           The level. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Write(LogLevel,string,params object[])"/>
        public override void Write(LogLevel level, string messageTemplate, params object[] propertyValues)
        {
            log.Write((Serilog.Events.LogEventLevel)level, messageTemplate, propertyValues);
        }

        /// <summary> Writes. </summary>
        /// <param name="level">           The level. </param>
        /// <param name="exception">       The exception. </param>
        /// <param name="messageTemplate"> The message template. </param>
        /// <param name="propertyValues">  A variable-length parameters list containing property values. </param>
        /// <seealso cref="M:TSoft.Library.Core.Logging.LoggerBase.Write(LogLevel,Exception,string,params object[])"/>
        public override void Write(LogLevel level, Exception exception, string messageTemplate, params object[] propertyValues)
        {
            log.Write((Serilog.Events.LogEventLevel)level, exception, messageTemplate, propertyValues);
        }
        #endregion

        #region [Protected methods]
        /// <summary> Handler, called when the log. </summary>
        /// <param name="logEvent"> The log event. </param>
        protected void LogHandler(LogEvent logEvent)
        {
            var formatter = new MessageTemplateTextFormatter(this.LogTemplate, new CultureInfo("en-US"));
            var sw = new StringWriter();
            formatter.Format(logEvent, sw);

            LogItem logItem = new LogItem
            {
                LoggerName = "MainLog",
                LogLevel = (LogLevel)logEvent.Level,
                Timestamp = logEvent.Timestamp,
                Message = sw.ToString(),
                Exception = logEvent.Exception
            };
            this.OnLogEvent(logItem);
        }
        #endregion
    }
}
