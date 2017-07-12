using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_System.BLL;
using University_Management_System.Models;

namespace University_Management_System.Controllers
{
    public class AssignCourseController : Controller
    {
        AssignCourseManager assignCourseManager=new AssignCourseManager();
        
        //
        // GET: /AssignCourse/
        public ActionResult CourseAssign()
        {
            ViewBag.listOfDepartments = assignCourseManager.GetAllDepartment();
            ViewBag.listOfTeachers = assignCourseManager.GetAllTeacher();
            ViewBag.listOfCourse = assignCourseManager.GetAllCourse();
            return View();
           
        }

        [HttpPost]
        public ActionResult CourseAssign(AssignCourse assignCourse)
        {
            ViewBag.listOfDepartments = assignCourseManager.GetAllDepartment();
            ViewBag.listOfTeachers = assignCourseManager.GetAllTeacher();
            ViewBag.listOfCourse = assignCourseManager.GetAllCourse();           
            string message = assignCourseManager.InsertAssignedCourse(assignCourse);
            ViewBag.Message = message;
            return View();

        }

        private IList<Teacher> GetAllTeacher(int deptId)
        {
            return assignCourseManager.GetAllTeacher().Where(teacher => teacher.Department == deptId).ToList();
        }
        private IList<Course> GetAllCourse(int deptId)
        {
            return assignCourseManager.GetAllCourse().Where(course => course.Department == deptId).ToList();
        }

         [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetTeacherByDepartmentId(int deptId)
         {
             var teacherList = this.GetAllTeacher(deptId);
             var teacherData = teacherList.Select(m => new SelectListItem()
             {
                 Text = m.Name,
                 Value = m.Id.ToString()
             });
            return Json(teacherData, JsonRequestBehavior.AllowGet);
        }
         [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetCourseByDepartmentId(int deptId)
        {
            var courseList = this.GetAllCourse(deptId);
            var courseData = courseList.Select(m => new SelectListItem()
            {
                Text = m.Code,
                Value = m.Id.ToString()
            });
            return Json(courseData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByCourseId(int courseId)
        {
            var courseList = assignCourseManager.GetAllCourse();
            var course = courseList.Where(m => m.Id == courseId).ToList();
            return Json(course, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherByTeacherId(int teacherId)
        {
            var teacherList =assignCourseManager.GetAllTeacher();
            var teacher = teacherList.Where(m => m.Id == teacherId).ToList();
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherTakenCreditByDepartmentIdAndTeacherId(int deptId, int teacherId)
        {
            var remainingCredit = assignCourseManager.GetTeacherTakenCredit(deptId,teacherId);
            return Json(remainingCredit, JsonRequestBehavior.AllowGet);
        }
	}
}