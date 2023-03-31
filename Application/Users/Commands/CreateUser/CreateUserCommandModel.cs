﻿using System;

namespace KredoBank.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
