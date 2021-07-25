using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMatrixAPI.Models.DbModels;

namespace TheMatrixAPI.Data.Seeding
{
    public class ActorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Actors.Any())
            {
                return;
            }

            var firstMovie = dbContext.Movies.Where(x => x.Id == 1).FirstOrDefault();
            var secondMovie = dbContext.Movies.Where(x => x.Id == 2).FirstOrDefault();
            var thirdMovie = dbContext.Movies.Where(x => x.Id == 3).FirstOrDefault();

            var keanu = new Actor
            {
                FirstName = "Keanu",
                MiddleName = "Charles",
                LastName = "Reeves",
            };

            var neo = dbContext.Characters.Where(x => x.Name == "Neo").FirstOrDefault();
            keanu.Character = neo;

            var laurence = new Actor
            {
                FirstName = "Laurence",
                MiddleName = "John",
                LastName = "Fishburne III",
            };

            var carrie = new Actor
            {
                FirstName = "Carrie-Anne",
                MiddleName = "",
                LastName = "Moss",
            };

            var hugo = new Actor
            {
                FirstName = "Hugo",
                MiddleName = "Wallace",
                LastName = "Weaving",
            };

            keanu.Movies.Add(firstMovie);
            keanu.Movies.Add(secondMovie);
            keanu.Movies.Add(thirdMovie);

            laurence.Movies.Add(firstMovie);
            laurence.Movies.Add(secondMovie);
            laurence.Movies.Add(thirdMovie);

            carrie.Movies.Add(firstMovie);
            hugo.Movies.Add(firstMovie);

            await dbContext.Actors.AddAsync(keanu);
            await dbContext.Actors.AddAsync(laurence);
            await dbContext.Actors.AddAsync(carrie);
            await dbContext.Actors.AddAsync(hugo);

            await dbContext.SaveChangesAsync();
        }
    }
}
