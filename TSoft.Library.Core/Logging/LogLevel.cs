// <copyright file="LogLevel.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the log level class</summary>
using System;

namespace TSoft.Library.Core.Logging
{
    /// <summary> Values that represent log levels. </summary>
    public enum LogLevel
    {
        /// <summary> . </summary>
        Verbose = 0,

        /// <summary> An enum constant representing the debug option. </summary>
        Debug = 1,

        /// <summary> An enum constant representing the information option. </summary>
        Information = 2,

        /// <summary> An enum constant representing the warning option. </summary>
        Warning = 3,

        /// <summary> An enum constant representing the error option. </summary>
        Error = 4,

        /// <summary> An enum constant representing the fatal option. </summary>
        Fatal = 5
    }
}
