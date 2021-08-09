using System;
using System.Collections.Generic;

namespace TheMatrixAPI.Models.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int MovieNumber { get; set; }

        public int? MovieLength { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        public string DistributedBy { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public decimal Budget { get; set; }

        public decimal BoxOffice { get; set; }

        public List<MovieActorDTO> Actors { get; set; }

        public List<MovieRaceDTO> Races { get; set; }
    }
}
