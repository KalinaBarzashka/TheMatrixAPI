using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.Character
{
    public class AddCharacterViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Please select character!")]
        public string Alignment { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please select race!")]
        public int RaceId { get; set; }

        public List<string> Quotes { get; set; }
    }
}
