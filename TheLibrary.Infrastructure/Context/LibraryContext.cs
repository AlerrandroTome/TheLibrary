using Microsoft.EntityFrameworkCore;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Data.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        { }

        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(LibraryContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
