using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Infrastructure.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(w => w.Id);

            builder.AddBaseMapping();

            builder.Property(w => w.Login)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(w => w.Password)
                   .HasColumnType("varchar(8)")
                   .IsRequired();

            builder.Property(w => w.FirstName)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(w => w.LastName)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(w => w.Identification)
                   .HasColumnType("varchar(30)")
                   .IsRequired();

            builder.Property(w => w.BirthDate)
                   .HasColumnType("datetime2")
                   .IsRequired();

            builder.HasMany(w => w.Addresses)
                   .WithOne(w => w.User)
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
