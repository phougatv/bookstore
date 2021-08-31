namespace Atlantis.Books
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class BookExtension
    {
        public static IServiceCollection AddBookComponent(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
            {
                // Install-Package Microsoft.EntityFrameworkCore.SqlServer for this extension method
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Atlantis.Books;Integrated Security=SSPI;Trusted_Connection=True");
            });

            services.AddScoped<BookService>();
            services.AddScoped<BookRepository>();

            return services;
        }
    }
}
