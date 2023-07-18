
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using System;

namespace CrudApplication.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                //Look for any movie
                if(context.Movies.Any())
                {
                    return; //DB has been seeded
                }
                context.Movies.AddRange(
                    new Movies
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-02-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R",
                    },
                    new Movies
                    {
                        Title = "Ghostbuster",
                        ReleaseDate = DateTime.Parse("1984-03-13"),
                        Genre = "Comedy",
                        Price = 8.98M,
                        Rating = "R",
                    },
                    new Movies
                    {
                        Title = "Ghostbuster 2",
                        ReleaseDate = DateTime.Parse("1986-02-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "R",
                    },
                    new Movies
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-04-15"),
                        Genre = "Western",
                        Price = 3.56M,
                        Rating = "R",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
