using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.DbModels
{
    public class Quotes
    {
        [Key]
        public int Id { get; set; }

        public string Quote { get; set; }

        public int CharacterId { get; set; }

        public Characters Character { get; set; }
    }
}
