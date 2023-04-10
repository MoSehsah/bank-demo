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
using OpenTelemetry.Extensions.Hosting;
using System;
using OpenTelemetry.Metrics;
using OpenTelemetry.Logs;
using Microsoft.Extensions.Logging;

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
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAllActuators();
            var openTelemetryServiceName = Environment.GetEnvironmentVariable("OTEL_SERVICE_NAME");
            var openTelemetryEndpoint =  Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT");
            if (!string.IsNullOrWhiteSpace(openTelemetryEndpoint))
            {
                services.AddOpenTelemetryMetrics((builder) =>
                {
                    builder.AddHttpClientInstrumentation();
                    builder.AddAspNetCoreInstrumentation();
                    builder.AddMeter(openTelemetryServiceName + "-metrics");
                    builder.AddOtlpExporter(options =>
                    {
                        options.Endpoint = new Uri(openTelemetryEndpoint);
                        options.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.HttpProtobuf;
                    });
                });
                services.AddOpenTelemetryTracing((builder) =>
                {
                    builder.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(openTelemetryServiceName));
                    builder.AddHttpClientInstrumentation();
                    builder.AddAspNetCoreInstrumentation();
                    builder.AddSource(openTelemetryServiceName + "-activity-source");
                    builder.AddOtlpExporter(options =>
                    {
                        options.Endpoint = new Uri(openTelemetryEndpoint);
                        options.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.HttpProtobuf;
                    });
                });
                services.AddLogging(loggingBuilder =>
                    {
                        loggingBuilder.AddOpenTelemetry(options =>
                        {
                            options.IncludeFormattedMessage = true;
                            options.IncludeScopes = true;
                            options.ParseStateValues = true;
                            options.AddOtlpExporter(exporterOptions =>
                            {
                                exporterOptions.Endpoint = new Uri(openTelemetryEndpoint);
                                exporterOptions.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.HttpProtobuf;
                            });
                            options.AddConsoleExporter();
                        });
                    });
            }
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
