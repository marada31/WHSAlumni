using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class AttendedClassResultsViewModel
    {
        public List<Movie>? PassedAlumni { get; set; }
        public SelectList? AttendedClass { get; set; }
        public string? AttendedClassResults { get; set; }
        public string? SearchString { get; set; }
    }
}
