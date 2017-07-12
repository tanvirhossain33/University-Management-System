using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class AssignCourse
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required]
        [DisplayName("Teacher")]
        public int TeacherId { get; set; }
        [Required]
        [DisplayName("Credit To Be Taken")]
        public double CreditToBeTaken { get; set; }
        [DisplayName("Remaining Credit")]
        public double RemainingCredit { get; set; }
        [Required]
        [DisplayName("Course Code")]
        public int CourseCodeId { get; set; }
        [Required]
        [DisplayName("Course")]
        public string CourseName { get; set; }
        [Required]
        [DisplayName("Credit")]
        public double CourseCredit { get; set; }
    }
}