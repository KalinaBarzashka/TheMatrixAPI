using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.DbModels
{
    public class Races
    {
        public Races()
        {
            this.Characters = new HashSet<Characters>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Characters> Characters { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }
}
