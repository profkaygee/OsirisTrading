using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;

namespace OsirisTrading_API
{
    /// <summary>
    /// The program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            ConfigureConfiguration(builder);
            IConfiguration build = builder.Build();

            var enableLogging = build.GetValue<bool>("AppSettings:EnableLogging");
            var loggingLevel = build.GetValue<int>("AppSettings:LoggingLevel");

            try
            {
                if (enableLogging)
                {
                    Log.Logger = loggingLevel switch
                    {
                        1 => new LoggerConfiguration().MinimumLevel.Debug()
                            .WriteTo.Console()
                            .WriteTo.File("Logs/Log.log", rollingInterval: RollingInterval.Day)
                            .CreateLogger(),
                        2 => new LoggerConfiguration().MinimumLevel.Information()
                            .WriteTo.Console()
                            .WriteTo.File("Logs/Log.log", rollingInterval: RollingInterval.Day)
                            .CreateLogger(),
                        3 => new LoggerConfiguration().MinimumLevel.Warning()
                            .WriteTo.Console()
                            .WriteTo.File("Logs/Log.log", rollingInterval: RollingInterval.Day)
                            .CreateLogger(),
                        4 => new LoggerConfiguration().MinimumLevel.Debug()
                            .WriteTo.Console()
                            .WriteTo.File("Logs/Log.log", rollingInterval: RollingInterval.Day)
                            .CreateLogger(),
                        _ => throw new ArgumentOutOfRangeException(nameof(loggingLevel), "Thhe passed parameter has not be handled.")
                    };
                }

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// Configures the configuration.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private static void ConfigureConfiguration(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        }

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(LogLevel.Trace);
                    });
                });
    }
}
