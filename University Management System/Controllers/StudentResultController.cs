using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_System.BLL;
using University_Management_System.Models;

namespace University_Management_System.Content
{
    public class StudentResultController : Controller
    {
        ResultViewManager resultViewManager = new ResultViewManager();
        ResultManager resultManager = new ResultManager();

        public ActionResult SaveResult()
        {

            var regNoList = resultViewManager.StudentsRegNo();
            ViewBag.GetallStudent = regNoList;
            //ViewData["StudentId"] = regNoList;

            var gradeList = resultManager.GetAllGrade();
            ViewBag.GetAllGrade = gradeList;
            //var gradeList = GetAllGradeList();
            //ViewData["GradeId"] = gradeList;


            return View();
        }



        [HttpPost]
        public ActionResult SaveResult(Result aResult)
        {

            var regNoList = resultViewManager.StudentsRegNo();
            ViewBag.GetallStudent = regNoList;
            //ViewData["StudentId"] = regNoList;

            var gradeList = resultManager.GetAllGrade();
            ViewBag.GetAllGrade = gradeList;
           // ViewData["GradeId"] = gradeList;


            string message = resultManager.Insert(aResult);
            ViewBag.message = message;
            
            return View();
        }



        [HttpPost]
        public JsonResult GetStudentCourseById(int id)
        {
            List<EnrollCourse> studentCourses = resultManager.GetStudentCourse(id);
            return Json(studentCourses, JsonRequestBehavior.AllowGet);
        }


        //private List<SelectListItem> StudentRegNo()
        //{
        //    List<ResultView> allStudents = resultViewManager.StudentsRegNo();
        //    List<SelectListItem> regNoList = new List<SelectListItem>();
        //    foreach (var aStudent in allStudents)
        //    {
        //        regNoList.Add(new SelectListItem() { Value = aStudent.Id.ToString(), Text = aStudent.RegNo });
        //    }
        //    return regNoList;
        //}

        //private List<SelectListItem> GetAllGradeList()
        //{
        //    List<Grade> AllGrade = resultManager.GetAllGrade();
        //    List<SelectListItem> gradeList = new List<SelectListItem>();
        //    foreach (var aGrade in AllGrade)
        //    {
        //        gradeList.Add(new SelectListItem() { Value = aGrade.Id.ToString(), Text = aGrade.GradeName });
        //    }
        //    return gradeList;
        //}

    }
}