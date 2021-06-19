using System;
using TheLibrary.Infrastructure.Entities;

namespace TheLibrary.Core.Entities
{
    public class UserAddress : EntityBase
    {
        public string Address { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public Guid UserId { get; set; }
        public string IdentificationCode { get; set; }

        public User User { get; set; }
    }
}
