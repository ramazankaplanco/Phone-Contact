namespace PhoneContact.DataAccess.Concrete.DTO
{
	public class User : DtoBase
	{
		public string UserName { get; set; }

		public string UserLastName { get; set; }

		public string UserPassword { get; set; }

		public string UserNickName { get; set; }

		public string UserFullName { get; set; }

		public string UserNote { get; set; }
	}
}