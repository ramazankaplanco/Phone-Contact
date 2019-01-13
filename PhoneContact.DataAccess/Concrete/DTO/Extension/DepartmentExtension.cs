#region 

using System.Collections.Generic;
using System.Linq;

#endregion

namespace PhoneContact.DataAccess.Concrete.DTO.Extension
{
	public static class DepartmentExtension
	{
		public static Department ToDto(this Entities.Department department)
		{
			if (department == null)
				return null;

			return new Department
			{
				Id = department.Id,
				DepartmentCode = department.Code,
				DepartmentName = department.Name,
				DepartmentNote = department.Note
			};
		}

		public static List<Department> ToDto(this IEnumerable<Entities.Department> departments)
		{
			return departments.Select(ToDto).ToList();
		}

		public static void ToUpdate(this Entities.Department department, Department item)
		{
			if (department == null)
				return;

			department.Code = item.DepartmentCode;
			department.Name = item.DepartmentName;
			department.Note = item.DepartmentNote;
		}

		public static Entities.Department ToEntity(this Department department)
		{
			if (department == null)
				return null;

			return new Entities.Department
			{
				Code = department.DepartmentCode,
				Name = department.DepartmentName,
				Note = department.DepartmentNote
			};
		}
	}
}