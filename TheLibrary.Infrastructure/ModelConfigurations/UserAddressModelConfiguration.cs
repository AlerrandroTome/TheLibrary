using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class UserAddressModelConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            _ = builder.ToTable("UserAddress");
            _ = builder.HasKey(k => k.Id);

            builder.AddBaseMapping();

            _ = builder.Property(p => p.IdentificationCode)
                       .HasColumnType("varchar(30)")
                       .IsRequired();

            _ = builder.Property(p => p.Number)
                       .HasColumnType("int")
                       .IsRequired();

            _ = builder.Property(p => p.Address)
                       .HasColumnType("varchar(80)")
                       .IsRequired();

            _ = builder.Property(p => p.Complement)
                       .HasColumnType("varchar(80)");

            _ = builder.HasOne(o => o.User)
                       .WithMany(m => m.Addresses)
                       .HasForeignKey(fk => fk.UserId)
                       .OnDelete(DeleteBehavior.NoAction)
                       .IsRequired();
        }
    }
}
