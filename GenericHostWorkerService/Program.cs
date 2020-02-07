using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericHostWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1
            //To write logs in the Program class of an ASP.NET Core app, get an ILogger instance from DI after building the host:
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Begin");

            host.Run();
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
