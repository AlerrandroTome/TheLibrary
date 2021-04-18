using System;

namespace TheLibrary.Infrastructure.DTOs.UserAddress
{
    public class UserAddressDTO
    {
        public string Address { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string IdentificationCode { get; set; }
    }
}
