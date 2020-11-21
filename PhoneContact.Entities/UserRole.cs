#region 

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using PhoneContact.Core.DataAccess.Base;

#endregion

namespace PhoneContact.Entities
{
    public class UserRole : IdentityUserRole<int>, IEntityBase
    {
        public override int UserId { get; set; }

        public override int RoleId { get; set; }

        [MaxLength(4096)]
        public string Note { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}