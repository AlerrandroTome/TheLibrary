using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Mapping
{
    public static class EntityBaseMapping
    {
        public static void AddBaseMapping<T>(this EntityTypeBuilder<T> builder) where T : EntityBase
        {
            builder.Property(w => w.InclusionDate)
                   .IsRequired()
                   .HasColumnType("datetime2");

            builder.Property(w => w.Active)
                   .IsRequired()
                   .HasColumnType("bit");

            builder.Property(w => w.LastChangeDate)
                   .HasColumnType("datetime2");
        }
    }
}
