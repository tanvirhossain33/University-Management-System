using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_System.BLL;
using University_Management_System.DAL;
using University_Management_System.Models;


namespace University_Management_System.Controllers
{
    public class StudentController : Controller
    {
        StudentManager studentManager = new StudentManager();
        StudentGateWay studentGateWay = new StudentGateWay();
        public ActionResult RegStudent()
        {
            var allDepList = GetDepartmentList();
            ViewBag.ALLDepartment = allDepList;
            
            return View(new Student{Date = DateTime.Today});

            }


        [HttpPost]
        public ActionResult RegStudent(Student aStudent)
        {
 

            int year = aStudent.Date.Year;
            int count = studentGateWay.CountAllStudent(aStudent.DepartmentId, year);
            int Counts = count + 1;
            string code = studentGateWay.GetDepartmentCode(aStudent.DepartmentId);
            

            string regNO = "";

            if (Counts < 10)
            {
                regNO = code + "-" + aStudent.Date.Year + "-" + "00" + Counts;
                
            }
            else if (Counts < 100 && Counts >= 10)
            {

                regNO = code + "-" + aStudent.Date.Year + "-" + "0" + Counts;

            }

            else
            {
                regNO = code + "-" + aStudent.Date.Year + "-" + Counts;

            }


            string mess = studentManager.Insert(aStudent, regNO, aStudent.Date.Year);
            string RegNomess =" Your Reg No is :" + regNO;

            string FullMess = "Name : " + aStudent.Name + "  ,   " + RegNomess + " ,  Email  : " + aStudent.Email +
                              "  ,  Department  :  " + code + "  !";

            if (mess == "Email Already Exixts")
            {
                ViewBag.message = mess;
                ViewBag.fullmess = null;
                //ViewBag.Name = null;
                //ViewBag.RegNo = null;
                //ViewBag.Email = null;
                //ViewBag.ContactNo = null;
                //ViewBag.Address = null;

            }
            else
            {
                ViewBag.message = mess;
                ViewBag.fullmess = FullMess;
                //ViewBag.StInfo = "Student Information";
                //ViewBag.Name = aStudent.Name;
                //ViewBag.RegNo = RegNomess;
                //ViewBag.Email =aStudent.Email  ;
                //ViewBag.ContactNo = aStudent.ContactNumber;
                //ViewBag.Address = aStudent.Address;
                //ViewBag.Code = code;
            }


            var allDepList = GetDepartmentList();
            ViewBag.ALLDepartment = allDepList;
            

            return View();
        }


        private List<SelectListItem> GetDepartmentList()
        {
            List<Department> getDepartmentList = studentManager.GetAllDepartment();

            List<SelectListItem> departmentList = new List<SelectListItem>();
            foreach (var adepartment in getDepartmentList)
            {
                departmentList.Add(new SelectListItem() { Value = adepartment.Id.ToString(), Text = adepartment.Name });
            }
            return departmentList;
        }


    }
}