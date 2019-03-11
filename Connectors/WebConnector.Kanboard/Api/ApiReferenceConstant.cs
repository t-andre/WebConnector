using System;

namespace WebConnector.Kanboard.Api
{
    public static class ApiReferenceConstant
    {
        #region [Nested Class]
        public static class ApplicationProcedures
        {
            #region [Constants]
            public const string GetApplicationRoles = "getApplicationRoles";

            public const string GetColorList = "getColorList";

            public const string GetDefaultTaskColor = "getDefaultTaskColor";

            public const string GetDefaultTaskColors = "getDefaultTaskColors";

            public const string GetProjectRoles = "getProjectRoles";

            public const string GetTimezone = "getTimezone";

            public const string GetVersion = "getVersion";
            #endregion
        }

        public static class SpecificProcedures
        {
            #region [Constants]
            public const string CreateMyPrivateProject = "createMyPrivateProject";

            public const string GetMe = "getMe";

            public const string GetMyActivityStream = "getMyActivityStream";

            public const string GetMyDashboard = "getMyDashboard";

            public const string GetMyOverdueTasks = "getMyOverdueTasks";

            public const string GetMyProjects = "getMyProjects";

            public const string GetMyProjectsList = "getMyProjectsList";
            #endregion
        }

        public static class UserProcedures
        {
            #region [Constants]
            public const string CreateLdapUser = "createLdapUser";

            public const string CreateUser = "createUser";

            public const string DisableUser = "disableUser";

            public const string EnableUser = "enableUser";

            public const string GetAllUsers = "getAllUsers";

            public const string GetUser = "getUser";

            public const string GetUserByName = "getUserByName";

            public const string IsActiveUser = "isActiveUser";

            public const string RemoveUser = "removeUser";

            public const string UpdateUser = "updateUser";
            #endregion
        }

        public static class GroupProcedures
        {
            #region [Constants]
            public const string CreateGroup = "createGroup";

            public const string UpdateGroup = "updateGroup";

            public const string RemoveGroup = "removeGroup";

            public const string GetGroup = "getGroup";

            public const string GetAllGroups = "getAllGroups";

            #endregion
        }

        public static class GroupMemberProcedures
        {
            #region [Constants]
            public const string GetMemberGroups = "getMemberGroups";

            public const string GetGroupMembers = "getGroupMembers";

            public const string AddGroupMember = "addGroupMember";

            public const string RemoveGroupMember = "removeGroupMember";

            public const string IsGroupMember = "isGroupMember";

            #endregion
        }

        public static class ProjectProcedures
        {
            #region [Constants]
            public const string CreateProject = "createProject";

            public const string GetProjectById = "getProjectById";

            public const string GetProjectByName = "getProjectByName";

            public const string GetProjectByIdentifier = "getProjectByIdentifier";

            public const string GetAllProjects = "getAllProjects";

            public const string UpdateProject = "updateProject";

            public const string RemoveProject = "removeProject";

            public const string EnableProject = "enableProject";

            public const string DisableProject = "disableProject";

            public const string EnableProjectPublicAccess = "enableProjectPublicAccess";

            public const string DisableProjectPublicAccess = "disableProjectPublicAccess";

            public const string GetProjectActivity = "getProjectActivity";

            public const string GetProjectActivities = "getProjectActivities";
            #endregion
        }

        public static class ProjectPermissionProcedures
        {
            #region [Constants]
            public const string GetProjectUsers = "getProjectUsers";

            public const string GetAssignableUsers = "getAssignableUsers";

            public const string AddProjectUser = "addProjectUser";

            public const string AddProjectGroup = "addProjectGroup";

            public const string RemoveProjectUser = "removeProjectUser";

            public const string RemoveProjectGroup = "removeProjectGroup";

            public const string ChangeProjectUserRole = "changeProjectUserRole";

            public const string GetProjectUserRole = "getProjectUserRole";
            #endregion
        }

        public static class ProjectMetadataProcedures
        {
            #region [Constants]
            public const string GetProjectMetadata = "getProjectMetadata";

            public const string GetProjectMetadataByName = "getProjectMetadataByName";

            public const string SaveProjectMetadata = "saveProjectMetadata";

            public const string RemoveProjectMetadata = "removeProjectMetadata";

            #endregion
        }

        public static class BoardProcedures
        {
            #region [Constants]
            public const string GetBoard = "getBoard";
            #endregion
        }

        public static class ColumnProcedures
        {
            #region [Constants]
            public const string GetColumns = "getColumns";

            public const string GetColumn = "getColumn";

            public const string ChangeColumnPosition = "changeColumnPosition";

            public const string UpdateColumn = "updateColumn";

            public const string AddColumn = "addColumn";

            public const string RemoveColumn = "removeColumn";

            #endregion
        }

        public static class SwimlaneProcedures
        {
            #region [Constants]
            public const string GetActiveSwimlanes = "getActiveSwimlanes";

            public const string GetAllSwimlanes = "getAllSwimlanes";

            public const string GetSwimlane = "getSwimlane";

            public const string GetSwimlaneById = "getSwimlaneById";

            public const string GetSwimlaneByName = "getSwimlaneByName";

            public const string ChangeSwimlanePosition = "changeSwimlanePosition";

            public const string UpdateSwimlane = "updateSwimlane";

            public const string AddSwimlane = "addSwimlane";

            public const string RemoveSwimlane = "removeSwimlane";

            public const string DisableSwimlane = "disableSwimlane";

            public const string EnableSwimlane = "enableSwimlane";
            #endregion
        }

        public static class TaskProcedures
        {
            #region [Constants]
            public const string CreateTask = "createTask";

            public const string GetTask = "getTask";

            public const string GetTaskByReference = "getTaskByReference";

