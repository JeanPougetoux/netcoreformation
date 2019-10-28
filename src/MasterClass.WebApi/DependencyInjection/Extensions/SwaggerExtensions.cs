using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterClass.WebApi.DependencyInjection.Extensions
{
    public static class SwaggerExtensions
    {
        private const string VERSION = "v1";
        private const string SWAGGER_DOCNAME = "masterclass.webapi." + VERSION;

        public static IServiceCollection AddMasterClassSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(genOptions
                => genOptions.SwaggerDoc(SWAGGER_DOCNAME,
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "MasterClass WebApi",
                        Version = VERSION
                    }));

            return services;
        }

        public static IApplicationBuilder UseMasterClassSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(uiOptions => uiOptions.SwaggerEndpoint($"/swagger/{SWAGGER_DOCNAME}/swagger.json", "MasterClass WebApi"));

            return app;
        }
    }
}
