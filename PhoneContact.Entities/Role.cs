using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PhoneContact.Entities
{
    public class Role : IdentityRole<int, UserRole>
    {
        public bool IsDeleted { get; set; }

        [MaxLength(4096)]
        public string Note { get; set; }


        public override ICollection<UserRole> Users => base.Users;
    }
}