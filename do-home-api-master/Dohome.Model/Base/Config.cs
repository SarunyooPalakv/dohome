using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model.Base
{
    public class Config
    {
        public string AuthenticationCode { get; set; }
        public string PathFileXML_Product { get; set; }
        public string PathFileXML_Stock { get; set; }
        public string PathFileXML_Price { get; set; }
        public string FTP_PathFileXML_Product { get; set; }
        public string FTP_PathFileXML_Stock { get; set; }
        public string FTP_PathFileXML_Price { get; set; }
        public string FTP_PathFileXML_Backup { get; set; }
        public string Inbound_TypeFrequency { get; set; }
        public string Inbound_OccursOnceAt { get; set; }
        public string Inbound_OccursEvery { get; set; }
        public string Inbound_OccursEvery_Type { get; set; }
        public string Outbound_TypeFrequency { get; set; }
        public string Outbound_OccursOnceAt { get; set; }
        public string Outbound_OccursEvery { get; set; }
        public string Outbound_OccursEvery_Type { get; set; }
        public string SMTP_Server { get; set; }
        public string SMTP_Port { get; set; }
        public string SMTP_User { get; set; }
        public string SMTP_Password { get; set; }
        public string SMTP_Body { get; set; }
        public string SMTP_Subject { get; set; }
        public string Ftp_Host { get; set; }
        public string Ftp_UserId { get; set; }
        public string Ftp_Password { get; set; }
    }
}
