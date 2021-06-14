using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace PROJECT_NAME.Api
{
    public class Program
    {
        private static string _environmentName;

        public static void Main(string[] args)
        {
            _environmentName = (string)Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();

            Console.WriteLine($"Environment name: {_environmentName}");

            var webHost = CreateHostBuilder(args).Build();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            ConfigureLogger(configuration);

            try
            {
                Log.Information("Starting web host");
                webHost.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        private static void ConfigureLogger(IConfigurationRoot configuration)
        {
            switch (configuration["LoggerProvider"]?.ToLowerInvariant())
            {
                case "Serilog":
                default:
                    SerilogConfiguration(configuration);
                    break;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, config) =>
            {
                config.ClearProviders();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

        private static void SerilogConfiguration(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Seq(configuration["Serilog:BaseUrl"])
                .CreateLogger();

            Log.Information("Logger has been configured using Serilog provider.");
        }
    }
}
