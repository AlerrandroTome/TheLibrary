using System;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Domain.Entities
{
    public class User : EntityBase, IODataEntity
    {
        //UserFields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPFCNPJ { get; set; }

        /*
        //Address Fields
        public string Cep { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        */
    }
}
