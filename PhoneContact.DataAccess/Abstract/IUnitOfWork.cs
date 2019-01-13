#region

using PhoneContact.Core.DataAccess.Base;
using System;

#endregion

namespace PhoneContact.DataAccess.Abstract
{
	public interface IUnitOfWork : IDisposable
	{
		IEntityRepositoryBase<T> GetRepository<T>() where T : class, IEntityBase, new();

		int Save();
	}
}