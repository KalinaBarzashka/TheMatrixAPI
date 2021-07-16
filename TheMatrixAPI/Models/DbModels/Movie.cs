using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheMatrixAPI.Models.DbModels
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int MovieNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MovieLength { get; set; }

        [MaxLength(100)]
        public string Director { get; set; }

        [MaxLength(100)]
        public string Producer { get; set; }

        [MaxLength(100)]
        public string DistributedBy { get; set; }

        public DateTime ReleaseDate { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string Language { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BoxOffice { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
