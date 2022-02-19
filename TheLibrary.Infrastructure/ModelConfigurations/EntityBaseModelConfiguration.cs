using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public static class EntityBaseModelConfiguration
    {
        public static void AddBaseMapping<T>(this EntityTypeBuilder<T> builder) where T : EntityBase
        {
            _ = builder.Property(p => p.InclusionDate)
                       .IsRequired()
                       .HasColumnType("datetime2");

            _ = builder.Property(p => p.Active)
                       .IsRequired()
                       .HasColumnType("bit");

            _ = builder.Property(p => p.LastChangeDate)
                       .HasColumnType("datetime2");
        }
    }
}
