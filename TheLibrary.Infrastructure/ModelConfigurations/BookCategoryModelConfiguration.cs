using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class BookCategoryModelConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            _ = builder.ToTable("BookCategory");
            _ = builder.HasKey(k => k.Id);

            builder.AddBaseMapping();

            _ = builder.Property(p => p.Title)
                       .IsRequired()
                       .HasColumnType("varchar(100)");

            _ = builder.HasMany(m => m.Books)
                       .WithOne(o => o.Category)
                       .HasForeignKey(fk => fk.CategoryId)
                       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
