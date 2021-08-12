using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace PersonalInventoryAPI {
  public class Program {
    public static void Main(string[] args) {
      SetupSerilog();

      try {
        Log.Information("Application starting up...");
        CreateHostBuilder(args).Build().Run();
      } catch (Exception ex) {
        Log.Fatal(ex, "The application failed to start correctly.");
      } finally {
        Log.CloseAndFlush();
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder => {
              webBuilder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
            });

    /// <summary>
    /// Sets up Serilog before dependency injection quite works for the application.
    /// </summary>
    private static void SetupSerilog() {
      var configuration = new ConfigurationBuilder()
        // If this were a production app, it might want to pull data from different appsettings
        // files based on the environment. But because it isn't, it just pulls from the one.
        .AddJsonFile("appsettings.json")
        .Build();

      Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
    }
  }
}
