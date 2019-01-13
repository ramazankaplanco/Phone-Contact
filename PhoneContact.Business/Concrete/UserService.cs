#region 

using PhoneContact.Business.Abstract;
using PhoneContact.Core.DataAccess.Base;
using PhoneContact.DataAccess.Concrete;
using PhoneContact.DataAccess.Concrete.DTO;
using PhoneContact.DataAccess.Concrete.DTO.Extension;
using System;
using System.Collections.Generic;

#endregion

namespace PhoneContact.Business.Concrete
{
	public class UserService : IUserService
	{
		public UserService(IEntityRepositoryBase<Entities.User> repository)
		{
			Repository = repository ?? throw new NullReferenceException($"Repository is null");
		}

		public IEntityRepositoryBase<Entities.User> Repository { get; set; }

		public ResponseBase<List<User>> GetList()
		{
			var model = Repository.GetList(p => !p.IsDeleted).ToDto();

			return new ResponseBase<List<User>>(model);
		}

		public ResponseBase<User> GetById(int id)
		{
			var model = Repository.Get(p => p.Id == id).ToDto();

			return new ResponseBase<User>(model);
		}

		public ResponseBase<User> GetByNickname(string nickName, string password)
		{
			var model = Repository.Get(p => p.NickName == nickName && p.Password == password).ToDto();

			return new ResponseBase<User>(model);
		}

		public ResponseBase<User> Add(User item)
		{
			var entity = item.ToEntity();

			Repository.Add(entity);

			var save = Repository.Save();

			var model = entity.ToDto();

			return new ResponseBase<User>(model) { Success = save };
		}

		public ResponseBase<bool> UpdateById(int id, User item)
		{
			var entity = Repository.Get(p => p.Id == id);

			entity.ToUpdate(item);

			Repository.Update(entity);

			var update = Repository.Save();

			return new ResponseBase<bool>(update) { Success = update };
		}

		public ResponseBase<bool> DeleteById(int id)
		{
			throw new NotImplementedException();
		}
	}
}