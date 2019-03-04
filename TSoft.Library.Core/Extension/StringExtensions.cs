// <copyright file="StringExtensions.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the string extensions class</summary>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TSoft.Library.Core
{
    /// <summary> A string extensions. </summary>
    public static class StringExtensions
    {
        #region [Public methods]
        /// <summary> An object extension method that string empty if null. </summary>
        /// <param name="value"> The value to act on. </param>
        /// <returns> A string. </returns>
        public static string StringEmptyIfNull(this object value)
        {
            return value == null ? string.Empty : value.ToString();
        }
        #endregion
    }
}
