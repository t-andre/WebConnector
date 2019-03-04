// <copyright file="TypeExtension.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the type extension class</summary>
using System;
using System.Collections.Generic;
using System.Linq;

namespace TSoft.Library.Core
{
    /// <summary> A type extension. </summary>
    public static class TypeExtension
    {
        #region [Public methods]
        /// <summary> A Type extension method that query if 't' has default constructor. </summary>
        /// <param name="t"> The t to act on. </param>
        /// <returns> True if default constructor, false if not. </returns>
        public static bool HasDefaultConstructor(this Type t)
        {
            return t.GetConstructors().Count(c => c.GetParameters().Length <= 0) > 0;
        }

        /// <summary> A Type extension method that converts a t to a generic type string. </summary>
        /// <param name="t"> The t to act on. </param>
        /// <returns> T as a string. </returns>
        public static string ToGenericTypeString(this Type t)
        {
            if (!t.IsGenericType)
                return t.Name;

            string genericTypeName = t.GetGenericTypeDefinition().Name;
            genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
            string genericArgs = string.Join(",", t.GetGenericArguments().Select(ToGenericTypeString));
            return $"{genericTypeName}<{genericArgs}>";
        }
        #endregion
    }
}
