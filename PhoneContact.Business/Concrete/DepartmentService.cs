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
	public class DepartmentService : IDepartmentService
	{
		public DepartmentService(IDepartmentRepository repository)
		{
			Repository = repository ?? throw new NullReferenceException($"Repository is null");
		}

		public IDepartmentRepository Repository { get; set; }

		public ResponseBase<List<Department>> GetList()
		{
			var model = Repository.GetList(p => !p.IsDeleted).ToDto();

			return new ResponseBase<List<Department>>(model);
		}

		public ResponseBase<Department> GetById(int id)
		{
			var model = Repository.Get(p => p.Id == id).ToDto();

			return new ResponseBase<Department>(model);
		}

		public ResponseBase<Department> Add(Department item)
		{
			var entity = item.ToEntity();

			Repository.Add(entity);

			var save = Repository.Save();

			var model = entity.ToDto();

			return new ResponseBase<Department>(model) { Success = save };
		}

		public ResponseBase<bool> UpdateById(int id, Department item)
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