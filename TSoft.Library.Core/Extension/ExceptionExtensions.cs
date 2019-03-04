// <copyright file="ExceptionExtensions.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the exception extensions class</summary>
using System;
using System.Text;

namespace TSoft.Library.Core
{
    /// <summary> An exception extensions. </summary>
    public static class ExceptionExtensions
    {
        #region [Public methods]
        /// <summary> An Exception extension method that flattens. </summary>
        /// <param name="ex">                The ex to act on. </param>
        /// <param name="message">           (Optional) The message. </param>
        /// <param name="includeStackTrace"> (Optional) True to include, false to exclude the stack trace. </param>
        /// <returns> A string. </returns>
        public static string Flatten(this Exception ex, string message = "", bool includeStackTrace = false)
        {
            StringBuilder sb = new StringBuilder(message);

            Exception current = ex;
            while (current != null)
            {
                sb.AppendLine(current.Message);
                if (includeStackTrace)
                    sb.Append(ex.StackTrace);

                current = current.InnerException;
                if (current != null && includeStackTrace)
                    sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary> An Exception extension method that format stack trace. </summary>
        /// <param name="exception"> The exception to act on. </param>
        /// <returns> The formatted stack trace. </returns>
        public static string FormatStackTrace(this Exception exception)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(exception.Message);
            sb.Append(exception.StackTrace);

            if (exception.InnerException != null)
            {
                return sb.Append(FormatStackTrace(exception.InnerException)).ToString();
            }
            else
            {
                return sb.ToString();
            }
        }
        #endregion
    }
}
