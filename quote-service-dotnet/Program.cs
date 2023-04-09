using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Tracing;
using Microsoft.Extensions.DependencyInjection;
namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureServices(services =>
                {
                    // Enables and automatically starts the instrumentation!
                    services.AddOpenTracing(builder =>
                    {
                        builder.ConfigureAspNetCore(options =>
                        {
                            // We don't need any tracing data for our health endpoint.
                            options.Hosting.IgnorePatterns.Add(ctx => ctx.Request.Path == "/health");
                        });
                    });
                })
                //.AddWavefrontMetrics()
                //.AddDistributedTracingAspNetCore()
                .AddAllActuators();
    }
}
