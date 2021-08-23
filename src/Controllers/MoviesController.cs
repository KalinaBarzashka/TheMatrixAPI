namespace TheMatrixAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using TheMatrixAPI.Models;
    using TheMatrixAPI.Models.DTO;
    using TheMatrixAPI.Models.Movie;
    using TheMatrixAPI.Services;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using TheMatrixAPI.Models.DbModels;
    using System.Threading.Tasks;

    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;
        private readonly IIPTokenMiddlewareService iPTokenMiddlewareService;
        private readonly UserManager<ApplicationUser> userManager;

        public MoviesController(IMoviesService moviesService, IIPTokenMiddlewareService iPTokenMiddlewareService, UserManager<ApplicationUser> userManager)
        {
            this.moviesService = moviesService;
            this.iPTokenMiddlewareService = iPTokenMiddlewareService;
            this.userManager = userManager;
        }

        [Route("/movies")]
        public IActionResult Index()
        {
            var movies = this.moviesService
                .GetAll<MovieDTO>()
                .OrderBy(x => x.MovieNumber);
            return this.View(movies);
        }

        [Route("/api/movies")]
        public async Task<IActionResult> GetAllInJSON()
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

        [HttpGet]
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
                this.moviesService.Edit(id, movieData);
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

        [HttpGet]
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

            var movie = this.moviesService.GetById<DeleteMovieViewModel>(id);
            return this.View(movie);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult PostDelete(int id)
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
