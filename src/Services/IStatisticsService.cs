namespace TheMatrixAPI.Services
{
    using TheMatrixAPI.Models.Home;

    public interface IStatisticsService
    {
        public void GetStatistics(StatisticsViewModel viewModel);
    }
}
