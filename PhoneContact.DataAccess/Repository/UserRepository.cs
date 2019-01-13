#region

using PhoneContact.Core.DataAccess.EntityFramework;
using PhoneContact.DataAccess.Abstract;
using PhoneContact.DataAccess.Context;

#endregion

namespace PhoneContact.DataAccess.Repository
{
	public class UserRepository : EntityRepositoryBase<Entities.User, DataContext>, IUserRepository
	{
		public UserRepository(DataContext dataContext) : base(dataContext)
		{

		}
	}
}