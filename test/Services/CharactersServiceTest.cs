namespace TheMatrixAPI.Test.Services
{
    using System.Linq;
    using TheMatrixAPI.Models.Character;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Services;
    using TheMatrixAPI.Test.Mocks;
    using Xunit;

    public class CharactersServiceTest
    {
        [Fact]
        public void DoesCharacterExist_ShouldReturnTrueWhenCharacterWithSelectedIdExists()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            const int characterId = 1;

            applicationDbContext.Characters.Add(new Character
            {   
                Id = characterId,
                Name = "Neo",
                Alignment = "Good"
            });
            applicationDbContext.SaveChanges();

            var charactersService = new CharactersService(applicationDbContext, null);

            // Act
            var result = charactersService.DoesCharacterExist(characterId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_ShouldAddCharacters()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var charactersService = new CharactersService(applicationDbContext, null);

            var character = new AddCharacterViewModel
            {
                Name = "Neo",
                Alignment = "Good",
                RaceId = 1
            };

            charactersService.Add(character);

            // Act
            var result = applicationDbContext.Characters.ToList().Count();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Delete_ShouldDeleteCharacter()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var charactersService = new CharactersService(applicationDbContext, null);

            var character = new Character
            {
                Name = "Neo",
                Alignment = "Good",
                RaceId = 1
            };

            applicationDbContext.Characters.Add(character);
            applicationDbContext.SaveChanges();

            // Act
            var dbCharacter = applicationDbContext.Characters.Where(x => x.Name == "Neo").FirstOrDefault();
            charactersService.DeleteById(dbCharacter.Id);
            var result = applicationDbContext.Characters.ToList().Count();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Delete_ShouldDeleteCharacterAndQuotes()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var charactersService = new CharactersService(applicationDbContext, null);

            var character = new Character
            {
                Name = "Neo",
                Alignment = "Good",
                RaceId = 1
            };

            applicationDbContext.Characters.Add(character);
            applicationDbContext.SaveChanges();

            var quote = new Quote
            {
                QuoteLine = "I Know Kung-Fu!",
                CharacterId = character.Id
            };

            applicationDbContext.Quotes.Add(quote);
            applicationDbContext.SaveChanges();

            // Act
            var dbCharacter = applicationDbContext.Characters.Where(x => x.Name == "Neo").FirstOrDefault();
            charactersService.DeleteById(dbCharacter.Id);
            var result = applicationDbContext.Characters.ToList().Count();
            var resultQuotes = applicationDbContext.Quotes.ToList().Count();

            // Assert
            Assert.Equal(0, result);
            Assert.Equal(0, resultQuotes);
        }

        [Fact]
        public void IsCharacterAvailable_ShoudReturnTrueForAvailableCharacter()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var charactersService = new CharactersService(applicationDbContext, null);

            var character = new Character
            {
                Name = "Neo",
                Alignment = "Good",
                RaceId = 1
            };

            applicationDbContext.Characters.Add(character);
            applicationDbContext.SaveChanges();

            var actor = new Actor
            {
                FirstName = "Kalina",
                MiddleName = "Teodorova",
                LastName = "Barzashka"
            };

            applicationDbContext.Actors.Add(actor);
            applicationDbContext.SaveChanges();

            // Act
            var result = charactersService.IsCharacterAvailable(actor.Id, character.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsCharacterAvailable_ShoudReturnFalseForNotAvailableCharacter()
        {
            // Arrange
            using var applicationDbContext = DatabaseMock.Instance;
            var charactersService = new CharactersService(applicationDbContext, null);

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
                RaceId = 1,
                ActorId = actor.Id
            };

            applicationDbContext.Characters.Add(character);
            applicationDbContext.SaveChanges();

            var actor2 = new Actor
            {
                FirstName = "Pesho",
                MiddleName = "Teodorov",
                LastName = "Peshev"
            };

            applicationDbContext.Actors.Add(actor2);
            applicationDbContext.SaveChanges();

            // Act
            var result = charactersService.IsCharacterAvailable(actor2.Id, character.Id);

            // Assert
            Assert.False(result);
        }
    }
}
