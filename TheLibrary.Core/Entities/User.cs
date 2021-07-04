using System;
using System.Collections.Generic;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Core.Entities
{
    public class User : EntityBase, IODataEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        //registration number of the user in his country of origin.
        public string Identification { get; set; }

        public ICollection<UserAddress> Addresses { get; set; } = new List<UserAddress>();
    }
}
