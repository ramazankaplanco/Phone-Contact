#region 

using PhoneContact.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace PhoneContact.Entities
{
	public class Profile : EntityBase
	{
		[Required]
		[MaxLength(64)]
		public string Name { get; set; }

		[Required]
		[MaxLength(64)]
		public string LastName { get; set; }

		public string Note { get; set; }


		[NotMapped]
		public string FullName => $"{Name} {LastName}";
	}
}