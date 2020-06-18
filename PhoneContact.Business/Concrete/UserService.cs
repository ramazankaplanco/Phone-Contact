#region 

using PhoneContact.Business.Abstract;
using PhoneContact.DataAccess.Concrete.DTO;
using PhoneContact.DataAccess.Concrete.DTO.Extension;
using System;
using System.Collections.Generic;
using PhoneContact.DataAccess.Abstract;

#endregion

namespace PhoneContact.Business.Concrete
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository repository)
        {
            Repository = repository ?? throw new NullReferenceException($"Repository is null");
        }

        public IUserRepository Repository { get; set; }

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

        public ResponseBase<User> GetByUsername(string userName)
        {
            var model = Repository.Get(p => p.UserName == userName).ToDto();

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