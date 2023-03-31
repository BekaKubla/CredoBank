using KredoBank.Domain.Entity.Statement;
using System;
using System.Collections.Generic;

namespace KredoBank.Domain.Entity.User
{
    public class Users
    {

        public Users(string firstName,
                     string lastName,
                     string personalNumber,
                     DateTime birthDate,
                     string userName,
                     string password)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
            UserName = userName;
            Password = password;
        }
        public int Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool IsActive { get; set; }
        public bool IsHidden { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PersonalNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public virtual List<Statements> Statements { get; private set; } = new List<Statements>();

        public static Users RegisterUser(string firstName,
                                         string lastName,
                                         string personalNumber,
                                         DateTime birthDate,
                                         string userName,
                                         string password) => new(firstName,
                                                                 lastName,
                                                                 personalNumber,
                                                                 birthDate,
                                                                 userName,
                                                                 password);

        public void AddStatement(Statements statement)
        {
            Statements.Add(statement);
        }

    }
}
