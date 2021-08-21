using System.Collections.Generic;
using TheMatrixAPI.Models.DbModels;

namespace TheMatrixAPI.Models.Character
{
    public class DeleteCharacterViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alignment { get; set; }

        public int RaceId { get; set; }
        public string RaceName { get; set; }

        public virtual List<Quote> Quotes { get; set; }
    }
}
