namespace TheMatrixAPI.Models.DTO.Character
{
    using System.Collections.Generic;
    using TheMatrixAPI.Models.DbModels;

    public class CharactersGroups
    {
        public IEnumerable<CharacterGroup> Good { get; set; }

        public IEnumerable<CharacterGroup> Neutral { get; set; }

        public IEnumerable<CharacterGroup> Bad { get; set; }
    }

    public class CharacterGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RaceId { get; set; }
        public Race Race { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
