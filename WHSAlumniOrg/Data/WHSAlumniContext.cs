#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcWHSAlumni.Models;

namespace MvcWHSAlumni.Data
{
    public class MvcWHSAlumniContext : DbContext
    {
        public MvcWHSAlumniContext (DbContextOptions<MvcWHSAlumniContext> options)
            : base(options)
        {
        }

        public DbSet<MvcWHSAlumni.Models.tWHSAlumni> tWHSAlumni { get; set; }
    }
}
