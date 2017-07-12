using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class EnrollCourse
    {

        public int Id { set; get; }
        [DisplayName("Student Reg. No.")]
        public int StudentId { set; get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        [DisplayName("Select Course")]
        public int CourseId { set; get; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { set; get; }

        public EnrollCourse(int courseId, string name)
        {
            this.Id = courseId;
            this.Name = name;
        }
        
        public EnrollCourse()
        {

        }


    }
}