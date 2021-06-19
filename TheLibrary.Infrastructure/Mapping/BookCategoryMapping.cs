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

            builder.Property(w => w.Title).IsRequired().HasColumnType("varchar(100)");
            builder.Property(w => w.InclusionDate).IsRequired().HasColumnType("datetime2");
            builder.Property(w => w.Active).IsRequired().HasColumnType("bit");

            builder.Property(w => w.LastChangeDate).HasColumnType("datetime2");
        }
    }
}
