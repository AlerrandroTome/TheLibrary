using System;

namespace TheLibrary.Domain.DTOs.Base
{
    public abstract class DTOUpdate
    {
        public Guid Id { get; set; }
        public DateTime LastChangeDate { get; } = DateTime.Now;
        public bool Active { get; set; }
    }
}
