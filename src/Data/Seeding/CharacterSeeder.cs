using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMatrixAPI.Models.DbModels;

namespace TheMatrixAPI.Data.Seeding
{
    public class CharacterSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Characters.Any())
            {
                return;
            }

            var humans = dbContext.Races.Where(x => x.Name == "Humans").FirstOrDefault();
            var machines = dbContext.Races.Where(x => x.Name == "Machines").FirstOrDefault();
            var programs = dbContext.Races.Where(x => x.Name == "Programs").FirstOrDefault();

            var neo = new Character
            {
                Name = "Neo",
                Alignment = "Good",
                Race = humans
            };

            neo.Quotes.Add(new Quote
            {
                QuoteLine = "test"
            });

            var morpheus = new Character
            {
                Name = "Morpheus",
                Alignment = "Good",
                Race = humans
            };

            var trinity = new Character
            {
                Name = "Trinity",
                Alignment = "Good",
                Race = humans
            };

            var agentSmith = new Character
            {
                Name = "Agent Smith",
                Alignment = "Bad",
                Race = programs
            };

            var cypher = new Character
            {
                Name = "Cypher",
                Alignment = "Good",
                Race = humans
            };

            var tank = new Character
            {
                Name = "Tank",
                Alignment = "Good",
                Race = humans
            };

            var dozer = new Character
            {
                Name = "Dozer",
                Alignment = "Good",
                Race = humans
            };

            var apoc = new Character
            {
                Name = "Apoc",
                Alignment = "Good",
                Race = humans
            };

            var mouse = new Character
            {
                Name = "Mouse",
                Alignment = "Good",
                Race = humans
            };

            var theOracle = new Character
            {
                Name = "The Oracle",
                Alignment = "Neutral",
                Race = programs
            };

            var @switch = new Character
            {
                Name = "Switch",
                Alignment = "Good",
                Race = humans
            };

            var agentBrown = new Character
            {
                Name = "Agent Brown",
                Alignment = "Bad",
                Race = programs
            };

            var agentJones = new Character
            {
                Name = "Agent Jones",
                Alignment = "Bad",
                Race = programs
            };

            var duJour = new Character
            {
                Name = "DuJour",
                Alignment = "Good",
                Race = humans
            };

            var choi = new Character
            {
                Name = "Choi",
                Alignment = "Good",
                Race = humans
            };

            var mrRhineheart = new Character
            {
                Name = "Mr. Rhineheart",
                Alignment = "Good",
                Race = humans
            };

            var characters = new List<Character>();
            characters.Add(neo);
            characters.Add(morpheus);
            characters.Add(trinity);
            characters.Add(agentSmith);
            characters.Add(cypher);
            characters.Add(tank);
            characters.Add(dozer);
            characters.Add(apoc);
            characters.Add(mouse);
            characters.Add(theOracle);
            characters.Add(@switch);
            characters.Add(agentBrown);
            characters.Add(agentJones);
            characters.Add(duJour);
            characters.Add(choi);
            characters.Add(mrRhineheart);

            dbContext.AddRange(characters);

            await dbContext.SaveChangesAsync();
        }
    }
}
