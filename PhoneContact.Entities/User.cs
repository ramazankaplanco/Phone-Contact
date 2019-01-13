#region 

using System.ComponentModel.DataAnnotations;

#endregion

namespace PhoneContact.Entities
{
	public class User : Profile
	{
		[Required]
		[MaxLength(64)]
		public string Password { get; set; }

		[MaxLength(64)]
		public string NickName { get; set; }
	}
}