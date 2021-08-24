namespace TheMatrixAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using TheMatrixAPI.Models;
    using TheMatrixAPI.Models.DTO.Race;
    using TheMatrixAPI.Models.Race;
    using TheMatrixAPI.Services;

    public class RacesController : Controller
    {
        private readonly IRacesService racesService;

        public RacesController(IRacesService racesService)
        {
            this.racesService = racesService;
        }

        [Authorize(Roles = "Admin")]
        [Route("/races")]
        public IActionResult Index()
        {
            var races = this.racesService.GetAll<RaceDTO>();

            return this.View(races);
        }

        [Route("/api/races")]
        [HttpGet]
        [HttpPost]
        public IActionResult GetAllInJSON()
        {
            var races = this.racesService.GetAll<RaceDTO>();
            return this.Json(races);
        }

        [Route("/api/races/{id}")]
        [HttpGet]
        [HttpPost]
        public IActionResult GetOneByIdInJSON(int id)
        {
            var movie = this.racesService.GetById<RaceDTO>(id);
            return this.Json(movie);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddRaceViewModel raceData)
        {
            if (!ModelState.IsValid)
            {
                return this.View(raceData);
            }

            try
            {
                this.racesService.Add(raceData);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return Redirect("/races");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var raceExists = this.racesService.DoesRaceExist(id);

            if (!raceExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Race not found!"
                };
                return this.View("Errors", errorModel);
            }

            var race = this.racesService.GetById<EditRaceViewModel>(id);
            return this.View(race);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditRaceViewModel raceData)
        {
            var raceExists = this.racesService.DoesRaceExist(id);

            if (!raceExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Race not found!"
                };
                return this.View("/Errors", errorModel);
            }

            if (!ModelState.IsValid)
            {
                return this.View(raceData);
            }

            try
            {
                this.racesService.Edit(id, raceData);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return Redirect("/races");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var raceExists = this.racesService.DoesRaceExist(id);

            if (!raceExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Race not found!"
                };
                return this.View("Errors", errorModel);
            }

            var race = this.racesService.GetById<DeleteRaceViewModel>(id);
            return this.View(race);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(int id)
        {
            var raceExists = this.racesService.DoesRaceExist(id);
            var raceIsInUse = this.racesService.IsRaceInUse(id);

            if (!raceExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Race not found!"
                };
                return this.View("Errors", errorModel);
            }

            if (!raceIsInUse)
            {
                this.ModelState.AddModelError(nameof(DeleteRaceViewModel.Name), "The race is already in use!");
            }

            try
            {
                this.racesService.DeleteById(id);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return Redirect("/races");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var raceDetails = this.racesService.GetRaceDetailsById<RaceDetailsViewModel>(id);
            return this.View(raceDetails);
        }
    }
}
