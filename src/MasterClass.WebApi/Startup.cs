using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.DependencyInjection.Extensions;
using CoreLibrary;
using MasterClass.WebApi.DependencyInjection.Extensions;
using MasterClass.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repository.DependencyInjection.Extensions;
using Service.DependencyInjection.Extensions;

namespace MasterClass.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMasterClassSwagger();

            services.AddSingleton<IApplicationRequestContext, ApplicationRequestContext>();
            services.Configure<DiagnosticOptions>(Configuration.GetSection("Diagnostic"));

            services.ConfigureMock(Configuration);

            services.AddRepository();
            services.AddBusiness();
            services.AddService();
            services.AddMasterClassAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMasterClassSwaggerUI();

            app.UseAuthentication();

            app.UseMiddleware<TrackMachineMiddleware>();
            app.UseMiddleware<TrackRequestContextMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
