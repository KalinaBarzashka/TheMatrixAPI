using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.DbModels
{
    public class Race
    {
        public Race()
        {
            this.Characters = new HashSet<Character>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Character> Characters { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
