namespace TheMatrixAPI.Test.Services
{
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Models.Home;
    using TheMatrixAPI.Services;
    using TheMatrixAPI.Test.Mocks;
    using Xunit;

    public class StatsticsServiceTest
    {
        [Fact]
        public void GetStatistics()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var statisticsService = new StatisticsService(applicationDbContext);

            var actor = new Actor
            {
                FirstName = "Kalina",
                MiddleName = "Teodorova",
                LastName = "Barzashka"
            };

            applicationDbContext.Actors.Add(actor);
            applicationDbContext.SaveChanges();

            var character = new Character
            {
                Name = "Neo",
                Alignment = "Good",
                RaceId = 1
            };

            applicationDbContext.Characters.Add(character);
            applicationDbContext.SaveChanges();

            var race = new Race
            {
                Name = "Humans"
            };

            applicationDbContext.Races.Add(race);
            applicationDbContext.SaveChanges();

            var viewModel = new StatisticsViewModel();
            // Act
            statisticsService.GetStatistics(viewModel);

            // Assert
            Assert.Equal(1, viewModel.Actors);
            Assert.Equal(1, viewModel.Races);
            Assert.Equal(1, viewModel.Characters);
            Assert.Equal(0, viewModel.Movies);
            Assert.Equal(0, viewModel.Quotes);
        }

    }
}
