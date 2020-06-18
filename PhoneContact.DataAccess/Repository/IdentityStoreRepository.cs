#region 

using Microsoft.AspNet.Identity.EntityFramework;
using PhoneContact.DataAccess.Context;
using PhoneContact.Entities;

#endregion

namespace PhoneContact.DataAccess.Repository
{
    public class UserStore : UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(DataContext context) : base(context)
        {
        }
    }

    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(DataContext context) : base(context)
        {
        }
    }
}