#region 

using System.ComponentModel.DataAnnotations;

#endregion

namespace PhoneContact.Entities
{
    public class User : Profile
    {
        [Required]
        [MaxLength(64)]
        [MinLength(4)]
        public string Password { get; set; }

        [Required]
        [MaxLength(64)]
        public string NickName { get; set; }
    }
}