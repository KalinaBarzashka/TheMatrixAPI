using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.DbModels
{
    public class Characters
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alignment { get; set; }

        public int RaceId { get; set; }
        public virtual Races Race { get; set; }

        public virtual ICollection<Quotes> Quotes { get; set; }
    }
}
