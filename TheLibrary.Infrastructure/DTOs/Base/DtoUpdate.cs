using System;

namespace TheLibrary.Infrastructure.DTOs.Base
{
    public abstract class DtoUpdate
    {
        public Guid Id { get; set; }
        public DateTime LastChangeDate { get; } = DateTime.Now;
        public bool Active { get; set; }
    }
}
