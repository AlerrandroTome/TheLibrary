using System;

namespace TheLibrary.Infrastructure.DTOs.User
{
    public class UserCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPFCNPJ { get; set; }

        /*public string Cep { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }*/
    }
}
