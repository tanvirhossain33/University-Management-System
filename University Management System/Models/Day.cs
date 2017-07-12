using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Day
    {
          public string Name { get; set; }

        public int Id { get; set; }

        public Day(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}