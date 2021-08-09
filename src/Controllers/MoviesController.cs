namespace TheMatrixAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using TheMatrixAPI.Models;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Models.DTO;
    using TheMatrixAPI.Models.Movie;
    using TheMatrixAPI.Services;

    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [Route("/movies")]
        public IActionResult GetAll()
        {
            var movies = this.moviesService.GetAll<MovieDTO>();
            return this.View(movies);
        }

        [Route("/api/movies")]
        public IActionResult GetAllInJSON()
        {
            var movies = this.moviesService.GetAll<MovieDTO>();
            return this.Json(movies);
        }

        [Route("/api/movies/{id}")]
        public IActionResult GetOneByIdInJSON(int id)
        {
            var movie = this.moviesService.GetById<MovieDTO>(id);
            return this.Json(movie);
        }

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

            try
            {
                this.moviesService.Add(movieData);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return Redirect("/movies");
        }

        public IActionResult Edit(int id)
        {
            var movieExists = this.moviesService.DoesMovieExist(id);

            if (!movieExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Movie not found!"
                };
                return this.View("Errors", errorModel);
            }

            var movie = this.moviesService.GetById<EditMovieViewModel>(id);
            return this.View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditMovieViewModel movieData)
        {
            var movieExists = this.moviesService.DoesMovieExist(id);

            if (!movieExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Movie not found!"
                };
                return this.View("/Errors", errorModel);
            }

            if (!ModelState.IsValid)
            {
                return this.View(movieData);
            }

            try
            {
                this.moviesService.Edit(movieData, id);
            }
            catch(Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return Redirect("/movies");
        }

        public IActionResult Delete(int id)
        {
            var movieExists = this.moviesService.DoesMovieExist(id);

            if (!movieExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Movie not found!"
                };
                return this.View("Errors", errorModel);
            }

            var movie = this.moviesService.GetById<Movie>(id);
            return this.View(movie);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult PostDelete(int id)
        {
            try
            {
                this.moviesService.DeleteById(id);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return Redirect("/movies");
        }
    }
}
