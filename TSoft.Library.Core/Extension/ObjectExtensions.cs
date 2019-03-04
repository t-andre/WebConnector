// <copyright file="ObjectExtensions.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the object extensions class</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TSoft.Library.Core
{
    /// <summary> An object extensions. </summary>
    public static class ObjectExtensions
    {
        #region [Fields]
        /// <summary> The object cache. </summary>
        public static ConditionalWeakTable<object, Dictionary<string, object>> ObjectCache = new ConditionalWeakTable<object, Dictionary<string, object>>();
        #endregion

        #region [Public methods]
        /// <summary> Copies the object values. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="source">      Another instance to copy. </param>
        /// <param name="destination"> Destination for the. </param>
        /// <returns> A T. </returns>
        public static T CopyObjectValues<T>(T source, T destination)
        {
            foreach (PropertyInfo propertyInfo in source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                propertyInfo.SetValue(destination, propertyInfo.GetValue(source, null), null);
            }
            return destination;
        }

        /// <summary> Creates object instance. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="instanceObject"> [in,out] The instance object. </param>
        /// <returns> The new object instance. </returns>
        public static T CreateObjectInstance<T>(ref T instanceObject)
            where T : class, new()
        {
            if (instanceObject == null)
            {
                instanceObject = new T();
            }

            return instanceObject;
        }

        /// <summary> A T extension method that gets object custom attributes. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="sender"> The sender to act on. </param>
        /// <param name="type">   (Optional) The type. </param>
        /// <returns> An array of object. </returns>
        public static object[] GetObjectCustomAttributes<T>(this T sender, Type type = null)
        {
            if (EqualityComparer<T>.Default.Equals(sender, default(T)))
                return null;

            try
            {
                Type tp = typeof(T);
                return tp.GetCustomAttributes(type, true);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary> A T extension method that gets propertie value. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="sender">    The sender to act on. </param>
        /// <param name="propertie"> The propertie. </param>
        /// <returns> The propertie value. </returns>
        public static object GetPropertieValue<T>(this T sender, string propertie)
        {
            if (EqualityComparer<T>.Default.Equals(sender, default(T)) || string.IsNullOrEmpty(propertie))
                return null;

            try
            {
                PropertyInfo p = sender.GetType().GetProperty(propertie);
                return p?.GetValue(sender, null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary> An object extension method that gets a value. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="obj">  The obj to act on. </param>
        /// <param name="name"> The name. </param>
        /// <returns> The value. </returns>
        public static T GetValue<T>(this object obj, string name)
        {
            if (ObjectCache.TryGetValue(obj, out Dictionary<string, object> properties) && properties.ContainsKey(name))
                return (T)properties[name];
            else
                return default(T);
        }

        /// <summary> An object extension method that gets a value. </summary>
        /// <param name="obj">  The obj to act on. </param>
        /// <param name="name"> The name. </param>
        /// <returns> The value. </returns>
        public static object GetValue(this object obj, string name)
        {
            return obj.GetValue<object>(name);
        }

        /// <summary> A T extension method that sets propertie value. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="sender">    The sender to act on. </param>
        /// <param name="propertie"> The propertie. </param>
        /// <param name="value">     The value. </param>
        public static void SetPropertieValue<T>(this T sender, string propertie, object value)
        {
            if (EqualityComparer<T>.Default.Equals(sender, default(T)) || string.IsNullOrEmpty(propertie))
                return;

            try
            {
                if (sender.GetType().GetProperty(propertie) == null)
                    return;

                sender.GetType().GetProperty(propertie).SetValue(sender, Convert.IsDBNull(value) ? null : value, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary> A T extension method that sets a value. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="obj">   The obj to act on. </param>
        /// <param name="name">  The name. </param>
        /// <param name="value"> The value. </param>
        public static void SetValue<T>(this T obj, string name, object value) where T : class
        {
            Dictionary<string, object> properties = ObjectCache.GetOrCreateValue(obj);

            if (properties.ContainsKey(name))
                properties[name] = value;
            else
                properties.Add(name, value);
        }

        /// <summary> Converts a typeBase to a derived. </summary>
        /// <typeparam name="TBase">    Type of the base. </typeparam>
        /// <typeparam name="TDerived"> Type of the derived. </typeparam>
        /// <param name="typeBase"> The type base. </param>
        /// <returns> TypeBase as a TDerived. </returns>
        public static TDerived ToDerived<TBase, TDerived>(TBase typeBase)
            where TDerived : TBase, new()
        {
            TDerived tDerived = new TDerived();
            foreach (PropertyInfo propertyBase in typeof(TBase).GetProperties())
            {
                PropertyInfo propDerived = typeof(TDerived).GetProperty(propertyBase.Name);
                propDerived.SetValue(tDerived, propertyBase.GetValue(typeBase, null), null);
            }
            return tDerived;
        }
        #endregion
    }
}
