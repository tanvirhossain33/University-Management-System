using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using University_Management_System.BLL;
using University_Management_System.Models;

namespace University_Management_System.Controllers
{
    public class EnrollStudentCourseController : Controller
    {
        EnrollCourseManager manager = new EnrollCourseManager();
        private ResultViewManager resultViewManager = new ResultViewManager();


        public ActionResult EnrollCourse()
        {

            var allRegList = resultViewManager.StudentsRegNo();
            ViewBag.AllRegList = allRegList;
            //ViewData["StudentId"] = allRegList;

            return View(new EnrollCourse { Date = DateTime.Now });

        }



        [HttpPost]
        public ActionResult EnrollCourse(EnrollCourse aEnrollCourse)
        {
            var allRegList = resultViewManager.StudentsRegNo();
            ViewBag.AllRegList = allRegList;

            //var allRegList = GetALlRegNo();
            //ViewData["StudentId"] = allRegList;

            string message = manager.Insert(aEnrollCourse);

            ViewBag.message = message;
            return View();
        }




        //private List<SelectListItem> GetALlRegNo()
        //{
        //    List<ResultView> aLlRegNo = resultViewManager.StudentsRegNo();
        //    List<SelectListItem> allRegList = new List<SelectListItem>();
        //    foreach (var aRegnO in aLlRegNo)
        //    {
        //        allRegList.Add(new SelectListItem() { Value = aRegnO.Id.ToString(), Text = aRegnO.RegNo });
        //    }
        //    return allRegList;
        //}


        [HttpPost]
        public JsonResult GetStudentById(int id)
        {
            Student student = manager.GetStudentByById(id);

            return Json(student, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult GetCourseById(int id)
        {
            List<EnrollCourse> courses = manager.GetCourse(id);
            return Json(courses, JsonRequestBehavior.AllowGet);

        }

    }
}