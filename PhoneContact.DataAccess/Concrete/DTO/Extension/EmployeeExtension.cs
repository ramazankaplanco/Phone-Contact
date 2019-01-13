#region 

using System.Collections.Generic;
using System.Linq;

#endregion

namespace PhoneContact.DataAccess.Concrete.DTO.Extension
{
	public static class EmployeeExtension
	{
		public static Employee ToDto(this Entities.Employee employee)
		{
			if (employee == null)
				return null;

			return new Employee
			{
				Id = employee.Id,
				EmployeeName = employee.Name,
				EmployeeLastName = employee.LastName,
				EmployeeFullName = employee.FullName,
				EmployeePhone = employee.Phone,
				DepartmentId = employee.DepartmentId,
				EmployerId = employee.EmployerId,
				EmployeeNote = employee.Note
			};
		}

		public static List<Employee> ToDto(this IEnumerable<Entities.Employee> employees)
		{
			return employees.Select(ToDto).ToList();
		}

		public static void ToUpdate(this Entities.Employee employee, Employee item)
		{
			if (employee == null)
				return;

			employee.Name = item.EmployeeName;
			employee.LastName = item.EmployeeLastName;
			employee.Phone = item.EmployeePhone;
			employee.DepartmentId = item.DepartmentId;
			employee.EmployerId = item.EmployerId;
			employee.Note = item.EmployeeNote;
		}

		public static Entities.Employee ToEntity(this Employee employee)
		{
			if (employee == null)
				return null;

			return new Entities.Employee
			{
				Name = employee.EmployeeName,
				LastName = employee.EmployeeLastName,
				Phone = employee.EmployeePhone,
				DepartmentId = employee.DepartmentId,
				EmployerId = employee.EmployerId,
				Note = employee.EmployeeNote
			};
		}
	}
}