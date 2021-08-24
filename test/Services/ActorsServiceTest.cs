namespace TheMatrixAPI.Test.Services
{
    using System.Linq;
    using TheMatrixAPI.Models.Actor;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Services;
    using TheMatrixAPI.Test.Mocks;
    using Xunit;

    public class ActorsServiceTest
    {
        [Fact]
        public void DoesActorExist_ShouldReturnTrueWhenMovieWithSelectedIdExists()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            const int actorId = 1;

            applicationDbContext.Actors.Add(new Actor
            {
                Id = actorId,
                FirstName = "Keanu",
                MiddleName = "Charles",
                LastName = "Reeves",
            });
            applicationDbContext.SaveChanges();

            var actorsService = new ActorsService(applicationDbContext, null);

            // Act
            var result = actorsService.DoesActorExist(actorId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_ShouldAddActors()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var actorsService = new ActorsService(applicationDbContext, null);

            var actor = new AddActorViewModel
            {
                FirstName = "Kalina",
                MiddleName = "Teodorova",
                LastName = "Barzashka"
            };

            actorsService.Add(actor);

            // Act
            var result = applicationDbContext.Actors.ToList().Count();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Delete_ShouldDeleteActor()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var actorsService = new ActorsService(applicationDbContext, null);

            var actor = new Actor
            {
                FirstName = "Kalina",
                MiddleName = "Teodorova",
                LastName = "Barzashka"
            };

            applicationDbContext.Actors.Add(actor);
            applicationDbContext.SaveChanges();

            // Act
            var dbActor = applicationDbContext.Actors.Where(x => x.FirstName == "Kalina").FirstOrDefault();
            actorsService.DeleteById(dbActor.Id);
            var result = applicationDbContext.Actors.ToList().Count();

            // Assert
            Assert.Equal(0, result);
        }

    }
}
