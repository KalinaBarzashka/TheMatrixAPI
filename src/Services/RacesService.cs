namespace TheMatrixAPI.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using TheMatrixAPI.Data;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Models.Race;

    public class RacesService : IRacesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public RacesService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.dbContext.Races
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public T GetById<T>(int id)
        {
            return this.dbContext.Races
                .Where(x => x.Id == id)
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        public T GetRaceDetailsById<T>(int id)
        {
            return this.dbContext.Races
                .Where(x => x.Id == id)
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        public bool DoesRaceExist(int id)
        {
            return this.dbContext.Races.Any(x => x.Id == id);
        }

        public bool IsRaceInUse(int id)
        {
            return this.dbContext.Characters.Any(x => x.RaceId == id);
        }

        public void Add(AddRaceViewModel raceData)
        {
            var race = new Race
            {
                Name = raceData.Name
            };

            this.dbContext.Races.Add(race);
            this.dbContext.SaveChanges();
        }

        public void Edit(int id, EditRaceViewModel raceData)
        {
            var originalRace = this.dbContext.Races.Where(x => x.Id == id).FirstOrDefault();

            originalRace.Name = raceData.Name;
            this.dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var race = this.dbContext.Races.Where(x => x.Id == id).FirstOrDefault();

            this.dbContext.Remove(race);
            this.dbContext.SaveChanges();
        }
    }
}
