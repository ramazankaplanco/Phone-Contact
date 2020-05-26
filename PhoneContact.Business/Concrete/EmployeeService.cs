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
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeRepository repository)
        {
            Repository = repository ?? throw new NullReferenceException($"Repository is null");
        }

        public IEmployeeRepository Repository { get; set; }

        public ResponseBase<List<Employee>> GetList()
        {
            var model = Repository.GetList(p => !p.IsDeleted).ToDto();

            return new ResponseBase<List<Employee>>(model);
        }

        public ResponseBase<Employee> GetById(int id)
        {
            var model = Repository.Get(p => p.Id == id).ToDto();

            return new ResponseBase<Employee>(model);
        }

        public ResponseBase<Employee> Add(Employee item)
        {
            var entity = item.ToEntity();

            Repository.Add(entity);

            var save = Repository.Save();

            var model = entity.ToDto();

            return new ResponseBase<Employee>(model) { Success = save };
        }

        public ResponseBase<bool> UpdateById(int id, Employee item)
        {
            var entity = Repository.Get(p => p.Id == id);

            entity.ToUpdate(item);

            Repository.Update(entity);

            var update = Repository.Save();

            return new ResponseBase<bool>(update) { Success = update };
        }

        public ResponseBase<bool> DeleteById(int id)
        {
            var entity = Repository.Get(p => p.Id == id);

            Repository.Delete(entity);

            var delete = Repository.Save();

            return new ResponseBase<bool>(delete) { Success = delete };
        }
    }
}