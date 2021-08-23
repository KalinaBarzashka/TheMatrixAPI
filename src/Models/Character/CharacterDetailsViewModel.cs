namespace TheMatrixAPI.Models.Character
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CharacterDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Character Name")]
        public string Name { get; set; }

        public string Alignment { get; set; }

        [Display(Name = "Race Name")]
        public string RaceName { get; set; }

        [Display(Name = "Actor Name")]
        public string ActorName { get; set; }

        public List<CharacterQuoteDetailsViewModel> Quotes { get; set; }
    }

    public class CharacterQuoteDetailsViewModel
    {
        public int Id { get; set; }

        public string QuoteLine { get; set; }
    }
}
