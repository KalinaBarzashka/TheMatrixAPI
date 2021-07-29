using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.Actor
{
    public class EditActorViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public ActorCharacterViewModel Character { get; set; }
    }

    public class ActorCharacterViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
