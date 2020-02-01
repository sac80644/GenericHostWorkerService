using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenericHostWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();
                services.Configure<AppSettings>(hostContext.Configuration.GetSection("AppSettings"));
                services.AddHostedService<LifetimeEventsHostedService>();
                services.AddHostedService<Worker>();
            });
    }
}
