namespace TheMatrixAPI.Models.Quote
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddQuoteViewModel
    {
        [Required]
        public string QuoteLine { get; set; }

        [Required]
        public int CharacterId { get; set; }

        public IEnumerable<QuoteCharacterViewModel> Characters { get; set; }
    }
}
