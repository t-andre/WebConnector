// <copyright file="LogEventHandler.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the log event handler class</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSoft.Library.Core.Logging
{
    #region [Delegates]
    /// <summary> Delegate for handling Log events. </summary>
    /// <param name="log"> The log. </param>
    public delegate void LogEventHandler(LogItem log);
    #endregion
}
