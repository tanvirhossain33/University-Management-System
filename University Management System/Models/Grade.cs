using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace University_Management_System.Models
{
    public class Grade
    {
        public int Id { set; get; }
        public string GradeName { set; get; }


        public Grade(int id, string grade)
        {
            this.Id = id;
            this.GradeName = grade;
        }

        public Grade()
        {

        }
    }


}
