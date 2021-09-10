namespace Atlantis.Books.Shared.Extensions
{
    using Atlantis.Books.Business;
    using Atlantis.Books.Persistence;
    using Atlantis.Books.Persistence.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class BooksExtension
    {
        public static IServiceCollection AddAtlantisCore(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAtlantisAutomapper()
                .AddAtlantisMsSql(configuration)
                .AddAtlantisServices();
            return services;
        }


        internal static IServiceCollection AddAtlantisMsSql(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AtlantisDbContext>(optionsBuilder =>
            {
                // Install-Package Microsoft.EntityFrameworkCore.SqlServer for this extension method
                optionsBuilder.UseSqlServer(configuration.GetSection("Atlantis:ConnectionString").Value);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }


        internal static IServiceCollection AddAtlantisServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
