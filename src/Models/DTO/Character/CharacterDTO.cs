namespace TheMatrixAPI.Models.DTO.Character
{
    using System.Collections.Generic;

    public class CharacterDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alignment { get; set; }

        public string RaceName { get; set; }

        public string ActorName { get; set; }

        public List<CharacterQuoteDTO> Quotes { get; set; }
    }

    public class CharacterQuoteDTO
    {
        public int Id { get; set; }

        public string QuoteLine { get; set; }
    }
}
