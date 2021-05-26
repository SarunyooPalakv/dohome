using System;
namespace Dohome.Model
{
    public class AccessToken
    {
        public Int64 id { get; set; }
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string account_id { get; set; }
        public string country { get; set; }
        public string country_user_info { get; set; }
        public string account_platform { get; set; }
        public string account { get; set; }
        public string refresh_token { get; set; }
        public string refresh_expires_in { get; set; }
        public string createdby { get; set; }
        public DateTime createdon { get; set; }
        public DateTime expires_on { get; set; }
        public DateTime refresh_expires_on { get; set; }
        public DateTime datenow { get; set; }
    }
}
    