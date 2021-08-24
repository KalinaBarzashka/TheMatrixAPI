namespace TheMatrixAPI.Test.Services
{
    using System.Linq;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Models.Race;
    using TheMatrixAPI.Services;
    using TheMatrixAPI.Test.Mocks;
    using Xunit;

    public class RacesServiceTest
    {
        [Fact]
        public void DoesRaceExist_ShouldReturnTrueWhenRaceWithSelectedIdExists()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            const int raceId = 1;

            applicationDbContext.Races.Add(new Race
            {
                Id = raceId,
                Name = "Humans"
            });
            applicationDbContext.SaveChanges();

            var racesService = new RacesService(applicationDbContext, null);

            // Act
            var result = racesService.DoesRaceExist(raceId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_ShouldAddRace()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var racesService = new RacesService(applicationDbContext, null);

            var race = new AddRaceViewModel
            {
                Name = "Humans"
            };

            racesService.Add(race);

            // Act
            var result = applicationDbContext.Races.ToList().Count();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Delete_ShouldDeleteRace()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var racesService = new RacesService(applicationDbContext, null);

            var race = new Race
            {
                Name = "Humans"
            };

            applicationDbContext.Races.Add(race);
            applicationDbContext.SaveChanges();

            // Act
            var dbRace = applicationDbContext.Races.Where(x => x.Name == "Humans").FirstOrDefault();
            racesService.DeleteById(dbRace.Id);
            var result = applicationDbContext.Races.ToList().Count();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void IsRaceInUse_ShouldReturnFalse()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var racesService = new RacesService(applicationDbContext, null);

            var race = new Race
            {
                Name = "Humans"
            };

            applicationDbContext.Races.Add(race);
            applicationDbContext.SaveChanges();

            // Act
            var result = racesService.IsRaceInUse(race.Id);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsRaceInUse_ShouldReturnTrue()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var racesService = new RacesService(applicationDbContext, null);

            var race = new Race
            {
                Name = "Humans"
            };

            applicationDbContext.Races.Add(race);
            applicationDbContext.SaveChanges();

            var character = new Character
            {
                Name = "Neo",
                Alignment = "Good",
                RaceId = race.Id
            };

            applicationDbContext.Characters.Add(character);
            applicationDbContext.SaveChanges();

            // Act
            var result = racesService.IsRaceInUse(race.Id);

            // Assert
            Assert.True(result);
        }
    }
}