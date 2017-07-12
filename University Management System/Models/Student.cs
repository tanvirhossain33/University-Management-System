using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Student
    {

        [Required(ErrorMessage = "Provide A Name.")]
        public string Name { get; set; }



        //[Required(ErrorMessage = "Enter Your Email.")]
        //[EmailAddress(ErrorMessage = "Enter Your Valid Email.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { set; get; }


        [Required(ErrorMessage = "Enter Your Adress.")]
        public string Address { set; get; }



        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { set; get; }

        [RegularExpression(@"^\(?[+]([8]{2})([0]{1})([1]{1})([1-9]{1})([0-9]{8})$", ErrorMessage = "Enter valid Digits. ex. (+88017XXXXXXXX)")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(14,MinimumLength = 6, ErrorMessage = "Please Enter Valid Phone Number")]
        [Required(ErrorMessage = "Enter Your Contact Number.")]
        [DisplayName("Cotact Number")]
        public string ContactNumber { set; get; }

        [Required(ErrorMessage = "Select Your DepartMent ID.")]
        [DisplayName("Department")]
        public int DepartmentId { set; get; }
        public virtual Department Department { get; set; }
        public virtual List<StudentResult> StudentResults { get; set; }





    }
}