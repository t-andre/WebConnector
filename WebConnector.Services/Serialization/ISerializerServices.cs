// <copyright file="ISerializerServices.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>08.03.2019</date>
// <summary>Declares the ISerializerServices interface</summary>
using System;

namespace WebConnector.Services.Serialization
{
    /// <summary> Interface for serializer services. </summary>
    public interface ISerializerServices
    {
        #region [Methods Implementation]
        /// <summary> Serialize this ISerializerServices to the given stream. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data">           The data. </param>
        /// <param name="serializerType"> Type of the serializer. </param>
        /// <returns> A string. </returns>
        string Serialize<T>(T data, SerializerType serializerType);

        /// <summary> Deserialize this ISerializerServices to the given stream. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data">           The data. </param>
        /// <param name="serializerType"> Type of the serializer. </param>
        /// <returns> A T. </returns>
        T Deserialize<T>(string data, SerializerType serializerType);

        /// <summary> JSON deserialize. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data"> The data. </param>
        /// <returns> A T. </returns>
        T JsonDeserialize<T>(string data);

        /// <summary> JSON serialize. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data"> The data. </param>
        /// <returns> A string. </returns>
        string JsonSerialize<T>(T data);

        /// <summary> XML deserialize. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="xml"> The XML. </param>
        /// <returns> A T. </returns>
        T XmlDeserialize<T>(string xml);

        /// <summary> XML serialize. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="data"> The data. </param>
        /// <returns> A string. </returns>
        string XmlSerialize<T>(T data);
        #endregion
    }
}
