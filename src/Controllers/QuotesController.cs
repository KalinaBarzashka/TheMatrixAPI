namespace TheMatrixAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using TheMatrixAPI.Models.DTO.Quote;
    using TheMatrixAPI.Services;

    public class QuotesController : Controller
    {
        private readonly IQuotesService quotesService;

        public QuotesController(IQuotesService quotesService)
        {
            this.quotesService = quotesService;
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
    }
}
