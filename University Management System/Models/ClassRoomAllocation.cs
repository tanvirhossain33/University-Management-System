using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class ClassRoomAllocation
    {
        public int Id { set; get; }
        public int DepartmentId { set; get; }
        public int CourseId { set; get; }
        public int DayId { set; get; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime TimeFrom { set; get; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime TimeTo { set; get; }


    }
}