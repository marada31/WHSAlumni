using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcWHSAlumni.Data;
using System;
using System.Linq;

namespace MvcWHSAlumni.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcWHSAlumniContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcWHSAlumniContext>>()))
            {
                // Look for any deceased.
                if (context.tWHSAlumni.Any())
                {
                    return;   // DB has been seeded
                }

                context.tWHSAlumni.AddRange(
                    new tWHSAlumni
                    {
                        FirstName = "When Harry Met Sally",
                        PassingDate = DateTime.Parse("1989-2-12"),
                        TheClassAttended = "Romantic Comedy",
                        LastName = "R",
                       
                    },

                    new tWHSAlumni
                    {
                        FirstName = "Ghostbusters ",
                        PassingDate = DateTime.Parse("1984-3-13"),
                        TheClassAttended = "Comedy",
                        LastName = "M17",
                        
                    },

                    new tWHSAlumni
                    {
                        FirstName = "Ghostbusters 2",
                        PassingDate = DateTime.Parse("1986-2-23"),
                        TheClassAttended = "Comedy",
                        LastName = "PG13",
                       
                    },

                    new tWHSAlumni
                    {
                        FirstName = "Rio Bravo",
                        PassingDate = DateTime.Parse("1959-4-15"),
                        TheClassAttended = "Western",
                        LastName = "MC17",
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
