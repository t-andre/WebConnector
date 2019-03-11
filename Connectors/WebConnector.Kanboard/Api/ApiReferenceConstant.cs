using System;

namespace WebConnector.Kanboard.Api
{
    public static class ApiReferenceConstant
    {
        #region [Nested Class]
        public class ApplicationProcedures
        {
            #region [Constants]
            public const string getApplicationRoles = "getApplicationRoles";

            public const string getColorList = "getColorList";

            public const string getDefaultTaskColor = "getDefaultTaskColor";

            public const string getDefaultTaskColors = "getDefaultTaskColors";

            public const string getProjectRoles = "getProjectRoles";

            public const string getTimezone = "getTimezone";

            public const string getVersion = "getVersion";
            #endregion
        }

        public class SpecificProcedures
        {
            #region [Constants]
            public const string createMyPrivateProject = "createMyPrivateProject";

            public const string getMe = "getMe";

            public const string getMyActivityStream = "getMyActivityStream";

            public const string getMyDashboard = "getMyDashboard";

            public const string getMyOverdueTasks = "getMyOverdueTasks";

            public const string getMyProjects = "getMyProjects";

            public const string getMyProjectsList = "getMyProjectsList";
            #endregion
        }

        public class UserProcedures
        {
            #region [Constants]
            public const string createLdapUser = "createLdapUser";

            public const string createUser = "createUser";

            public const string disableUser = "disableUser";

            public const string enableUser = "enableUser";

            public const string getAllUsers = "getAllUsers";

            public const string getUser = "getUser";

            public const string getUserByName = "getUserByName";

            public const string isActiveUser = "isActiveUser";

            public const string removeUser = "removeUser";

            public const string updateUser = "updateUser";
            #endregion
        }
        #endregion
    }
}
