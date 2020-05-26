#region 

using PhoneContact.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace PhoneContact.Entities
{
    public class Employee : Profile
    {
        [Required]
        [MaxLength(32)]
        public string Phone { get; set; }

        public int? DepartmentId { get; set; }

        public int? EmployerId { get; set; }


        [ForeignKey("EmployerId")]
        public virtual Employee Employer { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}