namespace TheMatrixAPI.Models.Character
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TheMatrixAPI.Models.DbModels;

    public class EditCharacterViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        [RegularExpression("Good|Bad|Neutral", ErrorMessage = "Only Good, Bad or Neutral are allowed for alignment!")]
        public string Alignment { get; set; }

        [Required]
        public int RaceId { get; set; }
        public string RaceName { get; set; }

        public virtual List<Quote> Quotes { get; set; }

        public virtual List<string> NewQuotes { get; set; }
    }
}
