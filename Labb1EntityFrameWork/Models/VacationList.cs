using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1EntityFrameWork.Models
{
    public class VacationList
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int VacationListId { get; set; }
        [Required]
        [DisplayName("Start date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("End date")]
        public DateTime EndDate { get; set; }
        [DisplayName("Date of application")]
        public DateTimeOffset DateApplied { get; set; } = DateTimeOffset.Now;
        [ForeignKey(nameof(Employees))]
        [DisplayName("Employee")]
        public int FK_EmployeeId { get; set; }
        public virtual Employee Employees { get; set; }
        [ForeignKey(nameof(Vacations))]
        [DisplayName("Reason for abscence")]
        public int FK_VacationId { get; set; }
        public virtual Vacation Vacations { get; set; }
        
    }
}
