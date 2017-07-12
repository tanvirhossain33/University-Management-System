using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Room
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public Room(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

    }
}