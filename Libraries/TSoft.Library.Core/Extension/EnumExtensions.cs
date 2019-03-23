// <copyright file="EnumExtensions.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the enumeration extensions class</summary>
using System;
using System.Collections.Generic;
using System.Globalization;

namespace TSoft.Library.Core
{
    /// <summary> An enumeration extensions. </summary>
    public static class EnumExtensions
    {
        #region [Public methods]
        /// <summary> An Enum extension method that adds type. </summary>
        /// <exception cref="ArgumentException"> Thrown when one or more arguments have unsupported or illegal values. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="type">  The type to act on. </param>
        /// <param name="value"> The value. </param>
        /// <returns> A T. </returns>
        public static T Add<T>(this Enum type, T value)
        {
            try
            {
                return (T)(object)((int)(object)type | (int)(object)value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not append value from enumerated type '{0}'.",
                        typeof(T).Name
                        ), ex);
            }
        }

        /// <summary> An Enum extension method that query if this EnumExtensions contains the given type. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="type">  The type to act on. </param>
        /// <param name="value"> The value. </param>
        /// <returns> True if the object is in this collection, false if not. </returns>
        public static bool Contains<T>(this Enum type, T value)
        {
            try
            {
                return ((int)(object)type & (int)(object)value) != 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary> Gets all items in this collection. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns> An enumerator that allows foreach to be used to process all items in this collection. </returns>
        public static IEnumerable<T> GetAllItems<T>()
            where T : struct
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }

        /// <summary> Gets all items in this collection. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="value"> The value. </param>
        /// <returns> An enumerator that allows foreach to be used to process all items in this collection. </returns>
        public static IEnumerable<T> GetAllItems<T>(this Enum value)
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }

        /// <summary> Gets all selected items in this collection. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="value"> The value. </param>
        /// <returns> An enumerator that allows foreach to be used to process all selected items in this collection. </returns>
        public static IEnumerable<T> GetAllSelectedItems<T>(this Enum value)
        {
            int valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);

            foreach (object item in Enum.GetValues(typeof(T)))
            {
                int itemAsInt = Convert.ToInt32(item, CultureInfo.InvariantCulture);

                if (itemAsInt == (valueAsInt & itemAsInt))
                {
                    yield return (T)item;
                }
            }
        }

        /// <summary> An Enum extension method that gets value int. </summary>
        /// <param name="value"> The value. </param>
        /// <returns> The value int. </returns>
        public static int GetValueInt(this Enum value)
        {
            return (int)Enum.Parse(value.GetType(), Enum.GetName(value.GetType(), value));
        }

        /// <summary> An Enum extension method that gets value string. </summary>
        /// <param name="value"> The value. </param>
        /// <returns> The value string. </returns>
        public static string GetValueString(this Enum value)
        {
            return ((int)Enum.Parse(value.GetType(), Enum.GetName(value.GetType(), value))).ToString();
        }

        /// <summary> An Enum extension method that has. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="type">  The type to act on. </param>
        /// <param name="value"> The value. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        public static bool Has<T>(this Enum type, T value)
        {
            try
            {
                return ((int)(object)type & (int)(object)value) == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary> An Enum extension method that is. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="type">  The type to act on. </param>
        /// <param name="value"> The value. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        public static bool Is<T>(this Enum type, T value)
        {
            try
            {
                return (int)(object)type == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary> An Enum extension method that lengths the given type. </summary>
        /// <exception cref="ArgumentException"> Thrown when one or more arguments have unsupported or illegal values. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="type"> The type to act on. </param>
        /// <returns> An int. </returns>
        public static int Length<T>(this Enum type)
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Type T must be an enumeration", "T");
            return Enum.GetNames(typeof(T)).Length;
        }

        /// <summary> Parse to enumeration. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="value"> The value. </param>
        /// <returns> A T. </returns>
        public static T ParseToEnum<T>(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"{nameof(value)} is null or empty.", nameof(value));
            }

            object enumParse = Enum.Parse(typeof(T), value);
            return (T)enumParse;
        }

        /// <summary> An Enum extension method that removes this EnumExtensions. </summary>
        /// <exception cref="ArgumentException"> Thrown when one or more arguments have unsupported or illegal values. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="type">  The type to act on. </param>
        /// <param name="value"> The value. </param>
        /// <returns> A T. </returns>
        public static T Remove<T>(this Enum type, T value)
        {
            try
            {
                return (T)(object)((int)(object)type & ~(int)(object)value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not remove value from enumerated type '{0}'.",
                        typeof(T).Name
                        ), ex);
            }
        }
        #endregion
    }
}
