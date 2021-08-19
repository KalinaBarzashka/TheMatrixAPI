namespace TheMatrixAPI.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using TheMatrixAPI.Models;
    using TheMatrixAPI.Models.Character;
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
        public ActionResult Index()
        {
            var characters = this.charactersService.GetAllGroups();
            return View(characters);
        }

        public ActionResult Add()
        {
            var races = this.racesService.GetAll<RaceDTO>();
            this.ViewData["Races"] = races;

            return View();
        }

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

        // GET: CharactersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CharactersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CharactersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CharactersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CharactersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
