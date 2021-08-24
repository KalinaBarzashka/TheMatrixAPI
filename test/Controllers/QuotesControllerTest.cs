namespace TheMatrixAPI.Test.Controllers
{
    using Xunit;
    using TheMatrixAPI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using TheMatrixAPI.Services;

    public class QuotesControllerTest
    {
        [Fact]
        public void Index_HttpGet_ShouldReturnView()
        {
            // Arrange
            var quotesController = new QuotesController(Mock.Of<IQuotesService>(), Mock.Of<ICharactersService>());

            // Act
            var result = quotesController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Add_HttpGet_ShouldReturnView()
        {
            // Arrange
            var quotesController = new QuotesController(Mock.Of<IQuotesService>(), Mock.Of<ICharactersService>());

            // Act
            var result = quotesController.Add();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
