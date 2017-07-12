using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace University_Management_System.Models
{
    public class Teacher
    {
        public Teacher(int id, string name)
        {

            this.Id = id;
            this.Name = name;
        }

        public int Id { set; get; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^\(?[+]([8]{2})([0]{1})([1]{1})([1-9]{1})([0-9]{8})$", ErrorMessage = "Enter valid Digits. ex. (+88017XXXXXXXX)")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(14, MinimumLength = 6, ErrorMessage = "Please Enter Valid Phone Number")]
        [Required]
        [DisplayName("Contact No.")]
        public string ContactNo { get; set; }
        [Required]
        [DisplayName("Designation")]
        public int Designation { get; set; }
        [Required]
        public int Department { get; set; }
        [Required]
        [DisplayName("Credit to be taken")]
        [Range(0, 1000, ErrorMessage = "Credit cannot be non-negative value!!")]
        public double Credit { get; set; }

      
        public virtual double RemainingCredit { get; set; }

        public Teacher(int id, string name, int departmentId, double creditToBeTaken, double remainCredit)
        {
            // TODO: Complete member initialization
            this.Id = id;
            this.Name = name;
            this.Department = departmentId;
            this.Credit = creditToBeTaken;
            this.RemainingCredit = remainCredit;
        }

        public Teacher(int id, string name, int departmentId, double creditToBeTaken)
        {
            // TODO: Complete member initialization
            this.Id = id;
            this.Name = name;
            this.Department = departmentId;
            this.Credit = creditToBeTaken;
        }
       
        public Teacher()
        {
            
        }
    }
}