using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(w => w.Id);

            builder.AddBaseMapping();

            builder.Property(w => w.Title)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(w => w.Resume)
                   .IsRequired()
                   .HasColumnType("varchar(700)");

            builder.Property(w => w.ReleaseDate)
                   .IsRequired()
                   .HasColumnType("datetime2");

            builder.HasOne(w => w.Category)
                   .WithMany(w => w.Books)
                   .HasForeignKey(w => w.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(w => w.Author)
                   .WithMany(w => w.Books)
                   .HasForeignKey(w => w.AuthorId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
