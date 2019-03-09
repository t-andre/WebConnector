// <copyright file="LogCategory.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the log category class</summary>
using System;

namespace TSoft.Library.Core.Logging
{
    /// <summary> Values that represent log categories. </summary>
    public enum LogCategory
    {
        /// <summary> An enum constant representing the debug option. </summary>
        Debug = 0,

        /// <summary> An enum constant representing the exception option. </summary>
        Exception = 1,

        /// <summary> An enum constant representing the Information option. </summary>
        Info = 2,

        /// <summary> An enum constant representing the Warning option. </summary>
        Warn = 3
    }
}
