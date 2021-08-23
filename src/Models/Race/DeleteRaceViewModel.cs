namespace TheMatrixAPI.Models.Race
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteRaceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Race Name")]
        public string Name { get; set; }
    }
}
