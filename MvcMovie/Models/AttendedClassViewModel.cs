using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcWHSAlumni.Models
{
    public class AttendedClassResultsViewModel
    {
        public List<tWHSAlumni>? PassedAlumni { get; set; }

        public SelectList? AttendedClass { get; set; }

        public SelectList? LastNameClass { get; set; }

        public string? AttendedClassResults { get; set; }

        public string? LastNameResults { get; set; }

        public string? SearchString { get; set; }
    }
}
