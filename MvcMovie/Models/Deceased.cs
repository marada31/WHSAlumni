using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWHSAlumni.Models
{
    public class tWHSAlumni
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }


        [Display(Name = "Maiden Name")]
        public string? MaidenName { get; set; }


        [Display(Name = "Last Name")]
        public string? LastName { get; set; }


        [Display(Name = "Passing Date")]
        [DataType(DataType.Date)]
        public DateTime PassingDate { get; set; }


        [Display(Name = "Class")]
        public string? TheClassAttended { get; set; }


    }
}