using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Department
    {
        [Required (ErrorMessage = "Please insert the Code number first !!")]
        [StringLength(7, MinimumLength = 2, ErrorMessage =  "The Code is a minimum length of 2 and a maximum length of 7.")]
        public string Code { get; set; }
        [Required (ErrorMessage = "Please insert the Name first !!")]
        public string Name { get; set; }

        public int Id { get; set; }



        public Department(string Code, string Name)
        {
            this.Code = Code;
            this.Name = Name;
        }

        public Department()
        {
            
        }

        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    


    }
}