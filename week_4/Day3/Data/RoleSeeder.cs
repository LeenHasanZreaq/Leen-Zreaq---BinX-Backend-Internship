using Microsoft.AspNetCore.Identity;

namespace week_4.Data;

public static class RoleSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        // 1. Create roles if they don't exist yet
        string[] roles = { "User", "Admin" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // 2. Create + assign a plain "User" test account
        await EnsureUserWithRoleAsync(
            userManager,
            email: "user@test.com",
            password: "Password123",
            role: "User");

        // 3. Create + assign an "Admin" test account
        await EnsureUserWithRoleAsync(
            userManager,
            email: "admin@test.com",
            password: "Password123",
            role: "Admin");
    }

    private static async Task EnsureUserWithRoleAsync(
        UserManager<IdentityUser> userManager,
        string email,
        string password,
        string role)
    {
        var existing = await userManager.FindByEmailAsync(email);
        if (existing != null) return; // already seeded, skip

        var user = new IdentityUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, role);
        }
        else
        {
            throw new Exception(
                $"Failed to seed {email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}