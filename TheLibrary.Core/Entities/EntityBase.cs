using System;

namespace TheLibrary.Core.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime InclusionDate { get; set; } = DateTime.Now;
        public DateTime? LastChangeDate { get; set; }
        public bool Active { get; set; } = true;
    }
}
