using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace Dohome.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Handler Custom Exception
            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());

            ////เพิ่มให้รองรับ CROS
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            ////DateTime OutputFormat
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new JsonOutputDateTime());

            // Remove the XML formatter (Json Only)
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
