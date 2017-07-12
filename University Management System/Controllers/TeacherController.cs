using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_System.BLL;
using University_Management_System.Models;

namespace University_Management_System.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManager teacherManager = new TeacherManager();
        //
        // GET: /Teacher/
        public ActionResult Save()
        {
            var designationList = GetDesignationList();
            ViewBag.designations = designationList;


            var departmentList = GetDepartmentList();
            ViewBag.departments = departmentList;

            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            var designationList = GetDesignationList();
            ViewBag.designations = designationList;


            var departmentList = GetDepartmentList();
            ViewBag.departments = departmentList;

            string message = teacherManager.Insert(teacher);
            ViewBag.message = message;


            return View();
        }

        [HttpGet]
        public ActionResult CourseAssign(  )
        {
            
            ViewBag.allDepartments = GetDepartmentList();
            ViewBag.teacherlist ="";
        
            return View();
        }
        [HttpPost]
        public ActionResult CourseAssign( int  department)
        {
            ViewBag.allDepartments = GetDepartmentList();
            List<Teacher> aLlteacher = teacherManager.GetAllTeacher(department);


            List<SelectListItem> TeacherList = new List<SelectListItem>();
            foreach (var aTeacher in aLlteacher)
            {
                TeacherList.Add(new SelectListItem() { Value = aTeacher.Id.ToString(), Text = aTeacher.Name });
            
            }
            ViewBag.teacherlist = TeacherList;
             

            return View( );


        }



        private List<SelectListItem> GetDepartmentList()
        {
            List<Department> teacherDepartmentList = teacherManager.GetAllDepartment();
            List<SelectListItem> departmentList = new List<SelectListItem>();
            foreach (var item in teacherDepartmentList)
            {
                departmentList.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return departmentList;
        }

        private List<SelectListItem> GetDesignationList()
        {
            List<TeacherDesignation> teacherDesignationList = teacherManager.GetAllDesignation();
            List<SelectListItem> designationList = new List<SelectListItem>();
            foreach (var item in teacherDesignationList)
            {
                designationList.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return designationList;
        }
    }
}