            public const string GetAllTasks = "getAllTasks";

            public const string GetOverdueTasks = "getOverdueTasks";

            public const string GetOverdueTasksByProject = "getOverdueTasksByProject";

            public const string UpdateTask = "updateTask";

            public const string OpenTask = "openTask";

            public const string CloseTask = "closeTask";

            public const string RemoveTask = "removeTask";

            public const string MoveTaskPosition = "moveTaskPosition";

            public const string MoveTaskToProject = "moveTaskToProject";

            public const string DuplicateTaskToProject = "duplicateTaskToProject";

            public const string SearchTasks = "searchTasks";
            #endregion
        }

        public static class TaskMetadataProcedures
        {
            #region [Constants]
            public const string GetTaskMetadata = "getTaskMetadata";

            public const string GetTaskMetadataByName = "getTaskMetadataByName";

            public const string SaveTaskMetadata = "saveTaskMetadata";

            public const string RemoveTaskMetadata = "removeTaskMetadata";

            #endregion
        }

        public static class SubtaskProcedures
        {
            #region [Constants]
            public const string CreateSubtask = "createSubtask";

            public const string GetSubtask = "getSubtask";

            public const string GetAllSubtasks = "getAllSubtasks";

            public const string UpdateSubtask = "updateSubtask";

            public const string RemoveSubtask = "removeSubtask";
            #endregion
        }

        public static class SubtaskTimeTrackingProcedures
        {
            #region [Constants]
            public const string HasSubtaskTimer = "hasSubtaskTimer";

            public const string SetSubtaskStartTime = "setSubtaskStartTime";

            public const string SetSubtaskEndTime = "setSubtaskEndTime";

            public const string GetSubtaskTimeSpent = "getSubtaskTimeSpent";
            #endregion
        }

        public static class CommentProcedures
        {
            #region [Constants]
            public const string CreateComment = "createComment";

            public const string GetComment = "getComment";

            public const string GetAllComments = "getAllComments";

            public const string UpdateComment = "updateComment";

            public const string RemoveComment = "removeComment";
            #endregion
        }

        public static class AutomaticActionsProcedures
        {
            #region [Constants]
            public const string GetAvailableActions = "getAvailableActions";

            public const string GetAvailableActionEvents = "getAvailableActionEvents";

            public const string GetCompatibleActionEvents = "getCompatibleActionEvents";

            public const string GetActions = "getActions";

            public const string CreateAction = "createAction";

            public const string RemoveAction = "removeAction";

            #endregion
        }

        public static class CategoryProcedures
        {
            #region [Constants]
            public const string CreateCategory = "createCategory";

            public const string GetCategory = "getCategory";

            public const string GetAllCategories = "getAllCategories";

            public const string UpdateCategory = "updateCategory";

            public const string RemoveCategory = "removeCategory";
            #endregion
        }

        public static class ExternalTaskLinkProcedures
        {
            #region [Constants]
            public const string GetExternalTaskLinkTypes = "getExternalTaskLinkTypes";

            public const string GetExternalTaskLinkProviderDependencies = "getExternalTaskLinkProviderDependencies";

            public const string CreateExternalTaskLink = "createExternalTaskLink";

            public const string UpdateExternalTaskLink = "updateExternalTaskLink";

            public const string GetExternalTaskLinkById = "getExternalTaskLinkById";

            public const string GetAllExternalTaskLinks = "getAllExternalTaskLinks";

            public const string RemoveExternalTaskLink = "removeExternalTaskLink";

            #endregion
        }

        public static class InternalTaskLinkProcedures
        {
            #region [Constants]
            public const string CreateTaskLink = "createTaskLink";

            public const string UpdateTaskLink = "updateTaskLink";

            public const string GetTaskLinkById = "getTaskLinkById";

            public const string GetAllTaskLinks = "getAllTaskLinks";

            public const string RemoveTaskLink = "removeTaskLink";
            #endregion
        }

        public static class LinksProcedures
        {
            #region [Constants]
            public const string GetAllLinks = "getAllLinks";

            public const string GetOppositeLinkId = "getOppositeLinkId";

            public const string GetLinkByLabel = "getLinkByLabel";

            public const string GetLinkById = "getLinkById";

            public const string CreateLink = "createLink";

            public const string UpdateLink = "updateLink";

            public const string RemoveLink = "removeLink";

            #endregion
        }

        public static class ProjectFileProcedures
        {
            #region [Constants]
            public const string CreateProjectFile = "createProjectFile";

            public const string GetAllProjectFiles = "getAllProjectFiles";

            public const string GetProjectFile = "getProjectFile";

            public const string DownloadProjectFile = "downloadProjectFile";

            public const string RemoveProjectFile = "removeProjectFile";

            public const string RemoveAllProjectFiles = "removeAllProjectFiles";

            #endregion
        }

        public static class TaskFileProcedures
        {
            #region [Constants]
            public const string CreateTaskFile = "createTaskFile";

            public const string GetAllTaskFiles = "getAllTaskFiles";

            public const string GetTaskFile = "getTaskFile";

            public const string DownloadTaskFile = "downloadTaskFile";

            public const string RemoveTaskFile = "removeTaskFile";

            public const string RemoveAllTaskFiles = "removeAllTaskFiles";
            #endregion
        }

        public static class TagsProcedures
        {
            #region [Constants]
            public const string GetAllTags = "getAllTags";

            public const string GetTagsByProject = "getTagsByProject";

            public const string CreateTag = "createTag";

            public const string UpdateTag = "updateTag";

            public const string RemoveTag = "removeTag";

            public const string setTaskTags = "setTaskTags";

            public const string GetTaskTags = "getTaskTags";
            #endregion
        }
        #endregion
    }
}
