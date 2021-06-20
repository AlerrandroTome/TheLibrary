using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class BookCategoryMapping : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.ToTable("BookCategory");
            builder.HasKey(w => w.Id);

            builder.AddBaseMapping();

            builder.Property(w => w.Title)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.HasMany(w => w.Books)
                   .WithOne(w => w.Category)
                   .HasForeignKey(w => w.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
