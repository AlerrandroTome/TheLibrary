using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.ModelConfigurations
{
    public class BookRentalModelConfiguration : IEntityTypeConfiguration<BookRental>
    {
        public void Configure(EntityTypeBuilder<BookRental> builder)
        {
            _ = builder.ToTable("BookRental");
            _ = builder.HasKey(k => k.Id);

            _ = builder.HasOne(o => o.Rental)
                       .WithMany(m => m.Books)
                       .HasForeignKey(fk => fk.RentalId)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = builder.HasOne(o => o.Book)
                       .WithMany(m => m.Rentals)
                       .HasForeignKey(fk => fk.BookId)
                       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
