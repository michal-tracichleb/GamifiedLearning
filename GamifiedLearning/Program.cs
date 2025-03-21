using GamifiedLearning.BLL;
using GamifiedLearning.DAL;
using GamifiedLearning.DAL.Models;
using GamifiedLearning.DAL.Seeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GamifiedLearningDBContext>(options =>
    options.UseInMemoryDatabase("GamifiedLearningDB"));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<GamifiedLearningDBContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        Seeder.SeedData(services).Wait();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during data initialization: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();