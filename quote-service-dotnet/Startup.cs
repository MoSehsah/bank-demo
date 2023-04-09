using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Steeltoe.Discovery.Client;
using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Tracing;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter;
using System;

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
            //services.AddOpenTracing();
            services.AddOpenTelemetryTracing(builder =>
            {
                builder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEurekaExporter()
                    .AddConsoleExporter()
                    .AddJaegerExporter()
                    .AddOtlpExporter()
                    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("YourServiceName"));
            });
            services.AddOpenTelemetryMetrics(builder =>
            {
                builder
                    .AddAspNetCoreInstrumentation()
                    .AddEurekaExporter()
                    .AddConsoleExporter()
                    .AddJaegerExporter()
                    .AddOtlpExporter()
                    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("YourServiceName"));
            });
            services.AddDiscoveryClient(Configuration);
            services.AddControllers().AddNewtonsoftJson(options => { 
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
                options.SerializerSettings.DateFormatString = "ddd MMM dd HH:mm:ss UTCZ yyyy";

                });
            services.AddAllActuators(Configuration);
            services.AddPrometheusActuatorServices(Configuration);
            services.AddDistributedTracingAspNetCore();
            //services.AddDistributedTracing(Configuration, builder =>
            //{
            //  builder.SetResource(new Resource(new Dictionary<string, object>
            //    {
            //        ["application"] = Configuration["management:tracing:exporter:zipkin:applicationName"],
            //        ["cluster"] = Configuration["management:tracing:exporter:zipkin:cluster"],
            //    })).UseZipkinWithTraceOptions(services);
            //});
            services.AddMetricsActuatorServices(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "quote-service-dotnet", Version = "v1" });
            });

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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapAllActuators(null);
            });
        }
    }
}
