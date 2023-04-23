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
        public DateTime DateApplied { get; set; } = DateTime.Now;
        [ForeignKey(nameof(Employees))]
        [DisplayName("Employee")]
        public int FK_EmployeeId { get; set; }
        public virtual Employee? Employees { get; set; } = default!;
        [ForeignKey(nameof(Vacations))]
        [DisplayName("Reason for abscence")]
        public int FK_VacationId { get; set; }
		[DisplayName("Reason for abscence")]
		public virtual Vacation? Vacations { get; set; } = default!;

	}
}
