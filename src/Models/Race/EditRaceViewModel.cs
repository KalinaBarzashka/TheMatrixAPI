namespace TheMatrixAPI.Models.Race
{
    using System.ComponentModel.DataAnnotations;

    public class EditRaceViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
