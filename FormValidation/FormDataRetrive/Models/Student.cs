using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormDataRetrive.Models
{
    public class Student
    {
        [Required][MaxLength(10, ErrorMessage = "name must be within 10 character")]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-\d$", ErrorMessage = "index format should be in xx-xxxxx-x.")]
        public string index { get; set; }

        [Required]
        [Email]
        public string email { get; set; }


        //[Required]
        public string age { get; set; }


       // [Required]
        public string department { get; set; }
    }
}