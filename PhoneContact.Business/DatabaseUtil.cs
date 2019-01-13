#region 

using PhoneContact.Business.Concrete;
using PhoneContact.Core.DataAccess.Base;
using PhoneContact.DataAccess;

#endregion

namespace PhoneContact.Business
{
	public class DatabaseUtil
	{
		#region Fields

		private static UnitOfWork _unitOfWork;

		private static IEntityRepositoryBase<Entities.User> _userRepository;
		private static UserService _userService;

		private static IEntityRepositoryBase<Entities.Department> _departmentRepository;
		private static DepartmentService _departmentService;

		private static IEntityRepositoryBase<Entities.Employee> _employeeRepository;
		private static EmployeeService _employeeService;

		#endregion

		#region Properties

		public static UnitOfWork UnitOfWork => _unitOfWork ?? (_unitOfWork = new UnitOfWork());

		public static IEntityRepositoryBase<Entities.User> UserRepository
			=> _userRepository ?? (_userRepository = UnitOfWork.GetRepository<Entities.User>());

		public static UserService UserService
			=> _userService ?? (_userService = new UserService(UserRepository));

		public static IEntityRepositoryBase<Entities.Department> DepartmentRepository
			=> _departmentRepository ?? (_departmentRepository = UnitOfWork.GetRepository<Entities.Department>());

		public static DepartmentService DepartmentService
			=> _departmentService ?? (_departmentService = new DepartmentService(DepartmentRepository));

		public static IEntityRepositoryBase<Entities.Employee> EmployeeRepository
			=> _employeeRepository ?? (_employeeRepository = UnitOfWork.GetRepository<Entities.Employee>());

		public static EmployeeService EmployeeService
			=> _employeeService ?? (_employeeService = new EmployeeService(EmployeeRepository));

		#endregion
	}
}