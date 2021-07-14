using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.DbModels
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int MovieNumber { get; set; }

        public decimal MovieLength { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        public string DistributedBy { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public decimal Budget { get; set; }

        public decimal BoxOffice { get; set; }

        public virtual ICollection<Actors> Actors { get; set; }

        public virtual ICollection<Races> Races { get; set; }
    }
}
