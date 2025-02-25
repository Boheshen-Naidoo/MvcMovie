using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
               new Movie
               {
                   Title = "When Harry Met Sally",
                   ReleaseDate = DateTime.Parse("1984-1-11"),
                   Genre = "Romantic Comedy",
                   Rating = "R",
                   Price = 7.99M
               },
                new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1984-6-8"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
               new Movie
               {
                   Title = "Ghostbusters 2",
                   ReleaseDate = DateTime.Parse("1989-6-16"),
                   Genre = "Romantic Comedy",
                   Rating = "R",
                   Price = 7.99M
               },
               new Movie
               {
                   Title = "Rio Bravo",
                   ReleaseDate = DateTime.Parse("1959-3-18"),
                   Genre = "Romantic Comedy",
                   Rating = "R",
                   Price = 7.99M
               }
            );
            context.SaveChanges();
        }
    }
}