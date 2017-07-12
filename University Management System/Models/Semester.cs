using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }

       

        public Semester(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}