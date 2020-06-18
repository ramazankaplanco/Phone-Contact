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
                UserName = user.UserName,
                UserFirstName = user.FirstName,
                UserLastName = user.LastName,
                UserEmail = user.Email,
                UserPhoneNumber = user.PhoneNumber,
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

            user.UserName = item.UserName;
            user.FirstName = item.UserFirstName;
            user.LastName = item.UserLastName;
            user.Email = item.UserEmail;
            user.PhoneNumber = item.UserPhoneNumber;
            user.Note = item.UserNote;
        }

        public static Entities.User ToEntity(this User user)
        {
            if (user == null)
                return null;

            return new Entities.User
            {
                UserName = user.UserName,
                FirstName = user.UserFirstName,
                LastName = user.UserLastName,
                Email = user.UserEmail,
                PhoneNumber = user.UserPhoneNumber,
                Note = user.UserNote
            };
        }
    }
}