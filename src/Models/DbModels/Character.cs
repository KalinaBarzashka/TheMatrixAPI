﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.DbModels
{
    public class Character
    {
        public Character()
        {
            this.Quotes = new HashSet<Quote>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Alignment { get; set; }

        [Required]
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }

        public int? ActorId { get; set; }

        public virtual Actor Actor { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
