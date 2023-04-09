using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Tracing;
namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureServices(services =>
                   {
                       services.AddControllers();
                       services.AddOpenTelemetryTracing(builder =>
                       {
                           builder
                               .AddAspNetCoreInstrumentation()
                               .AddHttpClientInstrumentation()
                               .AddEurekaExporter()
                               .AddConsoleExporter()
                               .AddJaegerExporter()
                               .AddAllActuators()
                               .AddOtlpExporter(options =>
                               {
                                   options.Endpoint = new System.Uri(Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT") ?? "http://jaeger-jaeger-collector.monitoring:4317");
                               })
                               .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("quote-service-dotnet"))
                               .Build();
                       });
                   })
                   .ConfigureWebHostDefaults(webBuilder =>
                   {
                       webBuilder.UseStartup<Startup>();
                   });
                //.UseStartup<Startup>()
                //.AddWavefrontMetrics()
                //.AddDistributedTracingAspNetCore()
                //.AddAllActuators();
    }
}
