namespace TheMatrixAPI.Test.Controllers
{
    using Xunit;
    using TheMatrixAPI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using TheMatrixAPI.Services;

    public class ActorsControllerTest
    {
        [Fact]
        public void Index_HttpGet_ShouldReturnView()
        {
            // Arrange
            var actorsController = new ActorsController(Mock.Of<IActorsService>(), Mock.Of<IMoviesService>(), null);

            // Act
            var result = actorsController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Add_HttpGet_ShouldReturnView()
        {
            // Arrange
            var actorsController = new ActorsController(Mock.Of<IActorsService>(), null, null);

            // Act
            var result = actorsController.Add();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
