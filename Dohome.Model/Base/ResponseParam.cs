using System;
namespace Dohome.Model
{
    public class ResponseParam
    {
        public string code { get; set; } = "0";
        public string message { get; set; } = "Success";
        public string type { get; set; }
        public string request_id { get; set; }
    }
}
