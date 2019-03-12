// <copyright file="UserProcedures.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>09.03.2019</date>
// <summary>Implements the user procedures class</summary>
using WebConnector.Kanboard.Entities;

namespace WebConnector.Kanboard.Api.Procedures
{
    /// <content> An API reference. </content>
    public partial class ApiReference
    {
        #region [Nested Class]
        /// <summary> A user procedures. </summary>
        public class UserProcedures
        {
            #region [Public methods]
            /// <summary> Gets a user. </summary>
            /// <param name="id">      The identifier. </param>
            /// <param name="user_id"> Identifier for the user. </param>
            /// <returns> The user. </returns>
            public static Request GetUser(int id, int user_id)
                => Request.Create(ApiReferenceConstant.UserProcedures.GetUser, id, new { user_id });

            /// <summary> Gets user by name. </summary>
            /// <param name="id">       The identifier. </param>
            /// <param name="username"> The username. </param>
            /// <returns> The user by name. </returns>
            public static Request GetUserByName(int id, string username)
                => Request.Create(ApiReferenceConstant.UserProcedures.GetUserByName, id, new { username });
            #endregion
        }
        #endregion
    }
}
