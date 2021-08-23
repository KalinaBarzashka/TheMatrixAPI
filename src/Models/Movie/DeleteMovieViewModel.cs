using System;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.Movie
{
    public class DeleteMovieViewModel
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Display(Name = "Movie Number")]
        public int? MovieNumber { get; set; }

        [Display(Name = "Movie Length")]
        public int? MovieLength { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        [Display(Name = "Distributed By")]
        public string DistributedBy { get; set; }

        [Display(Name = "Release Date")]
        public string ReleaseDate { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public decimal? Budget { get; set; }

        [Display(Name = "Box Office")]
        public decimal? BoxOffice { get; set; }

        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
    }
}
