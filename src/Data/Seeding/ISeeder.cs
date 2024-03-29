﻿using System;
using System.Threading.Tasks;

namespace TheMatrixAPI.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
