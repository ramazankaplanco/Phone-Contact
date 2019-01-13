#region 

using PhoneContact.Core.DataAccess.EntityFramework;
using PhoneContact.DataAccess.Abstract;
using PhoneContact.DataAccess.Context;

#endregion

namespace PhoneContact.DataAccess.Repository
{
	public class DepartmentRepository : EntityRepositoryBase<Entities.Department, DataContext>, IDepartmentRepository
	{
		public DepartmentRepository(DataContext dataContext) : base(dataContext)
		{

		}
	}
}