using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class AllocateClassrooms
    {

        public int Id { set; get; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Your Department")]
        [DisplayName("Department")]
        public int DepartmentId { set; get; }

        [Required(ErrorMessage = "Select Your Course")]
        [DisplayName("Course")]
        public int CourseId { set; get; }

        [Required(ErrorMessage = "Select Your Room No")]
        [DisplayName("Room")]
        public int RoomNoId { set; get; }

        [Required(ErrorMessage = "Select Your Day")]
        [DisplayName("Day")]
        public int DayId { set; get; }

        [DataType(DataType.Time)]
        public DateTime FromTime { set; get; }

        [DataType(DataType.Time)]
        public DateTime  ToTime { set; get; }

        public virtual List<Room> Room { get; set; }

        public AllocateClassrooms(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public AllocateClassrooms()
        {
            
        }


 


        public AllocateClassrooms(int id, int roomnoId, int dayId, DateTime ftime, DateTime ttime)
        {
            this.Id = id;
            this.RoomNoId = roomnoId;
            this.DayId = dayId;
            this.FromTime = ftime;
            this.ToTime = ttime;
        }
    }
}