using Microsoft.EntityFrameworkCore;

namespace TheLibrary.Infrastructure.Data.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {}
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(LibraryContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
