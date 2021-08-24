namespace TheMatrixAPI.Test.Controllers
{
    using Xunit;
    using TheMatrixAPI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using TheMatrixAPI.Services;

    public class HomeControllerTest
    {
        [Fact]
        public void Index_HttpGet_ShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController(null, Mock.Of<IStatisticsService>());

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void About_HttpGet_ShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController(null, Mock.Of<IStatisticsService>());

            // Act
            var result = homeController.About();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Documentation_HttpGet_ShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController(null, Mock.Of<IStatisticsService>());

            // Act
            var result = homeController.Documentation();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
