namespace TheMatrixAPI.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using TheMatrixAPI.Data;
    using TheMatrixAPI.Models.Character;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Models.DTO.Character;

    public class CharactersService : ICharactersService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CharactersService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public CharactersGroups GetAllGroups()
        {
            var charactres = new CharactersGroups();

            var good = this.dbContext.Characters.Where(x => x.Alignment == "Good")
                .ProjectTo<CharacterGroup>(this.mapper.ConfigurationProvider)
                .ToList();

            var neutral = this.dbContext.Characters.Where(x => x.Alignment == "Neutral")
                .ProjectTo<CharacterGroup>(this.mapper.ConfigurationProvider)
                .ToList();

            var bad = this.dbContext.Characters.Where(x => x.Alignment == "Bad")
                .ProjectTo<CharacterGroup>(this.mapper.ConfigurationProvider)
                .ToList();

            charactres.Good = good;
            charactres.Neutral = neutral;
            charactres.Bad = bad;
            return charactres;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var charactres = this.dbContext.Characters
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
            return charactres;
        }

        public T GetById<T>(int id)
        {
            var movie = dbContext.Characters
               .Where(x => x.Id == id)
               .ProjectTo<T>(this.mapper.ConfigurationProvider)
               .FirstOrDefault();

            return movie;
        }

        public bool IsCharacterAvailable(int actorId, int characterId)
        {
            var character = this.dbContext.Characters.Where(x => x.Id == characterId && (x.ActorId == null || x.ActorId == actorId)).FirstOrDefault();
            
            if(character == null)
            {
                return false;
            }

            return true;
        }

        public bool DoesCharacterExist(int id)
        {
            return this.dbContext.Characters.Any(x => x.Id == id);
        }

        public void Add(AddCharacterViewModel characterData)
        {
            var alignment = "Neutral";
            if(characterData.Alignment == "1")
            {
                alignment = "Good";
            }
            else if (characterData.Alignment == "2")
            {
                alignment = "Neutral";
            }
            else if (characterData.Alignment == "3")
            {
                alignment = "Bad";
            }

            var character = new Character
            {
                Name = characterData.Name,
                Alignment = alignment,
                RaceId = characterData.RaceId
            };

            this.dbContext.Characters.Add(character);
            this.dbContext.SaveChanges();

            if(characterData.Quotes != null)
            {
                AddNewQuotes(character.Id, characterData.Quotes);
            }

            this.dbContext.SaveChanges();
        }

        public void Edit(int id, EditCharacterViewModel characterData)
        {
            var originalCharacter = this.dbContext.Characters.Where(x => x.Id == id).FirstOrDefault();

            originalCharacter.Name = characterData.Name;
            originalCharacter.Alignment = characterData.Alignment;
            originalCharacter.RaceId = characterData.RaceId;

            if (characterData.NewQuotes != null)
            {
                AddNewQuotes(id, characterData.NewQuotes);
            }

            var dbQuotes = this.dbContext.Quotes.Where(x => x.CharacterId == id).ToList();
            if (characterData.Quotes != null)
            {
                RemoveQuotes(dbQuotes, characterData.Quotes);
            }
            else if (dbQuotes != null)
            {
                RemoveAllQuotes(dbQuotes);
            }

            this.dbContext.SaveChanges();
        }

        public void DeleteById(int characterId)
        {
            var character = this.dbContext.Characters.Where(x => x.Id == characterId).FirstOrDefault();
            var quotes = this.dbContext.Quotes.Where(x => x.CharacterId == characterId).ToList();

            foreach (var quote in quotes)
            {
                this.dbContext.Quotes.Remove(quote);
            }

            this.dbContext.SaveChanges();
            this.dbContext.Characters.Remove(character);
            this.dbContext.SaveChanges();
        }

        private void AddNewQuotes(int characterId, List<string> quotes)
        {
            foreach (var quote in quotes)
            {
                if (quote == null)
                {
                    continue;
                }
                var newQuote = new Quote
                {
                    CharacterId = characterId,
                    QuoteLine = quote
                };

                this.dbContext.Quotes.Add(newQuote);
            }
        }
        private void RemoveQuotes(List<Quote> dbQuotes, List<Quote> quotes)
        {
            for (int i = 0; i < dbQuotes.Count(); i++)
            {
                if (!quotes.Any(x => x.Id == dbQuotes[i].Id))
                {
                    this.dbContext.Quotes.Remove(dbQuotes[i]);
                }
            }
        }

        private void RemoveAllQuotes(List<Quote> dbQuotes)
        {
            foreach (var quote in dbQuotes)
            {
                this.dbContext.Remove(quote);
            }
        }
    }
}
