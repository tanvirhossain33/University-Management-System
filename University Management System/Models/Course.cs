using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Course
    {
      

        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The Code must be at least five (5) characters long !!")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.5, 5.0, ErrorMessage = "Credit range is from 0.5 to 5.0 !!")]
        public double Credit { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public int Department { get; set; }
        [Required]
        public int Semester { get; set; }
        [DisplayName("Course")]
        public int CourseId { set; get; }

        public virtual string SemesterName { get; set; }
        public virtual string AssignTo { get; set; }

        public virtual string RoomNo { get; set; }
        public virtual string Day { get; set; }
       [DataType(DataType.Time)]
        public virtual DateTime? FromTime { get; set; }
         [DataType(DataType.Time)]
        public virtual DateTime? ToTime { get; set; }

        public Course(int id, string courseCode, int deptId, string courseName, string roomNo, string day, DateTime? fromTime, DateTime? toTime)
        {
            this.Id = id;
            this.Code = courseCode;
            this.Department = deptId;
            this.Name = courseName;
            this.RoomNo = roomNo;
            this.Day = day;
            this.FromTime = fromTime;
            this.ToTime = toTime;
        }

        public Course()
        {
            
        }
    }
}