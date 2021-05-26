using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model.Schedule
{
    public class ResponseData
    {
        public string RES_CODE { get; set; } = "00";
        public string RES_MSG { get; set; } = "ทำรายการสำเร็จ";
        public string RES_DATA { get; set; }
        public string RES_RESULT { get; set; }
        public string RES_MAIL { get; set; }
        public string RES_MAIL_BODY { get; set; }
        public string RES_MAIL_SUBJECT { get; set; }
    }
}
