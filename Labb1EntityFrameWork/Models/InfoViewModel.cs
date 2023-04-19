using System.ComponentModel;

namespace Labb1EntityFrameWork.Models
{
    public class InfoViewModel
    {
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
    }
}
