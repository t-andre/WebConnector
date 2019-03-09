using System;

namespace WebConnector.Kanboard.Api
{
    public static class ApiReferenceConstant
    {
        public class ApplicationProcedures
        {
            public const string getVersion = "getVersion";
            public const string getTimezone = "getTimezone";
            public const string getDefaultTaskColors = "getDefaultTaskColors";
            public const string getDefaultTaskColor = "getDefaultTaskColor";
            public const string getColorList = "getColorList";
            public const string getApplicationRoles = "getApplicationRoles";
            public const string getProjectRoles = "getProjectRoles";
        }

        public class SpecificProcedures
        {
            public const string getMe = "getMe";
            public const string getMyDashboard = "getMyDashboard";
            public const string getMyActivityStream = "getMyActivityStream";
            public const string getMyProjectsList = "getMyProjectsList";
            public const string getMyOverdueTasks = "getMyOverdueTasks";
            public const string getMyProjects = "getMyProjects";
            public const string createMyPrivateProject = "createMyPrivateProject";
        }
        public class UserProcedures
        {
            public const string createUser = "createUser";
            public const string createLdapUser = "createLdapUser";
            public const string getUser = "getUser";
            public const string getUserByName = "getUserByName";
            public const string getAllUsers = "getAllUsers";
            public const string updateUser = "updateUser";
            public const string removeUser = "removeUser";
            public const string disableUser = "disableUser";
            public const string enableUser = "enableUser";
            public const string isActiveUser = "isActiveUser";
        }
    }
}
