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

            var actor = new Actor
            {
                FirstName = "Keanu",
                MiddleName = "Charles",
                LastName = "Reeves",
            };

            await dbContext.Actors.AddAsync(actor);


        }
    }
}
