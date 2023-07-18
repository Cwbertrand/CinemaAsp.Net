using CrudApplication.Models;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext") 
    ?? throw new InvalidOperationException("Connection string 'MovieContext' not found.")));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

//Adding services to seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// adding route for razor pages
//app.MapRazorPages();

app.Run();
