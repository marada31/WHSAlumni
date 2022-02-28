using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWHSAlumni.Models
{
    public class tWHSAlumni
    {
        public int Id { get; set; }


        [StringLength(60, MinimumLength = 2, ErrorMessage ="Please enter a valid first name.")]
        [Required(ErrorMessage = "Please enter a valid first name.")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }


        [Display(Name = "Maiden Name")]
        public string? MaidenName { get; set; }


        [StringLength(60, MinimumLength = 2, ErrorMessage = "Please enter a valid last name.")]
        [Required(ErrorMessage = "Please enter a valid last name.")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }


        [Display(Name = "Passing Date")]
        [DataType(DataType.Date)]
        public DateTime PassingDate { get; set; }

        /* (187[8-9]|18[8-9]\d|19\d\d|2\d{3}|21[0]\d|210[0])               (2040|[1-2][0-9][0-9][0-9])        */
        [RegularExpression(@"^(187[8-9]|18[8-9]\d|19\d\d|20\d{2}|2100)$", ErrorMessage ="Year must be four digits from 1878")]
        [Required(ErrorMessage ="Please enter a valid year using for digits from 1878")]
       
        [Display(Name = "Class")]
        public string? TheClassAttended { get; set; }


        [StringLength(60, MinimumLength = 2, ErrorMessage = "Please enter the High School Attended.")]
        [Required(ErrorMessage = "Please enter the High School Attended.")]
        [Display(Name = "School Attended")]
        public string? HighSchool { get; set; }
    }
}