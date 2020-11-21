#region 

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using PhoneContact.Core.DataAccess.Base;

#endregion

namespace PhoneContact.Entities
{
    public class UserClaim : IdentityUserClaim<int>, IEntityBase
    {
        public override int Id { get; set; }

        public override int UserId { get; set; }

        public override string ClaimType { get; set; }

        public override string ClaimValue { get; set; }

        [MaxLength(4096)]
        public string Note { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}