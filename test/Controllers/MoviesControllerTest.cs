namespace TheMatrixAPI.Test.Controllers
{
    using Xunit;
    using TheMatrixAPI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using TheMatrixAPI.Services;

    public class MoviesControllerTest
    {
        [Fact]
        public void Index_HttpGet_ShouldReturnView()
        {
            // Arrange
            var moviesController = new MoviesController(Mock.Of<IMoviesService>(), null, null);

            // Act
            var result = moviesController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Add_HttpGet_ShouldReturnView()
        {
            // Arrange
            var moviesController = new MoviesController(Mock.Of<IMoviesService>(), null, null);

            // Act
            var result = moviesController.Add();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

    }
}
