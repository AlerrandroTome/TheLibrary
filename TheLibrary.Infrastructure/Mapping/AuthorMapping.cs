using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(w => w.Id);

            builder.AddBaseMapping();

            builder.Property(w => w.Name)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.HasMany(w => w.Books)
                   .WithOne(w => w.Author)
                   .HasForeignKey(w => w.AuthorId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
