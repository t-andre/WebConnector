// <copyright file="CollectionExtensions.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the collection extensions class</summary>
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;

namespace TSoft.Library.Core
{
    /// <summary> A collection extensions. </summary>
    public static class CollectionExtensions
    {
        #region [Public methods]
        /// <summary> Enumerates action in this collection. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="source"> The source to act on. </param>
        /// <param name="action"> The action. </param>
        /// <returns> An enumerator that allows foreach to be used to process action in this collection. </returns>
        public static IEnumerable<T> Action<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }

            return source;
        }

        /// <summary> An ICollection&lt;T&gt; extension method that adds a range to 'items'. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="collection"> The collection to act on. </param>
        /// <param name="items">      The items. </param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                collection.Add(item);
            }
        }

        /// <summary> An IEnumerable&lt;TEntity&gt; extension method that converts this CollectionExtensions to a hierarchy. </summary>
        /// <typeparam name="TEntity">   Type of the entity. </typeparam>
        /// <typeparam name="TProperty"> Type of the property. </typeparam>
        /// <param name="allItems">         all items. </param>
        /// <param name="idProperty">       The identifier property. </param>
        /// <param name="parentIdProperty"> The parent identifier property. </param>
        /// <returns> A list of. </returns>
        public static IEnumerable<HierarchyNode<TEntity>> AsHierarchy<TEntity, TProperty>
          (this IEnumerable<TEntity> allItems, Func<TEntity, TProperty> idProperty, Func<TEntity, TProperty> parentIdProperty)
          where TEntity : class
        {
            return CreateHierarchy(allItems, default, idProperty, parentIdProperty, 0);
        }

        /// <summary> An ICollection&lt;T&gt; extension method that compares objects. </summary>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="collection">        The collection to act on. </param>
        /// <param name="other">             Another instance to compare. </param>
        /// <param name="sameOrderRequired"> (Optional) True if same order required. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        public static bool Compare<T>(this ICollection<T> collection, ICollection<T> other, bool sameOrderRequired = false)
        {
            if (!ReferenceEquals(collection, other))
            {
                if (other == null)
                    throw new ArgumentNullException(nameof(other));

                // Not the same number of elements.  No match
                if (collection.Count != other.Count)
                    return false;

                // Require same-order; just defer to existing LINQ match
                if (sameOrderRequired)
                    return collection.SequenceEqual(other);

                // Otherwise allow it to be any order, but require same count of each item type.
                var comparer = EqualityComparer<T>.Default;
                return !(from item in collection
                         let thisItem = item
                         where !other.Contains(item, comparer) || collection.Count(check => comparer.Equals(thisItem, check)) != other.Count(check => comparer.Equals(thisItem, check))
                         select item).Any();
            }

            return true;
        }

        /// <summary> An IEnumerable&lt;T&gt; extension method that searches for the first match. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="collection"> The collection to act on. </param>
        /// <param name="test">       The test. </param>
        /// <returns> An int. </returns>
        public static int IndexOf<T>(this IEnumerable<T> collection, Predicate<T> test)
        {
            int pos = 0;
            foreach (T item in collection)
            {
                if (test(item))
                    return pos;
                pos++;
            }
            return -1;
        }

        /// <summary> An IList&lt;T&gt; extension method that move range. </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when one or more arguments are outside the required range. </exception>
        /// <exception cref="NotSupportedException">       Thrown when the requested operation is not supported. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="collection">    The collection to act on. </param>
        /// <param name="startingIndex"> Zero-based index of the starting. </param>
        /// <param name="count">         Number of. </param>
        /// <param name="destIndex">     Zero-based index of the destination. </param>
        public static void MoveRange<T>(this IList<T> collection, int startingIndex, int count, int destIndex)
        {
            // Simple parameter checking
            if (startingIndex < 0 || startingIndex >= collection.Count)
                throw new ArgumentOutOfRangeException(nameof(startingIndex));
            if (destIndex < 0 || destIndex >= collection.Count)
                throw new ArgumentOutOfRangeException(nameof(destIndex));
            if (startingIndex + count > collection.Count)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            // Ignore if same index or count is zero
            if (startingIndex == destIndex || count == 0)
                return;

            // Make sure we can modify this directly
            if (collection.GetType().IsArray)
                throw new NotSupportedException("Collection is fixed-size and items cannot be efficiently moved.");

            // Go through the collection element-by-element
            var range = Enumerable.Range(0, count);
            if (startingIndex < destIndex)
                range = range.Reverse();

            foreach (var i in range)
            {
                int start = startingIndex + i;
                int dest = destIndex + i;

                T item = collection[start];
                collection.RemoveAt(start);
                collection.Insert(dest, item);
            }
        }

        /// <summary> An IList&lt;T&gt; extension method that swaps. </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when one or more arguments are outside the required range. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="collection">  The collection to act on. </param>
        /// <param name="sourceIndex"> Zero-based index of the source. </param>
        /// <param name="destIndex">   Zero-based index of the destination. </param>
        public static void Swap<T>(this IList<T> collection, int sourceIndex, int destIndex)
        {
            // Simple parameter checking
            if (sourceIndex < 0 || sourceIndex >= collection.Count)
                throw new ArgumentOutOfRangeException(nameof(sourceIndex));
            if (destIndex < 0 || destIndex >= collection.Count)
                throw new ArgumentOutOfRangeException(nameof(destIndex));

            // Ignore if same index
            if (sourceIndex == destIndex)
                return;

            T temp = collection[sourceIndex];
            collection[sourceIndex] = collection[destIndex];
            collection[destIndex] = temp;
        }

        /// <summary> An IEnumerable&lt;T&gt; extension method that converts a collection to a data table. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="collection"> The collection to act on. </param>
        /// <returns> Collection as a DataTable. </returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
        {
            DataTable dt = new DataTable();

            Type t = typeof(T);

            PropertyInfo[] pia = t.GetProperties();

            //Create the columns in the DataTable
            foreach (PropertyInfo pi in pia)
            {
                dt.Columns.Add(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType);
            }

            //Populate the table
            foreach (T item in collection)
            {
                DataRow dr = dt.NewRow();
                dr.BeginEdit();
                foreach (PropertyInfo pi in pia)
                {
                    dr[pi.Name] = pi.GetValue(item, null) ?? DBNull.Value;
                }
                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary> An IEnumerable&lt;T&gt; extension method that converts a collection to a data table. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="collection"> The collection to act on. </param>
        /// <param name="tableName">  Name of the table. </param>
        /// <returns> Collection as a DataTable. </returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection, string tableName)
        {
            DataTable tbl = ToDataTable(collection);
            tbl.TableName = tableName;
            return tbl;
        }

        /// <summary> An IEnumerable&lt;T&gt; extension method that converts an enumerableList to an observable collection. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="enumerableList"> The enumerableList to act on. </param>
        /// <returns> EnumerableList as an ObservableCollection&lt;T&gt; </returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerableList)
        {
            if (enumerableList != null)
            {
                return new ObservableCollection<T>(enumerableList);
            }
            return null;
        }
        #endregion

        #region [Private methods]
        /// <summary> Creates a hierarchy. </summary>
        /// <typeparam name="TEntity">   Type of the entity. </typeparam>
        /// <typeparam name="TProperty"> Type of the property. </typeparam>
        /// <param name="allItems">         all items. </param>
        /// <param name="parentItem">       The parent item. </param>
        /// <param name="idProperty">       The identifier property. </param>
        /// <param name="parentIdProperty"> The parent identifier property. </param>
        /// <param name="depth">            The depth. </param>
        /// <returns> The new hierarchy. </returns>
        private static IEnumerable<HierarchyNode<TEntity>> CreateHierarchy<TEntity, TProperty>
          (IEnumerable<TEntity> allItems, TEntity parentItem,
          Func<TEntity, TProperty> idProperty, Func<TEntity, TProperty> parentIdProperty, int depth) where TEntity : class
        {
            IEnumerable<TEntity> childs;

            if (parentItem == null)
                childs = allItems.Where(i => parentIdProperty(i).Equals(default(TProperty)));
            else
                childs = allItems.Where(i => parentIdProperty(i).Equals(idProperty(parentItem)));

            if (childs.Any())
            {
                depth++;

                foreach (TEntity item in childs)
                {
                    yield return new HierarchyNode<TEntity>()
                    {
                        Entity = item,
                        ChildNodes = CreateHierarchy<TEntity, TProperty>
                           (allItems, item, idProperty, parentIdProperty, depth),
                        Depth = depth
                    };
                }
            }
        }
        #endregion
    }
}
