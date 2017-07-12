using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Result
    {
        public int Id { set; get; }
        [Required]
        [DisplayName("Student")]
        public int StudentId { set; get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        [Required]
        [DisplayName("Course")]

        public int CourseId { set; get; }
         [Required]
         [DisplayName("Grade")]
        public int GradeId { set; get; }

    }
}