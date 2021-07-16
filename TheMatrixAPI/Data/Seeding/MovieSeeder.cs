using System;
using System.Linq;
using System.Threading.Tasks;
using TheMatrixAPI.Models.DbModels;

namespace TheMatrixAPI.Data.Seeding
{
    public class MovieSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Movies.Any())
            {
                return;
            }

            await dbContext.Movies.AddAsync(new Movie 
            { 
                Name = "The Matrix",
                MovieNumber = 1,
                MovieLength = 136,
                Director = "The Wachowskis",
                Producer = "Joel Silver",
                DistributedBy = "Warner Bros. Pictures",
                ReleaseDate = new DateTime(1999, 03, 31),
                Country = "United States",
                Language = "English",
                Budget = 63-000-000.00M,
                BoxOffice = 465-000-000.30M
            });

            await dbContext.Movies.AddAsync(new Movie
            {
                Name = "The Matrix Reloaded",
                MovieNumber = 2,
                MovieLength = 138,
                Director = "The Wachowskis",
                Producer = "Joel Silver",
                DistributedBy = "Warner Bros. Pictures",
                ReleaseDate = new DateTime(2003, 05, 15),
                Country = "United States",
                Language = "English",
                Budget = 63-000-000.00M,
                BoxOffice = 739-000-000.04M
            });

            await dbContext.Movies.AddAsync(new Movie
            {
                Name = "The Matrix Revolutions",
                MovieNumber = 3,
                MovieLength = 129,
                Director = "The Wachowskis",
                Producer = "Joel Silver",
                DistributedBy = "Warner Bros. Pictures",
                ReleaseDate = new DateTime(2003, 11, 05),
                Country = "United States",
                Language = "English",
                Budget = 63-000-000.00M,
                BoxOffice = 427-000-000.03M
            });

            await dbContext.Movies.AddAsync(new Movie
            {
                Name = "The Matrix 4",
                MovieNumber = 4,
                MovieLength = 0,
                Director = "Lana Wachowski",
                Producer = "Lana Wachowski and Grant Hill",
                DistributedBy = "Warner Bros. Pictures",
                ReleaseDate = new DateTime(2021, 12, 22),
                Country = "United States",
                Language = "English",
                Budget = 0.00M,
                BoxOffice = 0.00M
            });
        }
    }
}
