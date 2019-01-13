﻿#region 

using PhoneContact.DataAccess.Concrete;
using PhoneContact.DataAccess.Concrete.DTO;

#endregion

namespace PhoneContact.Business.Abstract
{
	public interface IUserService : IServiceBase<User>
	{
		ResponseBase<User> GetByNickname(string nickName, string password);
	}
}