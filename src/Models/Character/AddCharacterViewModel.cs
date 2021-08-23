namespace TheMatrixAPI.Models.Character
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddCharacterViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Character Name")]
        public string Name { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Please select character!")]
        public string Alignment { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please select race!")]
        [Display(Name = "Select Race")]
        public int RaceId { get; set; }

        public List<string> Quotes { get; set; }
    }
}
