using WebConnector.Kanboard.Entities;

namespace WebConnector.Kanboard.Api.Procedures
{
    public partial class ApiReference
    {
        public class UserProcedures
        {
            public static BaseRequest GetUser(int id, int user_id)
                => BaseRequest.Create(ApiReferenceConstant.UserProcedures.getUser, id, new { user_id });
            public static BaseRequest GetUserByName(int id, string username)
                => BaseRequest.Create(ApiReferenceConstant.UserProcedures.getUserByName, id, new { username });
        }
    }

}
