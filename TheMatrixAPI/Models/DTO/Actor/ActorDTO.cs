using System.Collections.Generic;

namespace TheMatrixAPI.Models.DTO
{
    public class ActorDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.MiddleName + " " + this.LastName;
            }
        }

        public int? CharacterId { get; set; }

        public ActorCharacterDTO Character { get; set; }

        public List<ActorMovieDTO> Movies { get; set; }
    }

    public class ActorCharacterDTO
    {
        public string Name { get; set; }
    }
}
