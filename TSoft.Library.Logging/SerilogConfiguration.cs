// <copyright file="SerilogConfiguration.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the serilog configuration class</summary>
using System;
using System.Linq;
using Serilog;

namespace TSoft.Library.Logging
{
    /// <summary> A serilog configuration. </summary>
    public static class SerilogConfiguration
    {
        #region [Constants]
        /// <summary> The log template header. </summary>
        public const string TemplateHeader = "Date      Time     | INFORMATION | Machine | User | Version | ThreadId | ModuleContext | Log";

        /// <summary> The template. </summary>
        public const string Template = "{Timestamp:dd.MM.yyyy HH:mm:ss} | {Level,-11:u} | {LogContext} | {Message}{NewLine}{Exception}";

        /// <summary> The second template. </summary>
        public const string Template2 = "{Timestamp:dd.MM.yyyy HH:mm:ss} | {Level,-11:u} | {MachineName} | {EnvironmentUserName} | {Version} | {ThreadId} | [{LogContext}] | {Message}{NewLine}{Exception}";
        #endregion

        #region [Public methods]
        /// <summary> A LoggerConfiguration extension method that writes to console. </summary>
        /// <param name="configuration">  The configuration to act on. </param>
        /// <param name="outputTemplate"> (Optional) The output template. </param>
        /// <returns> A LoggerConfiguration. </returns>
        public static LoggerConfiguration WriteToConsole(this LoggerConfiguration configuration, string outputTemplate = null)
        {
            configuration.WriteTo.Console(outputTemplate: string.IsNullOrEmpty(outputTemplate) ? Template : outputTemplate);
            return configuration;
        }

        /// <summary> A LoggerConfiguration extension method that writes to rolling file. </summary>
        /// <param name="configuration">  The configuration to act on. </param>
        /// <param name="fileName">       (Optional) Filename of the file. </param>
        /// <param name="outputTemplate"> (Optional) The output template. </param>
        /// <returns> A LoggerConfiguration. </returns>
        public static LoggerConfiguration WriteToRollingFile(this LoggerConfiguration configuration, string fileName = null, string outputTemplate = null)
        {
            fileName = string.IsNullOrEmpty(fileName) ? @"Logs\\Log-{Date}.log" : fileName;
            configuration.WriteTo.RollingFile(fileName, outputTemplate: string.IsNullOrEmpty(outputTemplate) ? Template : outputTemplate);
            return configuration;
        }
        #endregion
    }
}
