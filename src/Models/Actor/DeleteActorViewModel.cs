namespace TheMatrixAPI.Models.Actor
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteActorViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
