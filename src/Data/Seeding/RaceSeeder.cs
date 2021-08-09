using System;
using System.Linq;
using System.Threading.Tasks;
using TheMatrixAPI.Models.DbModels;

namespace TheMatrixAPI.Data.Seeding
{
    public class RaceSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Races.Any())
            {
                return;
            }

            var humans = new Race
            {
                Name = "Humans"
            };

            var machines = new Race
            {
                Name = "Machines"
            };

            var programs = new Race
            {
                Name = "Programs"
            };

            dbContext.Races.Add(humans);
            dbContext.Races.Add(machines);
            dbContext.Races.Add(programs);

            await dbContext.SaveChangesAsync();
        }
    }
}
