using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using STap2Go_Licenses.Context;
using STap2Go_Licenses.Entities;
using STap2Go_Licenses.Roles;

namespace STap2Go_Licenses.Helpers
{
    public static class Seed
    {
        public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, LicensesContext context)
        {
            SeedRoles(roleManager);
            SeedAdmin(userManager);
            SeedTestClient(userManager);
            BringAllData(userManager, context);
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
    
        private static void SeedTestClient(UserManager<User> userManager)
        {
            // Check if test client exists
            if (userManager.FindByEmailAsync("sharontaymarin@gmail.com").Result == null)
            {
                var testClient = new User
                {
                    UserName = "sharontaymarin@gmail.com",
                    Email = "sharontaymarin@gmail.com",
                    FirstName = "Sharon",
                    LastName = "Marin",
                    Address1 = "NA",
                    PostalCode = "NA",
                    City = "NA",
                    Country = "NA",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(testClient, "holiholi").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(testClient, Role.Admin.ToString()).Wait();
                }
            }
        }

        private static void BringAllData(UserManager<User> userManager, LicensesContext context)
        {
            var clients = context.Clients.Include(c => c.Licenses).ToList();

            foreach (var client in clients)
            {
                if (userManager.FindByEmailAsync(client.Email).Result == null)
                {
                    var newClient = new User
                    {
                        UserName = client.Email,
                        Email = client.Email,
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        IsCompany = client.IsCompany,
                        ContactNIF = client.ContactNIF,
                        CompanyName = client.CompanyName,
                        CompanyNIF = client.CompanyNIF,
                        Address1 = client.Address1,
                        Address2 = client.Address2,
                        PostalCode = client.PostalCode,
                        City = client.City,
                        Country = client.Country,
                        EmailConfirmed = true
                    };

                    // Generate random password
                    string password = RandomString(6);

                    IdentityResult result = userManager.CreateAsync(newClient, password).Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(newClient, Role.Client.ToString()).Wait();
                    }

                    foreach (var license in client.Licenses)
                    {
                        var newLicense = new Licenses
                        {
                            ClientId = newClient.Id,
                            LicenseCode = license.LicenseCode,
                            Status = license.Status,
                            CreationDate = license.CreationDate,
                            AssignmentDate = license.AssignmentDate,
                            UsageDate = license.UsageDate,
                            ProductId = license.ProductId,
                            Metadata = license.Metadata
                        };

                        context.License.Add(newLicense);
                    }

                    context.SaveChanges();
                }
            }   
        }

        private static string RandomString(int length)
        {
            Random random = new();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
