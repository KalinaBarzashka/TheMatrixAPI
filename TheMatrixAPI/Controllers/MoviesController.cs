using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using TheMatrixAPI.Data;
using TheMatrixAPI.Models.DbModels;
using TheMatrixAPI.Models.DTO;
using TheMatrixAPI.Models.Movie;

namespace TheMatrixAPI.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public MoviesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [Route("/api/movies")]
        public IActionResult GetAll()
        {
            var movies = dbContext.Movies
                .ProjectTo<MovieDTO>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.Json(movies);
        }

        [Route("/api/movies/{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = dbContext.Movies
                .Where(x => x.Id == id)
                .ProjectTo<MovieDTO>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

            return this.Json(movie);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddMovieViewModel movieData)
        {
            if (!ModelState.IsValid)
            {
                return this.View(movieData);
            }

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
            };

            this.dbContext.Add(movie);
            this.dbContext.SaveChanges();

            return Redirect("/");
        }

        //var moviesTest = dbContext.Movies
        //    .Select(x => new MovieDTO
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        MovieNumber = x.MovieNumber,
        //        MovieLength = x.MovieLength,
        //        Director = x.Director,
        //        Producer = x.Producer,
        //        DistributedBy = x.DistributedBy,
        //        ReleaseDate = x.ReleaseDate,
        //        Country = x.Country,
        //        Language = x.Language,
        //        Budget = x.Budget,
        //        BoxOffice = x.BoxOffice,
        //        Actors = x.Actors
        //            .Select(a => new MovieActorDTO
        //            {
        //                Id = a.Id,
        //                FullName = a.FullName,
        //                Url = "https://thematrixapi.com/api/actors/" + a.Id
        //            }).ToList(),
        //        Races = x.Races
        //            .Select(r => new MovieRaceDTO
        //            {
        //                Id = r.Id,
        //                Name = r.Name,
        //                Url = "https://thematrixapi.com/api/races/" + r.Id
        //            }).ToList()
        //    }).ToList();
    }
}
