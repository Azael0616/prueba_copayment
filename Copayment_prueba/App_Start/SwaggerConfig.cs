using System.Web.Http;
using WebActivatorEx;
using Copayment_prueba;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Copayment_prueba
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Prueba Copayment API");
                })
                .EnableSwaggerUi();
        }
    }
}
