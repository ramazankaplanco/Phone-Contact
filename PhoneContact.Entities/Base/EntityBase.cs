#region 

using PhoneContact.Core.DataAccess.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace PhoneContact.Entities.Base
{
	public class EntityBase : IEntityBase
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public bool IsDeleted { get; set; }
	}
}