namespace TheMatrixAPI.Test.Services
{
    using System.Linq;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Models.Quote;
    using TheMatrixAPI.Services;
    using TheMatrixAPI.Test.Mocks;
    using Xunit;

    public class QuotesServiceTest
    {
        [Fact]
        public void DoesQuoteExist_ShouldReturnTrueWhenQuoteWithSelectedIdExists()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            const int quoteId = 1;

            applicationDbContext.Quotes.Add(new Quote
            {
                Id = quoteId,
                QuoteLine = "There is no spoon."
            });
            applicationDbContext.SaveChanges();

            var quotesService = new QuotesService(null, applicationDbContext);

            // Act
            var result = quotesService.DoesQuoteExist(quoteId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_ShouldAddQuote()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var quotesService = new QuotesService(null, applicationDbContext);

            var quote = new AddQuoteViewModel
            {
                QuoteLine = "I Know Kung-Fu!",
                CharacterId = 1
            };

            quotesService.Add(quote);

            // Act
            var result = applicationDbContext.Quotes.ToList().Count();

            // Assert
            Assert.Equal(1, result);
        }
    }
}