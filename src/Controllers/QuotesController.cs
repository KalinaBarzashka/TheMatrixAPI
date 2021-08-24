namespace TheMatrixAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using TheMatrixAPI.Models;
    using TheMatrixAPI.Models.DTO.Quote;
    using TheMatrixAPI.Models.Quote;
    using TheMatrixAPI.Services;

    public class QuotesController : Controller
    {
        private readonly IQuotesService quotesService;
        private readonly ICharactersService charactersService;

        public QuotesController(IQuotesService quotesService, ICharactersService charactersService)
        {
            this.quotesService = quotesService;
            this.charactersService = charactersService;
        }

        [Authorize(Roles = "Admin")]
        [Route("/quotes")]
        public IActionResult Index()
        {
            var quotes = this.quotesService
                .GetAll<QuoteDTO>()
                .OrderBy(x => x.Character.Name);

            return this.View(quotes);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            var viewModel = new AddQuoteViewModel();
            var characters = this.charactersService.GetAll<QuoteCharacterViewModel>();

            viewModel.Characters = characters;

            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddQuoteViewModel quoteData)
        {
            if (!ModelState.IsValid)
            {
                return this.View(quoteData);
            }

            try
            {
                this.quotesService.Add(quoteData);
            }
            catch (Exception ex)
            {
                var errorModel = new CustomErrorViewModel
                {
                    Message = ex.Message
                };
                return this.View("Errors", errorModel);
            }

            return Redirect("/quotes");
        }
    }
}
