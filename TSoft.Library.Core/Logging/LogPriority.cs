// <copyright file="LogPriority.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the log priority class</summary>
using System;

namespace TSoft.Library.Core.Logging
{
    /// <summary> Values that represent log priorities. </summary>
    public enum LogPriority
    {
        /// <summary> An enum constant representing the none option. </summary>
        None = 0,

        /// <summary> An enum constant representing the high option. </summary>
        High = 1,

        /// <summary> An enum constant representing the medium option. </summary>
        Medium = 2,

        /// <summary> An enum constant representing the low option. </summary>
        Low = 3
    }
}
