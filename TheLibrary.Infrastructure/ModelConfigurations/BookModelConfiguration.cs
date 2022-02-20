using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class BookModelConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            _ = builder.ToTable("Book");
            _ = builder.HasKey(k => k.Id);

            builder.AddBaseMapping();

            _ = builder.Property(p => p.Title)
                       .IsRequired()
                       .HasColumnType("varchar(100)");

            _ = builder.Property(p => p.Summary)
                       .IsRequired()
                       .HasColumnType("varchar(700)");

            _ = builder.Property(p => p.ReleaseDate)
                       .IsRequired()
                       .HasColumnType("datetime2");

            _ = builder.HasOne(o => o.Category)
                       .WithMany(m => m.Books)
                       .HasForeignKey(fk => fk.CategoryId)
                       .OnDelete(DeleteBehavior.NoAction);

            _ = builder.HasOne(o => o.Author)
                       .WithMany(m => m.Books)
                       .HasForeignKey(fk => fk.AuthorId)
                       .OnDelete(DeleteBehavior.NoAction);

            _ = builder.HasMany(m => m.Rentals)
                       .WithOne(o => o.Book)
                       .HasForeignKey(fk => fk.BookId)
                       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
