using System.ComponentModel;

namespace Labb1EntityFrameWork.Models
{
    public class InfoViewModel
    {
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string VacayType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateApplied { get; set; }

    }
}
