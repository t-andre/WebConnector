// <copyright file="SerializerType.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>08.03.2019</date>
// <summary>Implements the serializer type class</summary>
using System;
using System.Collections.Generic;
using System.Text;

namespace WebConnector.Services.Serialization
{
    /// <summary> Values that represent serializer types. </summary>
    public enum SerializerType
    {
        /// <summary> An enum constant representing the none option. </summary>
        None = 0,

        /// <summary> An enum constant representing the XML option. </summary>
        Xml = 1,

        /// <summary> An enum constant representing the JSON option. </summary>
        Json = 2
    }
}
