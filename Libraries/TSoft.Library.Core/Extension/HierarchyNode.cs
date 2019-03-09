// <copyright file="HierarchyNode.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the hierarchy node class</summary>
using System;
using System.Linq;
using System.Collections.Generic;

namespace TSoft.Library.Core
{
    /// <summary> A hierarchy node. </summary>
    /// <typeparam name="T"> Generic type parameter. </typeparam>
    public class HierarchyNode<T> where T : class
    {
        #region [Public properties]
        /// <summary> Gets or sets the child nodes. </summary>
        /// <value> The child nodes. </value>
        public IEnumerable<HierarchyNode<T>> ChildNodes { get; set; }

        /// <summary> Gets or sets the depth. </summary>
        /// <value> The depth. </value>
        public int Depth { get; set; }

        /// <summary> Gets or sets the entity. </summary>
        /// <value> The entity. </value>
        public T Entity { get; set; }
        #endregion
    }
}
