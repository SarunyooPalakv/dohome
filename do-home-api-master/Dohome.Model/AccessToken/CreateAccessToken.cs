using System;
using System.Collections.Generic;

namespace Dohome.Model
{
    public class CreateAccessToken : ResponseParam
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string account_id { get; set; }
        public string country { get; set; }
        public List<country_user_info> country_user_info { get; set; }
        public string account_platform { get; set; }
        public string account { get; set; }
        public string refresh_token { get; set; }
        public string refresh_expires_in { get; set; }
    }

    public class country_user_info
    {
        public string country { get; set; }
        public string seller_id { get; set; }
        public string user_id { get; set; }
        public string short_code { get; set; }
    }
}
