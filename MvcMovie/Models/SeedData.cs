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
                        FirstName = "John",
                        PassingDate = DateTime.Parse("1989-2-12"),
                        TheClassAttended = "1989",
                        LastName = "Smith",
                       
                    },

                    new tWHSAlumni
                    {
                        FirstName = "Julie",
                        PassingDate = DateTime.Parse("1984-3-13"),
                        TheClassAttended = "1949",
                        LastName = "Jones",
                        
                    },

                    new tWHSAlumni
                    {
                        FirstName = "Jerry",
                        PassingDate = DateTime.Parse("1986-2-23"),
                        TheClassAttended = "1964",
                        LastName = "Mason",
                       
                    },

                    new tWHSAlumni
                    {
                        FirstName = "ALbert",
                        PassingDate = DateTime.Parse("1959-4-15"),
                        TheClassAttended = "1968",
                        LastName = "Hirsch",
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
