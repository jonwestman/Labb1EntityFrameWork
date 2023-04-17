using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1EntityFrameWork.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; } = 0;
        [Required]
        [StringLength(50)]
        [DisplayName("First name")]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(50)]
        [DisplayName("Last name")]
        public string LastName { get; set; } = default!;
        [StringLength(50)]
        public string? Email { get; set; }
    }
}
