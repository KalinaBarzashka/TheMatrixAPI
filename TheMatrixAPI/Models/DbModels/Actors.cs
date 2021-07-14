using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.DbModels
{
    public class Actors
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string GetName 
        { 
            get
            {
                return this.FirstName + " " + this.MiddleName + " " + this.LastName;
            }
        }

        public virtual ICollection<Movies> Movies { get; set; }
    }
}
