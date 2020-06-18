#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using PhoneContact.Core.DataAccess.Base;

#endregion

namespace PhoneContact.Entities
{
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>, IEntityBase
    {
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(64)]
        public override string UserName { get; set; }

        [Required]
        [MaxLength(64)]
        public override string Email { get; set; }

        [MaxLength(32)]
        public override string PhoneNumber { get; set; }

        public bool IsDeleted { get; set; }

        [MaxLength(4096)]
        public string Note { get; set; }


        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";


        public override ICollection<UserLogin> Logins => base.Logins;

        public override ICollection<UserRole> Roles => base.Roles;

        public override ICollection<UserClaim> Claims => base.Claims;
    }
}