using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace Dohome.API
{
    public static class AppConfig
    {
        public static string LocalIP = GetLocalIPAddress();
        public static string Username = System.Configuration.ConfigurationManager.AppSettings["Username"];
        public static string Password = System.Configuration.ConfigurationManager.AppSettings["Password"];
        public static string UUID = System.Configuration.ConfigurationManager.AppSettings["AppUUID"];
        public static int RequestTimeout = int.Parse(System.Configuration.ConfigurationManager.AppSettings["RequestTimeout"]);
        public static string CHANNEL = System.Configuration.ConfigurationManager.AppSettings["ApiChannel"];
        public static string KeyMD5 = System.Configuration.ConfigurationManager.AppSettings["KeyMD5"];

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}