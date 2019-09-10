using EShop.DataAccess;
using EShop.WebUI.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EShop.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build()
                                      .InitializeDatabase<ApplicationDbContext>()
                                      .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .ConfigureLogging(config =>
                          {
                              config.ClearProviders();
                          })
                          .UseSerilog((hostingContext, loggerConfiguration) =>
                          {
                              loggerConfiguration
                                  .ReadFrom.Configuration(hostingContext.Configuration);
                          })
                          .UseStartup<Startup>();
        }
    }
}