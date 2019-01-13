﻿#region 

using PhoneContact.Entities.Base;
using System.ComponentModel.DataAnnotations;

#endregion

namespace PhoneContact.Entities
{
	public class Department : EntityBase
	{
		[Required]
		[MaxLength(256)]
		public string Name { get; set; }

		[MaxLength(32)]
		public string Code { get; set; }

		public string Note { get; set; }
	}
}