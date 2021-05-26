using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Log
{
    public class TRACE_LOG_WEB_API_ERROR
    {
        public long LOG_ID { get; set; }
        public string LOG_LEVEL { get; set; }
        public string SERVICE_NAME { get; set; }
        public string SERVICE_TYPE { get; set; }
        public string ERROR_MESSAGE { get; set; }
        public string SERVER_IP { get; set; }
        public string CLIENT_IP { get; set; }
        public DateTime LOG_DATE { get; set; }
    }
}
