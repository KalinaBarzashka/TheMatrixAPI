namespace TheMatrixAPI.Test.Controllers
{
    using Xunit;
    using TheMatrixAPI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using TheMatrixAPI.Services;

    public class RacesControllerTest
    {
        [Fact]
        public void Index_HttpGet_ShouldReturnView()
        {
            // Arrange
            var racesController = new RacesController(Mock.Of<IRacesService>());

            // Act
            var result = racesController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Add_HttpGet_ShouldReturnView()
        {
            // Arrange
            var racesController = new RacesController(Mock.Of<IRacesService>());

            // Act
            var result = racesController.Add();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
