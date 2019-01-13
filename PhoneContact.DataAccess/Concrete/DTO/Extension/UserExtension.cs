#region 

using System.Collections.Generic;
using System.Linq;

#endregion

namespace PhoneContact.DataAccess.Concrete.DTO.Extension
{
	public static class UserExtension
	{
		public static User ToDto(this Entities.User user)
		{
			if (user == null)
				return null;

			return new User
			{
				Id = user.Id,
				UserName = user.Name,
				UserLastName = user.LastName,
				UserPassword = user.Password,
				UserNickName = user.NickName,
				UserFullName = user.FullName,
				UserNote = user.Note
			};
		}

		public static List<User> ToDto(this IEnumerable<Entities.User> users)
		{
			return users.Select(ToDto).ToList();
		}

		public static void ToUpdate(this Entities.User user, User item)
		{
			if (user == null)
				return;

			user.Name = item.UserName;
			user.LastName = item.UserLastName;
			user.Password = item.UserPassword;
			user.NickName = item.UserNickName;
			user.Note = item.UserNote;
		}

		public static Entities.User ToEntity(this User user)
		{
			if (user == null)
				return null;

			return new Entities.User
			{
				Name = user.UserName,
				LastName = user.UserLastName,
				Password = user.UserPassword,
				NickName = user.UserNickName,
				Note = user.UserNote
			};
		}
	}
}