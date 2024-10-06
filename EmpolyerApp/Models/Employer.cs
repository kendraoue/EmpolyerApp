using System.ComponentModel.DataAnnotations;

namespace EmpolyerApp.Models
{
    public class Employer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Url]
        [Display(Name = "Website URL")]
        public string Website { get; set; }

        [Display(Name = "Incorporation Date")]
        public DateTime? IncorporatedDate { get; set; }
    }
}
