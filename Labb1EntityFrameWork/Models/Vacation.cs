using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1EntityFrameWork.Models
{
    public class Vacation
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int VacationId { get; set; }      
        [Required]
        [DisplayName("Reason for abscence")]
        public string VacayType { get; set; }
        public DateTime DateApplied { get; set; } = DateTime.Now;
        public virtual ICollection<VacationList>? VacationLists { get; set; } //navigation
    }
}
