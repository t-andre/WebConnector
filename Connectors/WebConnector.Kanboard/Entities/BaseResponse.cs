using System;

namespace WebConnector.Kanboard.Entities
{
    public abstract class BaseResponse
    {
        public string jsonrpc { get; set; } = "2.0";
        public int id { get; set; }
    }
}
