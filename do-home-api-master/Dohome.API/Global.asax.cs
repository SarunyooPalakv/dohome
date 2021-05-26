using Dohome.API.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Routing;

namespace Dohome.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Exception Log
            GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger), new CustomExceptionLog());
            //TracingLog (Request/Response)
            GlobalConfiguration.Configuration.MessageHandlers.Add(new ApiLogHandler());
        }
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Set("Server", "secret");
            Response.Headers.Remove("X-AspNet-Version"); //alternative to above solution
            Response.Headers.Remove("X-AspNetMvc-Version"); //alternative to above solution
            Response.Headers.Remove("X-Powered-By");
        }
    }
}
