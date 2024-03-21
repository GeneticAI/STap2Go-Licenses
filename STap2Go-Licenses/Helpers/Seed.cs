using Microsoft.AspNetCore.Identity;
using STap2Go_Licenses.Entities;
using STap2Go_Licenses.Roles;

namespace STap2Go_Licenses.Helpers
{
    public static class Seed
    {
        public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedAdmin(userManager);
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Check if admin role exists
            if (!roleManager.RoleExistsAsync(Role.Admin.ToString()).Result)
            {
                // Create admin role
                IdentityRole adminRole = new(Role.Admin.ToString());
                IdentityResult roleResult = roleManager.CreateAsync(adminRole).Result;
            }

            // Check if client role exists
            if (!roleManager.RoleExistsAsync(Role.Client.ToString()).Result)
            {
                // Create client role
                IdentityRole clientRole = new(Role.Client.ToString());
                IdentityResult roleResult = roleManager.CreateAsync(clientRole).Result;
            }
        }

        private static void SeedAdmin(UserManager<User> userManager)
        {
            // Check if admin user exists
            if(userManager.FindByEmailAsync("smarin@geneticai.com").Result == null)
            {
                var adminUser = new User
                {
                    UserName = "smarin@geneticai.com",
                    Email = "smarin@geneticai.com",
                    FirstName = "Sharon",
                    LastName = "Marin",
                    Address1 = "NA",
                    PostalCode = "NA",
                    City = "NA",
                    Country = "NA",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(adminUser, "holiholi").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, Role.Admin.ToString()).Wait();
                }
            }
        }
    }
}
