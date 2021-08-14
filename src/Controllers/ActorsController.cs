namespace TheMatrixAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheMatrixAPI.Models;
    using TheMatrixAPI.Models.Actor;
    using TheMatrixAPI.Models.DTO;
    using TheMatrixAPI.Models.DTO.Character;
    using TheMatrixAPI.Services;

    public class ActorsController : Controller
    {
        private readonly IActorsService actorsService;
        private readonly IMoviesService moviesService;
        private readonly ICharactersService charactersService;

        public ActorsController(IActorsService actorsService, IMoviesService moviesService, ICharactersService charactersService)
        {
            this.actorsService = actorsService;
            this.moviesService = moviesService;
            this.charactersService = charactersService;
        }

        [Route("/actors")]
        public IActionResult Index()
        {
            var actors = this.actorsService.GetAll<ActorDTO>().OrderBy(x => x.FullName);
            var movies = this.moviesService.GetAll<ActorMovieDTO>();

            this.ViewData["Movies"] = movies;

            return this.View(actors);
        }

        [Route("/api/actors")]
        public IActionResult GetAllJson()
        {
            var actors = this.actorsService.GetAll<ActorDTO>();
            return this.Json(actors);
        }

        [Route("/api/actors/{id}")]
        public IActionResult GetActorById(int id)
        {
            var actor = this.actorsService.GetById<ActorDTO>(id);
            return this.Json(actor);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddActorViewModel actorData)
        {
            if (!ModelState.IsValid)
            {
                return this.View(actorData);
            }

            try
            {
                this.actorsService.Add(actorData);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return this.Redirect("/actors");
        }

        public IActionResult Edit(int id)
        {
            var actorExists = this.actorsService.DoesActorExist(id);

            if (!actorExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Actor not found!"
                };
                return this.View("Errors", errorModel);
            }

            var actor = this.actorsService.GetById<EditActorViewModel>(id);
            var allMovies = this.moviesService.GetAll<ActorMovieDTO>();
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

            var characters = this.charactersService.GetAll<CharacterDTO>();
            this.ViewData["Characters"] = characters;

            return this.View(actor);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditActorViewModel actorData)
        {
            var actorExists = this.actorsService.DoesActorExist(id);
            if (!actorExists)
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

            try
            {
                this.actorsService.Edit(id, actorData);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }
            return Redirect("/actors");
        }

        public IActionResult Delete(int id)
        {
            var actorExists = this.actorsService.DoesActorExist(id);

            if (!actorExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Actor not found!"
                };
                return this.View("Errors", errorModel);
            }

            var actor = this.actorsService.GetById<DeleteActorViewModel>(id);
            return this.View(actor);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult PostDelete (int id)
        {
            var actorExists = this.actorsService.DoesActorExist(id);

            if (!actorExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Actor not found!"
                };
                return this.View("Errors", errorModel);
            }

            try
            {
                this.actorsService.DeleteById(id);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return this.Redirect("/actors");
        }
    }
}
