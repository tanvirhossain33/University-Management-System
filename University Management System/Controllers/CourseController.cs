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
    public class CourseController : Controller
    {
        AssignCourseManager assignCourseManager = new AssignCourseManager();

        CourseManager courseManager = new CourseManager();
       
        public ActionResult Save()
        {
            var depertments = GetDepartmentList();
            ViewBag.depertments = depertments;

            var semesters = GetSemesterList();
            ViewBag.semesters = semesters;

            return View();
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {
            var depertments = GetDepartmentList();
            ViewBag.depertments = depertments;

            var semesters = GetSemesterList();
            ViewBag.semesters = semesters;
            if (course.Description == null)
            {
                course.Description = "";
            }

            string message = courseManager.Insert(course);
            ViewBag.message = message;
            
            return View();
        }

        private List<SelectListItem> GetSemesterList()
        {
            List<Semester> semesterList = courseManager.GetGetAllSemester();
            List<SelectListItem> semesters = new List<SelectListItem>();
            foreach (var item in semesterList)
            {
                semesters.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return semesters;
        }

        private List<SelectListItem> GetDepartmentList()
        {
            List<Department> departmentList = courseManager.GetAllDepartment();
            List<SelectListItem> depertments = new List<SelectListItem>();
            foreach (var item in departmentList)
            {
                depertments.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return depertments;
        }

        public ActionResult Show()
        {
            ViewBag.listOfDepartments = assignCourseManager.GetAllDepartment();
            return View();
        }

        public JsonResult GetAssignInfoForShow(int deptId)
        {
            var assignList = assignCourseManager.GetCourseAssignInfo();
            var assign = assignList.Where(m => m.Department == deptId).ToList();
            foreach (var course in assign)
            {
                if (course.AssignTo.Length < 1)
                {
                    course.AssignTo = "Not Assigned Yet";
                }
            }
            return Json(assign, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClassSchedule()
        {
            ViewBag.listOfDepartments = assignCourseManager.GetAllDepartment();
            return View();

        }

	}
}