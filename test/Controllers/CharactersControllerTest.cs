namespace TheMatrixAPI.Test.Controllers
{
    using Xunit;
    using TheMatrixAPI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using TheMatrixAPI.Services;

    public class CharactersControllerTest
    {
        [Fact]
        public void Index_HttpGet_ShouldReturnView()
        {
            // Arrange
            var charactersController = new CharactersController(Mock.Of<ICharactersService>(), Mock.Of<IRacesService>());

            // Act
            var result = charactersController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Add_HttpGet_ShouldReturnView()
        {
            // Arrange
            var charactersController = new CharactersController(Mock.Of<ICharactersService>(), Mock.Of<IRacesService>());

            // Act
            var result = charactersController.Add();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
