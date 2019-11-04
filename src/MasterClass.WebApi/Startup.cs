

using MasterClass.Business.DependencyInjection.Extensions;
using MasterClass.Core;
using MasterClass.Repository.DependencyInjection.Extensions;
using MasterClass.Service.DependencyInjection.Extensions;
using MasterClass.WebApi.DependencyInjection.Extensions;
using MasterClass.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MasterClass.WebApi
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DiagnosticOptions>(Configuration.GetSection("Diagnostic"));
            //services.AddScoped<IApplicationRequestContext, ApplicationRequestContext>();
            services.AddSingleton<IApplicationRequestContext, ApplicationRequestContext>();
            //services.AddTransient<IApplicationRequestContext, ApplicationRequestContext>();
            services.AddControllers();
            //services.AddMasterClassSwagger();
            services.ConfigureMock(Configuration);

            services.AddRepository();
            services.AddBusiness();
            services.AddService();
            
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

            app.UseMiddleware<TrackMachineMiddleware>();
            app.UseMiddleware<TrackRequestContextMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
