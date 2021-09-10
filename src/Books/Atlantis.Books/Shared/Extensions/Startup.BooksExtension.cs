namespace Atlantis.Books.Shared.Extensions
{
    using Atlantis.Books.Business;
    using Atlantis.Books.Persistence;
    using Atlantis.Books.Persistence.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public static class BooksExtension
    {
        public static IServiceCollection AddAtlantis(this IServiceCollection services, IConfiguration configuration, ILogger logger)
        {
            services
                .AddAtlantisAutomapper(logger)
                .AddAtlantisMsSql(configuration, logger)
                .AddAtlantisBusinessServices(logger);
            return services;
        }

        internal static IServiceCollection AddAtlantisMsSql(this IServiceCollection services, IConfiguration configuration, ILogger logger)
        {
            logger.LogInformation("Atlantis MsSql: Configuring services...");
            services.AddDbContext<AtlantisDbContext>(optionsBuilder =>
            {
                // Install-Package Microsoft.EntityFrameworkCore.SqlServer for this extension method
                optionsBuilder.UseSqlServer(configuration.GetSection("Atlantis:ConnectionString").Value);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookRepository>();
            logger.LogInformation("Atlantis MsSql: Successfully configured services.");

            return services;
        }

        internal static IServiceCollection AddAtlantisBusinessServices(this IServiceCollection services, ILogger logger)
        {
            logger.LogInformation("Atlantis Services: Configuring services...");
            services.AddScoped<IBookService, BookService>();
            logger.LogInformation("Atlantis Services: Successfully configured services.");
            return services;
        }
    }
}
