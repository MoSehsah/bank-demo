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
                //.AddWavefrontMetrics()
                //.AddDistributedTracingAspNetCore()
                .AddAllActuators();
    }
}
