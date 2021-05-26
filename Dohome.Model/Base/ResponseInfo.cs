using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model
{
    public class ResponseInfo<T> where T: class
    {
        public string code { get; set; } = "0";
        public string message { get; set; } = "Success";
        public T data { get; set; }
        public string type { get; set; }
        public string request_id { get; set; }
        public List<details> detail { get; set; }
    }

    public class details
    {
        public string field { get; set; }
        public string message { get; set; }
    }
}
