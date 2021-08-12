namespace TheMatrixAPI.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using TheMatrixAPI.Data;
    using TheMatrixAPI.Models.DbModels;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
    using TheMatrixAPI.Models.Movie;
    using System;
    using System.Globalization;

    public class MoviesService : IMoviesService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public MoviesService(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public bool DoesMovieExist(int id)
        {
            var movie = this.dbContext.Movies.Where(x => x.Id == id).FirstOrDefault();

            if(id == 0 || movie == null)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var movies = dbContext.Movies
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
            return movies;
        }

        public T GetById<T>(int id)
        {
            var movie = dbContext.Movies
               .Where(x => x.Id == id)
               .ProjectTo<T>(this.mapper.ConfigurationProvider)
               .FirstOrDefault();

            return movie;
        }

        public void Add(AddMovieViewModel movieData)
        {
            var movie = new Movie
            {
                Name = movieData.Name,
                MovieNumber = movieData.MovieNumber,
                MovieLength = movieData.MovieLength,
                Director = movieData.Director,
                Producer = movieData.Producer,
                DistributedBy = movieData.DistributedBy,
                ReleaseDate = movieData.ReleaseDate == null ? null : DateTime.Parse(movieData.ReleaseDate),
                Country = movieData.Country,
                Language = movieData.Language,
                Budget = movieData.Budget,
                BoxOffice = movieData.BoxOffice,
                ImageUrl = movieData.ImageUrl
            };

            this.dbContext.Add(movie);
            this.dbContext.SaveChanges();
        }

        public void Edit(EditMovieViewModel movieData, int id)
        {
            var originalMovie = this.dbContext.Movies.Where(x => x.Id == id).FirstOrDefault();

            originalMovie.Name = movieData.Name;
            originalMovie.MovieNumber = movieData.MovieNumber;
            originalMovie.MovieLength = movieData.MovieLength;
            originalMovie.Director = movieData.Director;
            originalMovie.Producer = movieData.Producer;
            originalMovie.DistributedBy = movieData.DistributedBy;
            originalMovie.ReleaseDate = movieData.ReleaseDate == null ? null : DateTime.ParseExact(movieData.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            originalMovie.Country = movieData.Country;
            originalMovie.Language = movieData.Language;
            originalMovie.Budget = movieData.Budget;
            originalMovie.BoxOffice = movieData.BoxOffice;

            dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var movie = this.dbContext.Movies.Where(x => x.Id == id).FirstOrDefault();
            this.dbContext.Movies.Remove(movie);
            this.dbContext.SaveChanges();
        }
    }
}