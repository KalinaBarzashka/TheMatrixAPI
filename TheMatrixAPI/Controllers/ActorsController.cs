using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TheMatrixAPI.Data;
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
    }
}
