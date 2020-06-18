﻿namespace PhoneContact.DataAccess.Concrete.DTO
{
    public class User : DtoBase
    {
        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public string UserPhoneNumber { get; set; }

        public string UserFullName { get; set; }

        public string UserNote { get; set; }
    }
}