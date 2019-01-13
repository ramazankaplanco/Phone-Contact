namespace PhoneContact.DataAccess.Concrete.DTO
{
	public class Employee : DtoBase
	{
		public string EmployeeName { get; set; }

		public string EmployeeLastName { get; set; }

		public string EmployeePhone { get; set; }

		public int? DepartmentId { get; set; }

		public int? EmployerId { get; set; }

		public string EmployeeFullName { get; set; }

		public string EmployeeNote { get; set; }
	}
}