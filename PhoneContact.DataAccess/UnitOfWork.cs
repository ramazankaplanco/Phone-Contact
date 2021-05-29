#region 

using PhoneContact.Core.DataAccess.Base;
using PhoneContact.Core.DataAccess.EntityFramework;
using PhoneContact.DataAccess.Abstract;
using PhoneContact.DataAccess.Context;
using PhoneContact.DataAccess.Repository;
using System;

#endregion

namespace PhoneContact.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        private bool _disposed;

        public DataContext Context => _context ?? (_context = new DataContext());

        public int Save()
        {
            return Context.SaveChanges();
        }

        public IEntityRepositoryBase<T> GetRepository<T>() where T : class, IEntityBase, new()
        {
            return new EntityRepositoryBase<T, DataContext>(Context);
        }

        public IUserRepository GetUserRepository()
        {
            return new UserRepository(Context);
        }

        public IDepartmentRepository GetDepartmentRepository()
        {
            return new DepartmentRepository(Context);
        }

        public IEmployeeRepository GetEmployeeRepository()
        {
            return new EmployeeRepository(Context);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                Context.Dispose();

            _disposed = true;
        }
    }
}