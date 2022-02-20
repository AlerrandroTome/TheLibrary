using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class RentalModelConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            _ = builder.ToTable("Rental");
            _ = builder.HasKey(k => k.Id);

            builder.AddBaseMapping();

            _ = builder.Property(p => p.ReturnDate).HasColumnType("datetime2").IsRequired();
            _ = builder.Property(p => p.StartDate).HasColumnType("datetime2").IsRequired();

            _ = builder.HasOne(o => o.User)
                       .WithMany()
                       .HasForeignKey(fk => fk.UserId)
                       .OnDelete(DeleteBehavior.Cascade);

            _ = builder.HasMany(m => m.Books)
                       .WithOne(o => o.Rental)
                       .HasForeignKey(fk => fk.RentalId)
                       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
