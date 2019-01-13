#region 

using PhoneContact.Core.DataAccess.EntityFramework;
using PhoneContact.DataAccess.Abstract;
using PhoneContact.DataAccess.Context;

#endregion

namespace PhoneContact.DataAccess.Repository
{
	public class EmployeeRepository : EntityRepositoryBase<Entities.Employee, DataContext>, IEmployeeRepository
	{
		public EmployeeRepository(DataContext dataContext) : base(dataContext)
		{

		}
	}
}