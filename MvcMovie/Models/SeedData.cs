﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any deceased.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        FirstName = "When Harry Met Sally",
                        PassingDate = DateTime.Parse("1989-2-12"),
                        TheClassAttended = "Romantic Comedy",
                        LastName = "R",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        FirstName = "Ghostbusters ",
                        PassingDate = DateTime.Parse("1984-3-13"),
                        TheClassAttended = "Comedy",
                        LastName = "M17",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        FirstName = "Ghostbusters 2",
                        PassingDate = DateTime.Parse("1986-2-23"),
                        TheClassAttended = "Comedy",
                        LastName = "PG13",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        FirstName = "Rio Bravo",
                        PassingDate = DateTime.Parse("1959-4-15"),
                        TheClassAttended = "Western",
                        LastName = "MC17",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
