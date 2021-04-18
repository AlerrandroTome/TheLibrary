using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Domain.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class UserAddressMapping : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddress");
            builder.HasKey(w => w.Id);

            builder.Property(w => w.IdentificationCode)
                   .HasColumnType("varchar(30)")
                   .IsRequired();

            builder.Property(w => w.InclusionDate)
                   .HasColumnType("datetime2")
                   .IsRequired();

            builder.Property(w => w.Number)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(w => w.Active)
                   .HasColumnType("bit")
                   .IsRequired();

            builder.Property(w => w.Address)
                   .HasColumnType("varchar(80)")
                   .IsRequired();

            builder.Property(w => w.Complement)
                   .HasColumnType("varchar(80)");
            
            builder.Property(w => w.LastChangeDate)
                .HasColumnType("datetime2");

            builder.HasOne(w => w.User)
                   .WithMany(w => w.Addresses)
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}
