using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.Actor
{
    public class AddActorViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
