using System.ComponentModel.DataAnnotations;

namespace TheMatrixAPI.Models.DbModels
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string QuoteLine { get; set; }

        public int CharacterId { get; set; }

        public Character Character { get; set; }
    }
}
