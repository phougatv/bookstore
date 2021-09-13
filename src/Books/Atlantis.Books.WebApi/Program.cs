namespace Atlantis.Books.WebApi
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;

    public class Program
    {
        /// <summary>
        /// Main method, the entry point of the application.
        /// </summary>
        /// <param name="args">The args <see cref="string[]"/>.</param>
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var configuration = GetConfiguration(environment);
            var loggerFactory = GetLoggerFactory();
            var logger = loggerFactory.CreateLogger<Program>();
            try
            {
                logger.LogInformation("Starting the host...");
                CreateHostBuilder(args, configuration, loggerFactory)
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                logger.LogCritical("Host terminated unexpectedly!");
#if DEBUG
                logger.LogError($"Error message: {ex.Message}");
#endif
            }
            finally
            {
                logger.LogInformation("Disposing LoggerFactory...");
                loggerFactory.Dispose();
            }
        }

        /// <summary>
        /// Creates an instance of the host builder.
        /// </summary>
        /// <param name="args">The args <see cref="string[]"/>.</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(
            string[] args,
            IConfiguration configuration,
            ILoggerFactory loggerFactory)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseStartup<Startup>();
                    webBuilder.UseStartup(context =>
                    {
                        return new Startup(configuration, context.HostingEnvironment, loggerFactory.CreateLogger<Startup>());
                    });
                });
        }

        #region Private Static Methods
        /// <summary>
        /// Gets the logger factory <see cref="ILoggerFactory"/>.
        /// </summary>
        /// <returns></returns>
        private static ILoggerFactory GetLoggerFactory() => LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });

        /// <summary>
        /// Gets the configuration <see cref="IConfiguration"/>.
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        private static IConfiguration GetConfiguration(string environment) => new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
#if DEBUG
                //.AddJsonFile("secrets.json")
#endif
                .Build();
        #endregion Private Static Methods
    }
}
