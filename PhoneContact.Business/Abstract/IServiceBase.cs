#region 

using PhoneContact.DataAccess.Concrete;
using System.Collections.Generic;

#endregion

namespace PhoneContact.Business.Abstract
{
	public interface IServiceBase<T> where T : class, new()
	{
		ResponseBase<List<T>> GetList();

		ResponseBase<T> GetById(int id);

		ResponseBase<T> Add(T item);

		ResponseBase<bool> UpdateById(int id, T item);

		ResponseBase<bool> DeleteById(int id);
	}
}