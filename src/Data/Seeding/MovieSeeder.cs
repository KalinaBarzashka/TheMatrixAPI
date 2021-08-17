using System;
using System.Collections.Generic;
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

            var humans = dbContext.Races.Where(x => x.Name == "Humans").FirstOrDefault();
            var machines = dbContext.Races.Where(x => x.Name == "Machines").FirstOrDefault();
            var programs = dbContext.Races.Where(x => x.Name == "Programs").FirstOrDefault();

            var firstMovie = new Movie
            {
                Name = "The Matrix",
                ImageUrl = "https://thematrixapi.com/images/The_Matrix_1_Poster.jpg",
                MovieNumber = 1,
                MovieLength = 136,
                Director = "The Wachowskis",
                Producer = "Joel Silver",
                DistributedBy = "Warner Bros. Pictures",
                ReleaseDate = new DateTime(1999, 03, 31),
                Country = "United States",
                Language = "English",
                Budget = 63 - 000 - 000.00M,
                BoxOffice = 465 - 000 - 000.30M
            };

            dbContext.Movies.Add(firstMovie);

            var secondMovie = new Movie
            {
                Name = "The Matrix Reloaded",
                ImageUrl = "https://thematrixapi.com/images/The_Matrix_2_Poster.jpg",
                MovieNumber = 2,
                MovieLength = 138,
                Director = "The Wachowskis",
                Producer = "Joel Silver",
                DistributedBy = "Warner Bros. Pictures",
                ReleaseDate = new DateTime(2003, 05, 15),
                Country = "United States",
                Language = "English",
                Budget = 63 - 000 - 000.00M,
                BoxOffice = 739 - 000 - 000.04M
            };

            dbContext.Movies.Add(secondMovie);

            var thirdMovie = new Movie
            {
                Name = "The Matrix Revolutions",
                ImageUrl = "https://thematrixapi.com/images/The_Matrix_3_Poster.jpg",
                MovieNumber = 3,
                MovieLength = 129,
                Director = "The Wachowskis",
                Producer = "Joel Silver",
                DistributedBy = "Warner Bros. Pictures",
                ReleaseDate = new DateTime(2003, 11, 05),
                Country = "United States",
                Language = "English",
                Budget = 63 - 000 - 000.00M,
                BoxOffice = 427 - 000 - 000.03M
            };

            dbContext.Movies.Add(thirdMovie);

            dbContext.Movies.Add(new Movie
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
