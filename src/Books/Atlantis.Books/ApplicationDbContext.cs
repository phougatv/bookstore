using Microsoft.EntityFrameworkCore;

namespace Atlantis.Books
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        /// <summary>
        /// First removes pluralizing table name convention, then pass the model builder to the base method.
        /// </summary>
        /// <param name="modelBuilder">The model builder <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach (var entity in entityTypes)
            {
                // Remove pluralizing table name convention (Install package - Microsoft.EntityFrameworkCore.Relational).
                entity.SetTableName(entity.DisplayName());
            }

            base.OnModelCreating(modelBuilder);
        }

        internal DbSet<Book> Books { get; set; }
    }
}
