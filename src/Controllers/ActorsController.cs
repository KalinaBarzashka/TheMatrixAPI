﻿namespace TheMatrixAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheMatrixAPI.Models;
    using TheMatrixAPI.Models.Actor;
    using TheMatrixAPI.Models.DTO;
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

        [Authorize(Roles = "Admin")]
        [Route("/actors")]
        public IActionResult Index()
        {
            var actors = this.actorsService.GetAll<ActorDTO>().OrderBy(x => x.FullName);
            var movies = this.moviesService.GetAll<ActorMovieDTO>();

            this.ViewData["Movies"] = movies;

            return this.View(actors);
        }

        [Route("/api/actors")]
        [HttpGet]
        [HttpPost]
        public IActionResult GetAllJson()
        {
            var actors = this.actorsService.GetAll<ActorDTO>();
            return this.Json(actors);
        }

        [Route("/api/actors/{id}")]
        [HttpGet]
        [HttpPost]
        public IActionResult GetActorById(int id)
        {
            var actor = this.actorsService.GetById<ActorDTO>(id);
            return this.Json(actor);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        [Authorize(Roles = "Admin")]
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
                }); ;
            }

            this.ViewData["Movies"] = movies;

            var characters = this.charactersService.GetAll<ActorCharacterDTO>();
            this.ViewData["Characters"] = characters;

            return this.View(actor);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
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

            if (!this.charactersService.IsCharacterAvailable(actorData.Id, actorData.Character.Id))
            {
                this.ModelState.AddModelError(nameof(actorData.Character.Id), "Selected character is already in use!");
            }

            if (!ModelState.IsValid)
            {
                var characters = this.charactersService.GetAll<ActorCharacterDTO>();
                this.ViewData["Characters"] = characters;

                actorData.Movies = this.moviesService.GetAllMoviesForSpecifiedActor(actorData.Id);

                var allMovies = this.moviesService.GetAll<ActorMovieDTO>();
                var movies = new List<CheckedMoviesViewModel>();

                foreach (var movie in allMovies)
                {
                    movies.Add(new CheckedMoviesViewModel
                    {
                        Id = movie.Id,
                        Name = movie.Name,
                        IsChecked = actorData.Movies.Any(x => x.Id == movie.Id) ? true : false
                    }); ;
                }

                this.ViewData["Movies"] = movies;

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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
