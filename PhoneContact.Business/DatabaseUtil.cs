﻿#region

using PhoneContact.Business.Abstract;
using PhoneContact.Business.Concrete;
using PhoneContact.DataAccess;
using PhoneContact.DataAccess.Abstract;
using PhoneContact.DataAccess.Repository;

#endregion

namespace PhoneContact.Business
{
    public class DatabaseUtil
    {
        #region Fields

        private static UnitOfWork _unitOfWork;

        private static IUserRepository _userRepository;
        private static IUserService _userService;

        private static IDepartmentRepository _departmentRepository;
        private static IDepartmentService _departmentService;

        private static IEmployeeRepository _employeeRepository;
        private static IEmployeeService _employeeService;

        #endregion

        #region Properties

        public static UnitOfWork UnitOfWork => _unitOfWork ?? (_unitOfWork = new UnitOfWork());

        public static IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(UnitOfWork.Context));
        public static IUserService UserService => _userService ?? (_userService = new UserService(UserRepository));

        public static IDepartmentRepository DepartmentRepository => _departmentRepository ?? (_departmentRepository = new DepartmentRepository(UnitOfWork.Context));
        public static IDepartmentService DepartmentService => _departmentService ?? (_departmentService = new DepartmentService(DepartmentRepository));

        public static IEmployeeRepository EmployeeRepository => _employeeRepository ?? (_employeeRepository = new EmployeeRepository(UnitOfWork.Context));
        public static IEmployeeService EmployeeService => _employeeService ?? (_employeeService = new EmployeeService(EmployeeRepository));

        #endregion
    }
}