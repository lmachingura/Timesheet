using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimesheetApp.Web.Data;
using TimesheetApp.Web.Models;

public static class DbSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        string[] roles = { "Admin", "Manager", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        if (!await db.Organisations.AnyAsync())
        {
            var org = new Organisation { Name = "Default Org" };
            db.Organisations.Add(org);
            await db.SaveChangesAsync();

            // Create users
            var users = new[]
            {
                new { Email = "lmachingura@gmail.com", Role = "Admin", Password = "Admin123!" },
                new { Email = "lovemore.machingura@hotmail.com", Role = "Manager", Password = "Manager123!" },
                new { Email = "love.machingura@outlook.com", Role = "User", Password = "User123!" }
            };

            foreach (var entry in users)
            {
                if (await userManager.FindByEmailAsync(entry.Email) == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = entry.Email,
                        Email = entry.Email,
                        EmailConfirmed = true//,
                        //OrganisationId = org.Id
                    };

                    var result = await userManager.CreateAsync(user, entry.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, entry.Role);
                    }
                }
            }
        }
    }
}
