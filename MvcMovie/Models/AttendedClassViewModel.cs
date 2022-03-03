using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcWHSAlumni.Models
{
    public class AttendedClassResultsViewModel
    {
        public List<tWHSAlumni>? PassedAlumni { get; set; }

        public SelectList? AttendedClass { get; set; }

        public SelectList? HighSchoolClass { get; set; }

        public string? AttendedClassResults { get; set; }

        public string? HighSchoolResults { get; set; }

        public string? SearchString { get; set; }

        public string? MaidenName { get; set; }

        public string? LastName { get; set; }

    }
}
