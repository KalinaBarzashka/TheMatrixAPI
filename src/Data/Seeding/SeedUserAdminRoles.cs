using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheMatrixAPI.Models.DbModels;

namespace TheMatrixAPI.Data.Seeding
{
    public class SeedUserAdminRoles
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

            string[] roles = new string[] { "Admin", "User" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(dbContext);

                if (!dbContext.Roles.Any(r => r.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole(role));
                }
            }

            await dbContext.SaveChangesAsync();

            var user = new ApplicationUser
            {
                FirstName = "Kalina",
                LastName = "Barzashka",
                Email = "kalina.barzashka@gmail.com",
                NormalizedEmail = "KALINA.BARZASHKA@GMAIL.COM",
                UserName = "KalinaBarzashka",
                NormalizedUserName = "KALINABARZASHKA",
                PhoneNumber = "+359877228262",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!dbContext.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "KalinaBarzashka");
                user.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(dbContext);
                var result = await userStore.CreateAsync(user);

                await AssignRoles(serviceProvider, user.Email, roles);
            }

            

            await dbContext.SaveChangesAsync();
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<ApplicationUser> _userManager = services.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }
    }
}
