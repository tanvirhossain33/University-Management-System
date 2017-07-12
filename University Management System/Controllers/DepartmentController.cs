using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_System.BLL;
using University_Management_System.Models;

namespace University_Management_System.Controllers
{

    public class DepartmentController : Controller
    {


        DepartmentManager departmentManager = new DepartmentManager();

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {

            string message = departmentManager.Insert(department);
            ViewBag.Message = message;

            return View();
        }


        public ActionResult Show()
        {
            List<Department> departmentInfoList = departmentManager.GetDepartmentInfo();
            ViewData["DepartmentInfo"] = departmentInfoList;

            return View();
        }



	}
}