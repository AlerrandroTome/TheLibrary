using System;

namespace TheLibrary.Core.DTOs.Base
{
    public abstract class DtoUpdate
    {
        public Guid Id { get; set; }
        public DateTime LastChangeDate { get; } = DateTime.Now;
        public bool Active { get; set; } = true;
    }
}
