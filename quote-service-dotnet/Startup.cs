using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Steeltoe.Discovery.Client;
using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Tracing;
using Newtonsoft.Json;
namespace WebApi
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
            services.AddCors();
            services.AddDiscoveryClient(Configuration);
            services.AddControllers().AddNewtonsoftJson();
            services.AddAllActuators(Configuration);
            services.AddDistributedTracingAspNetCore();
            services.AddMetricsActuatorServices(Configuration);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapAllActuators();
            });
        }
    }
}
