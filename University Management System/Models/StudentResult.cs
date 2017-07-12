using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class StudentResult
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Course")]
        public int CourseId { get; set; }
       
        public virtual Course Course { get; set; }

         
        [Required]
        [DisplayName("Grade")]
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
    }

 
}