using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.DbModels
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public string FullName
        { 
            get
            {
                return this.FirstName + " " + this.MiddleName + " " + this.LastName;
            }
        }

        public int? CharacterId { get; set; }

        public Character Character { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
