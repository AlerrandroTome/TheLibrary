using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class AuthorModelConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            _ = builder.ToTable("Author");
            _ = builder.HasKey(w => w.Id);

            builder.AddBaseMapping();

            _ = builder.Property(w => w.Name)
                       .IsRequired()
                       .HasColumnType("varchar(100)");

            _ = builder.HasMany(m => m.Books)
                       .WithOne(o => o.Author)
                       .HasForeignKey(fk => fk.AuthorId)
                       .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
