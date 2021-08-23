using System;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.Movie
{
    public class EditMovieViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Movie Number")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Movie Number must be grater than 0")]
        public int MovieNumber { get; set; }

        [Required]
        [Display(Name = "Movie Length")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Movie length must be at least 1 minute.")]
        public int MovieLength { get; set; }

        [MaxLength(100)]
        public string Director { get; set; }

        [MaxLength(100)]
        public string Producer { get; set; }

        [Display(Name = "Distributed By")]
        [MaxLength(100)]
        public string DistributedBy { get; set; }

        [Display(Name = "Release Date")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[\/](0[0-9]|1[0-2])[\/][0-9]{4}$", ErrorMessage = "Release date must valid!")]
        public string ReleaseDate { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string Language { get; set; }

        public decimal? Budget { get; set; }

        [Display(Name = "Box Office")]
        public decimal? BoxOffice { get; set; }

        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
    }
}
