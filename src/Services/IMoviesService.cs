namespace TheMatrixAPI.Services
{
    using System.Collections.Generic;
    using TheMatrixAPI.Models.Actor;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Models.Movie;

    public interface IMoviesService
    {
        public bool DoesMovieExist(int id);

        public IEnumerable<T> GetAll<T>();

        public T GetById<T>(int id);

        public List<ActorMovieViewModel> GetAllMoviesForSpecifiedActor(int actorId);

        public void Add(AddMovieViewModel movieData);

        public void Edit(int id, EditMovieViewModel movieData);

        public void DeleteById(int id);
    }
}
