﻿namespace TheMatrixAPI.Models.Character
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TheMatrixAPI.Models.DbModels;

    public class DeleteCharacterViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Character Name")]
        public string Name { get; set; }

        public string Alignment { get; set; }

        public int RaceId { get; set; }
        [Display(Name = "Race Name")]
        public string RaceName { get; set; }

        public virtual List<Quote> Quotes { get; set; }
    }
}
