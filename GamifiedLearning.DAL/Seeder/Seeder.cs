using GamifiedLearning.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace GamifiedLearning.DAL.Seeder
{
    public static class Seeder
    {
        public static async Task SeedData(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            using var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<GamifiedLearningDBContext>();

            await SeedRolesAsync(roleManager);
            await SeedUserAsync(userManager);
            await SeedLessonsAsync(context);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "User", "Admin" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    var roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!roleResult.Succeeded)
                    {
                        Console.WriteLine($"Error creating role: {roleName}");
                    }
                    else
                    {
                        Console.WriteLine($"Role created: {roleName}");
                    }
                }
                else
                {
                    Console.WriteLine($"Role {roleName} already exists.");
                }
            }
        }

        private static async Task SeedUserAsync(UserManager<User> userManager)
        {
            await CreateUserIfNotExists(userManager, "user@example.com", "User123!", "User");
            await CreateUserIfNotExists(userManager, "admin@example.com", "Admin123!", "Admin");
        }

        private static async Task CreateUserIfNotExists(UserManager<User> userManager, string email, string password, string role)
        {
            var existingUser = await userManager.FindByEmailAsync(email);
            if (existingUser == null)
            {
                var user = new User
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error creating user {email}: {error.Description}");
                    }
                }
                else
                {
                    Console.WriteLine($"User created: {email}");

                    var addRoleResult = await userManager.AddToRoleAsync(user, role);
                    if (!addRoleResult.Succeeded)
                    {
                        Console.WriteLine($"Error assigning role {role} to {email}");
                    }
                    else
                    {
                        Console.WriteLine($"Role {role} assigned to user {email}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"User {email} already exists.");

                var roles = await userManager.GetRolesAsync(existingUser);
                if (!roles.Contains(role))
                {
                    var addRoleResult = await userManager.AddToRoleAsync(existingUser, role);
                    if (!addRoleResult.Succeeded)
                    {
                        Console.WriteLine($"Error assigning role {role} to existing user {email}");
                    }
                    else
                    {
                        Console.WriteLine($"Role {role} assigned to existing user {email}");
                    }
                }
                else
                {
                    Console.WriteLine($"User {email} already has role {role}");
                }
            }
        }

        private static async Task SeedLessonsAsync(GamifiedLearningDBContext context)
        {
            if (context.Lessons.Any())
            {
                Console.WriteLine("Lessons already seeded.");
                return;
            }

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seeder", "Data", "lessons.json");
            if (!File.Exists(path))
            {
                Console.WriteLine($"Lesson seed file not found at: {path}");
                return;
            }

            var json = await File.ReadAllTextAsync(path);
            var lessons = JsonConvert.DeserializeObject<List<Lesson>>(json);

            context.Lessons.AddRange(lessons);
            await context.SaveChangesAsync();

            Console.WriteLine($"Seeded {lessons.Count} lessons.");
        }
    }
}