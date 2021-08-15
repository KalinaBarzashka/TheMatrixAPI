namespace TheMatrixAPI.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using TheMatrixAPI.Data;

    public class CharactersService : ICharactersService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CharactersService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
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
    }
}
