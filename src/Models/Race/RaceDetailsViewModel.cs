namespace TheMatrixAPI.Models.Race
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RaceDetailsViewModel
    {
        [Display(Name = "Race Name")]
        public string Name { get; set; }

        public IEnumerable<RaceCharacterViewModel> Characters { get; set; }
    }

    public class RaceCharacterViewModel
    {
        [Display(Name = "Character Name")]
        public string Name { get; set; }

        public string Alignment { get; set; }
    }
}
