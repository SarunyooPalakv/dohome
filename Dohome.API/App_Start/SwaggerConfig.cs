using System.Web.Http;
using WebActivatorEx;
using Dohome.API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Dohome.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
              .EnableSwagger(c => c.SingleApiVersion("v1", "Cttwms API"))
              .EnableSwaggerUi();
        }
    }
}
