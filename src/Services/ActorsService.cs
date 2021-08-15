namespace TheMatrixAPI.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using TheMatrixAPI.Data;
    using TheMatrixAPI.Models.Actor;
    using TheMatrixAPI.Models.DbModels;

    public class ActorsService : IActorsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ActorsService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public bool DoesActorExist(int id)
        {
            var actor = this.dbContext.Actors.Where(x => x.Id == id).FirstOrDefault();

            if (id == 0 || actor == null)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var acotrs = dbContext.Actors
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
            return acotrs;
        }

        public T GetById<T>(int id)
        {
            var actor = dbContext.Actors
               .Where(x => x.Id == id)
               .ProjectTo<T>(this.mapper.ConfigurationProvider)
               .FirstOrDefault();

            return actor;
        }

        public void Add(AddActorViewModel actorData)
        {
            var actor = new Actor
            {
                FirstName = actorData.FirstName,
                MiddleName = actorData.MiddleName,
                LastName = actorData.LastName
            };

            this.dbContext.Actors.Add(actor);
            this.dbContext.SaveChanges();
        }

        public void Edit(int id, EditActorViewModel actorData)
        {
            var originalActor = this.dbContext.Actors.Where(x => x.Id == id).FirstOrDefault();

            originalActor.FirstName = actorData.FirstName;
            originalActor.MiddleName = actorData.MiddleName;
            originalActor.LastName = actorData.LastName;
            originalActor.CharacterId = actorData.Character.Id;

            var character = this.dbContext.Characters.Where(x => x.Id == actorData.Character.Id).FirstOrDefault();
            character.ActorId = id;
            
            var movies = new List<Movie>();
            if (actorData.CheckedMovies != null)
            {
                foreach (var movieId in actorData.CheckedMovies)
                {
                    var dbMovie = this.dbContext.Movies.Where(x => x.Id == movieId).FirstOrDefault();
                    movies.Add(dbMovie);
                };
            }

            this.dbContext.Database.ExecuteSqlRaw($"Delete FROM ActorMovie WHERE ActorsId = {actorData.Id}");
            originalActor.Movies = movies;

            this.dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var actor = this.dbContext.Actors.Where(x => x.Id == id).FirstOrDefault();
            this.dbContext.Actors.Remove(actor);
            this.dbContext.SaveChanges();
        }
    }
}
