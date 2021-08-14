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
    }
}
