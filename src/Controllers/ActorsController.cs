using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TheMatrixAPI.Data;
using TheMatrixAPI.Models;
using TheMatrixAPI.Models.Actor;
using TheMatrixAPI.Models.DTO;

namespace TheMatrixAPI.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ActorsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [Route("/actors")]
        public IActionResult GetAll()
        {
            var actors = this.dbContext.Actors.ProjectTo<ActorDTO>(this.mapper.ConfigurationProvider).ToList().OrderBy(x => x.FullName);
            var movies = this.dbContext.Movies.ToList();

            this.ViewData["Movies"] = movies;

            return this.View(actors);
        }

        [Route("/api/actors")]
        public IActionResult GetAllJson()
        {
            var actors = dbContext.Actors
                .ProjectTo<ActorDTO>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.Json(actors);
        }

        [Route("/api/actors/{id}")]
        public IActionResult GetActorById(int id)
        {
            var actor = dbContext.Actors
                .Where(x => x.Id == id)
                .ProjectTo<ActorDTO>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

            return this.Json(actor);
        }

        public IActionResult Edit(int id)
        {
            var actor = this.dbContext.Actors
                .ProjectTo<EditActorViewModel>(this.mapper.ConfigurationProvider)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (id == 0 || actor == null)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Actor not found!"
                };
                return this.View("Errors", errorModel);
            }

            var allMovies = this.dbContext.Movies.ToList();
            var movies = new List<CheckedMoviesViewModel>();

            foreach (var movie in allMovies)
            {
                movies.Add(new CheckedMoviesViewModel
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    IsChecked = actor.Movies.Any(x => x.Id == movie.Id) ? true : false
                });;
            }

            this.ViewData["Movies"] = movies;

            var characters = this.dbContext.Characters.ToList();
            this.ViewData["Characters"] = characters;

            return this.View(actor);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditActorViewModel actorData, CheckedMoviesViewModel[] movies)
        {
            var originalActor = dbContext.Actors.Where(x => x.Id == id).FirstOrDefault();
            if (originalActor == null)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Actor not found!"
                };
                return this.View("/Errors", errorModel);
            }

            if (!ModelState.IsValid)
            {
                return this.View(actorData);
            }
            
            //originalMovie.Name = movieData.Name;
            //originalMovie.MovieNumber = movieData.MovieNumber;
            //originalMovie.MovieLength = movieData.MovieLength;
            //originalMovie.Director = movieData.Director;
            //originalMovie.Producer = movieData.Producer;
            //originalMovie.DistributedBy = movieData.DistributedBy;
            //originalMovie.ReleaseDate = movieData.ReleaseDate == null ? null : DateTime.Parse(movieData.ReleaseDate);
            //originalMovie.Country = movieData.Country;
            //originalMovie.Language = movieData.Language;
            //originalMovie.Budget = movieData.Budget;
            //originalMovie.BoxOffice = movieData.BoxOffice;
            //
            //dbContext.SaveChanges();
            //
            return Redirect("/");
        }
    }
}
