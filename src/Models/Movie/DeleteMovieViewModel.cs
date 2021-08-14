using System;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.Movie
{
    public class DeleteMovieViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? MovieNumber { get; set; }

        public int? MovieLength { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        public string DistributedBy { get; set; }

        public string ReleaseDate { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public decimal? Budget { get; set; }

        public decimal? BoxOffice { get; set; }

        public string ImageUrl { get; set; }
    }
}
