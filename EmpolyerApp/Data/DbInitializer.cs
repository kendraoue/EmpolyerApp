using EmpolyerApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using static EmpolyerApp.Models.AppSecerts;

namespace EmpolyerApp.Data
{
    public class DbInitializer
    {
        public static AppSecrets appSecrets { get; set; }
        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var appSecrets = serviceProvider.GetRequiredService<IOptions<AppSecrets>>().Value;

            string[] roleNames = { "Manager", "Employee" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            if (userManager.FindByEmailAsync("manager@employers.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "manager@employers.com",
                    Email = "manager@employers.com",
                    FirstName = "Manager",
                    LastName = "User",
                    BirthDate = DateTime.Now.AddYears(-30)
                };

                var result = await userManager.CreateAsync(user, appSecrets.AdminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Manager");
                }
            }

            if (userManager.FindByEmailAsync("employee@employers.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "employee@employers.com",
                    Email = "employee@employers.com",
                    FirstName = "Employee",
                    LastName = "User",
                    BirthDate = DateTime.Now.AddYears(-25)
                };

                var result = await userManager.CreateAsync(user, appSecrets.MemberPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Employee");
                }
            }
        }
    }
}
