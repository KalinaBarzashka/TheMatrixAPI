using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMatrixAPI.Data;
using TheMatrixAPI.Models;
using TheMatrixAPI.Models.DbModels;
using TheMatrixAPI.Models.DTO;

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
        public IActionResult Add(string data)
        {
            return Ok();
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
