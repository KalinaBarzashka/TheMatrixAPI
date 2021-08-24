namespace TheMatrixAPI.Models.DTO.Quote
{    
    public class QuoteDTO
    {
        public int Id { get; set; }

        public string QuoteLine { get; set; }

        public int CharacterId { get; set; }

        public QuoteCharacterDTO Character { get; set; }
    }
}
