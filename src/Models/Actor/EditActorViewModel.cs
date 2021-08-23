using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.Actor
{
    public class EditActorViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        public ActorCharacterViewModel Character { get; set; }

        public List<ActorMovieViewModel> Movies { get; set; }

        public int[] CheckedMovies { get; set; }
    }

    public class ActorMovieViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        public string Name { get; set; }
    }

    public class ActorCharacterViewModel
    {
        [Display(Name = "Character Played")]
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please select a character!")]
        public int Id { get; set; }

        [Display(Name = "Character Name")]
        public string Name { get; set; }
    }
}
