using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using University_Management_System.BLL;
using University_Management_System.Models;


namespace University_Management_System.Controllers
{
    public class ViewResultController : Controller
    {
        private ResultViewManager manager = new ResultViewManager();

        public ActionResult ViewResult()
        {

            List<ResultView> aLlRegNo = manager.StudentsRegNo();
            List<SelectListItem> allRegList = new List<SelectListItem>();
            foreach (var aRegnO in aLlRegNo)
            {
                allRegList.Add(new SelectListItem() { Value = aRegnO.Id.ToString(), Text = aRegnO.RegNo });
            }
            ViewData["RegNoId"] = allRegList;
            //ViewBag.GetallStudent = aLlRegNo;
            return View();

        }


        [HttpPost]
        public ActionResult ViewResult(ResultView aResultView)
        {
            List<ResultView> aLlRegNo = manager.StudentsRegNo();

            List<SelectListItem> allRegList = new List<SelectListItem>();
            foreach (var aRegnO in aLlRegNo)
            {
                allRegList.Add(new SelectListItem() { Value = aRegnO.Id.ToString(), Text = aRegnO.RegNo });
            }
            ViewData["RegNoId"] = allRegList;
           // ViewBag.GetallStudent = aLlRegNo;

            ResultView resultView = manager.GetStudenPdftById(aResultView.Id);
            return null;
        }


        [HttpPost]
        public JsonResult GetResultData(int id)
        {

            Student student = manager.GetStudentById(id);
            return Json(student, JsonRequestBehavior.AllowGet);
        }
    }
}
 