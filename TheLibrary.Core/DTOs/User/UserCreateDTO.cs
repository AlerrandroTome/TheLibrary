using System;
using System.Collections.Generic;
using TheLibrary.Core.DTOs.UserAddress;

namespace TheLibrary.Core.DTOs.User
{
    public class UserCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Identification { get; set; }
        public ICollection<UserAddressDTO> Addresses { get; set; } = new List<UserAddressDTO>();
    }
}
