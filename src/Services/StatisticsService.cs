namespace TheMatrixAPI.Services
{
    using System.Linq;
    using TheMatrixAPI.Data;
    using TheMatrixAPI.Models.Home;

    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext dbContext;

        public StatisticsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetStatistics(StatisticsViewModel viewModel)
        {
            viewModel.Movies = this.dbContext.Movies.Count();
            viewModel.Actors = this.dbContext.Actors.Count();
            viewModel.Characters = this.dbContext.Characters.Count();
            viewModel.Quotes = this.dbContext.Quotes.Count();
            viewModel.Races = this.dbContext.Races.Count();
        }
    }
}
