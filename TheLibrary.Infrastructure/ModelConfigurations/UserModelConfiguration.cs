using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class UserModelConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            _ = builder.ToTable("User");
            _ = builder.HasKey(k => k.Id);

            builder.AddBaseMapping();

            _ = builder.Property(p => p.Login)
                       .HasColumnType("varchar(100)")
                       .IsRequired();

            _ = builder.Property(p => p.Password)
                       .HasColumnType("varchar(8)")
                       .IsRequired();

            _ = builder.Property(p => p.FirstName)
                       .HasColumnType("varchar(50)")
                       .IsRequired();

            _ = builder.Property(p => p.LastName)
                       .HasColumnType("varchar(100)")
                       .IsRequired();

            _ = builder.Property(p => p.Identification)
                       .HasColumnType("varchar(30)")
                       .IsRequired();

            _ = builder.Property(p => p.BirthDate)
                       .HasColumnType("datetime2")
                       .IsRequired();

            _ = builder.HasMany(m => m.Addresses)
                       .WithOne(o => o.User)
                       .HasForeignKey(fk => fk.UserId)
                       .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
