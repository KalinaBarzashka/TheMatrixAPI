namespace TheMatrixAPI.Models.Race
{
    using System.Collections.Generic;

    public class RaceDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<RaceCharacterDTO> Characters { get; set; }
    }

    public class RaceCharacterDTO
    {
        public string Name { get; set; }

        public string Alignment { get; set; }
    }
}
