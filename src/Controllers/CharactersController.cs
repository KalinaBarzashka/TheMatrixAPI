namespace TheMatrixAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using TheMatrixAPI.Models;
    using TheMatrixAPI.Models.Character;
    using TheMatrixAPI.Models.DTO.Character;
    using TheMatrixAPI.Models.DTO.Race;
    using TheMatrixAPI.Services;

    public class CharactersController : Controller
    {
        private readonly ICharactersService charactersService;
        private readonly IRacesService racesService;

        public CharactersController(ICharactersService charactersService, IRacesService racesService)
        {
            this.charactersService = charactersService;
            this.racesService = racesService;
        }

        [Route("/characters")]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var characters = this.charactersService.GetAllGroups();
            return View(characters);
        }

        [Route("/api/characters")]
        [HttpGet]
        [HttpPost]
        public IActionResult GetAllJson()
        {
            var characters = this.charactersService.GetAll<CharacterDTO>();
            return this.Json(characters);
        }

        [Route("/api/characters/{id}")]
        [HttpGet]
        [HttpPost]
        public IActionResult GetActorById(int id)
        {
            var character = this.charactersService.GetById<CharacterDTO>(id);
            return this.Json(character);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            var races = this.racesService.GetAll<RaceDTO>();
            this.ViewData["Races"] = races;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddCharacterViewModel characterData)
        {
            if (!ModelState.IsValid)
            {
                return this.View(characterData);
            }

            try
            {
                this.charactersService.Add(characterData);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return Redirect("/characters");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var characterExisis = this.charactersService.DoesCharacterExist(id);

            if (!characterExisis)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Character not found!"
                };
                return this.View("Errors", errorModel);
            }

            var character = this.charactersService.GetById<EditCharacterViewModel>(id);

            var races = this.racesService.GetAll<RaceDTO>();
            this.ViewData["Races"] = races;

            return this.View(character);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCharacterViewModel characterData)
        {
            var characterExisis = this.charactersService.DoesCharacterExist(id);
        
            if (!characterExisis)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Character not found!"
                };
                return this.View("/Errors", errorModel);
            }
        
            if (!ModelState.IsValid)
            {
                var races = this.racesService.GetAll<RaceDTO>();
                this.ViewData["Races"] = races;

                return this.View(characterData);
            }
        
            try
            {
                this.charactersService.Edit(id, characterData);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }
        
            return Redirect("/characters");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var characterExists = this.charactersService.DoesCharacterExist(id);

            if (!characterExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Character not found!"
                };
                return this.View("Errors", errorModel);
            }

            var character = this.charactersService.GetById<DeleteCharacterViewModel>(id);
            return this.View(character);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(int id)
        {
            var characterExists = this.charactersService.DoesCharacterExist(id);

            if (!characterExists)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = "Character not found!"
                };
                return this.View("Errors", errorModel);
            }

            try
            {
                this.charactersService.DeleteById(id);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return Redirect("/characters");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var charactersDetails = this.charactersService.GetById<CharacterDetailsViewModel>(id);
            return this.View(charactersDetails);
        }
    }
}
