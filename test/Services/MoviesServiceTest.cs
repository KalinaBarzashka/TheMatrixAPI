namespace TheMatrixAPI.Test.Services
{
    using System;
    using System.Linq;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Models.Movie;
    using TheMatrixAPI.Services;
    using TheMatrixAPI.Test.Mocks;
    using Xunit;

    public class MoviesServiceTest
    {
        [Fact]
        public void DoesMovieExist_ShouldReturnTrueWhenMovieWithSelectedIdExists()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            const int movieId = 1;

            applicationDbContext.Movies.Add(new Movie
            {
                Id = movieId,
                Name = "The Matrix",
                ImageUrl = "https://thematrixapi.com/images/The_Matrix_1_Poster.jpg",
                MovieNumber = 1,
                MovieLength = 136,
                Director = "The Wachowskis",
                Producer = "Joel Silver",
                DistributedBy = "Warner Bros. Pictures",
                ReleaseDate = new DateTime(1999, 03, 31),
                Country = "United States",
                Language = "English",
                Budget = 63 - 000 - 000.00M,
                BoxOffice = 465 - 000 - 000.30M
            });
            applicationDbContext.SaveChanges();

            var moviesService = new MoviesService(null, applicationDbContext);

            // Act
            var result = moviesService.DoesMovieExist(movieId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_ShouldAddMovies()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var moviesService = new MoviesService(null, applicationDbContext);

            var movie = new AddMovieViewModel
            {
                Name = "The Matrix",
                MovieNumber = 1,
                MovieLength = 136,
                Director = "The Watchowskis",
                Producer = "Joel Silver",
                DistributedBy = "Warner Bros. Pictures",
                ReleaseDate = new DateTime(1999, 03, 31).ToString(),
                Country = "United States",
                Language = "English",
                Budget = 63m,
                BoxOffice = 464.70m,
                ImageUrl = "https://thematrixapi.com/images/The_Matrix_1_Poster.jpg"
            };

            moviesService.Add(movie);

            // Act
            var result = applicationDbContext.Movies.ToList().Count();

            // Assert
            Assert.Equal(1, result);

        }

        [Fact]
        public void Delete_ShouldDeleteMovie()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var moviesService = new MoviesService(null, applicationDbContext);

            var movie = new Movie
            {
                Name = "The Matrix",
                MovieNumber = 1,
                MovieLength = 136,
                Director = "The Watchowskis",
                Producer = "Joel Silver",
                DistributedBy = "Warner Bros. Pictures",
                ReleaseDate = new DateTime(1999, 03, 31),
                Country = "United States",
                Language = "English",
                Budget = 63m,
                BoxOffice = 464.70m,
                ImageUrl = "https://thematrixapi.com/images/The_Matrix_1_Poster.jpg"
            };

            applicationDbContext.Movies.Add(movie);
            applicationDbContext.SaveChanges();

            // Act
            var dbMovie = applicationDbContext.Movies.Where(x => x.Name == "The Matrix").FirstOrDefault();
            moviesService.DeleteById(dbMovie.Id);
            var result = applicationDbContext.Movies.ToList().Count();

            // Assert
            Assert.Equal(0, result);
        }
    }
}