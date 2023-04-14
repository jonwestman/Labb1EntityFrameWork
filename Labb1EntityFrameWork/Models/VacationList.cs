using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1EntityFrameWork.Models
{
    public class VacationList
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int VacationListId { get; set; }
        [ForeignKey(nameof(Employees))]
        public int FK_EmployeeId { get; set; }
        public virtual Employee Employees { get; set; }
        [ForeignKey(nameof(Vacations))]
        public int FK_VacationId { get; set; }
        public virtual Vacation Vacations { get; set; }
        
    }
}
