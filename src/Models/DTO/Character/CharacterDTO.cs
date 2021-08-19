using System.Collections.Generic;

namespace TheMatrixAPI.Models.DTO.Character
{
    public class CharacterDTO
    {
        public string Alignment { get; set; }

        public List<CharactersInfo> Characters { get; set; }
    }

    public class CharactersInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
