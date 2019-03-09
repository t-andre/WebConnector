using System;
using System.Collections.Generic;
using System.Text;

namespace WebConnector.Kanboard.Entities
{
    public class BaseRequest
    {
        public BaseRequest()
        {

        }

        public BaseRequest(string method, int id, object parameters = null)
        {
            this.method = method;
            this.id = id;
            this.@params = parameters;
        }

        public string jsonrpc { get; set; } = "2.0";
        public string method { get; set; }
        public int id { get; set; }
        public dynamic @params { get; set; }

        public static BaseRequest Create(string method, int id, dynamic parameters = null)
        {
            return new BaseRequest
            {
                method = method,
                id = id,
                @params = parameters
            };
        }
    }
}
