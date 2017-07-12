using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_System.BLL;
using University_Management_System.Models;

namespace University_Management_System.Controllers
{
    public class AllocateClassroomsController : Controller
    {
        AllocateManager allocateManager = new AllocateManager();
        //
        // GET: /AllocateClassrooms/
        public ActionResult AllocateClassrooms()
        {

            var departmentList =  allocateManager.GetAllDepartment();
            ViewBag.ALLDepartment = departmentList;

            var roomList = GetRoomList();
            ViewBag.ALLRoom = roomList;

            var dayList = GetDayList();
            ViewBag.ALLDay = dayList;
            return View();
        }

        [HttpPost]
        public ActionResult AllocateClassrooms(AllocateClassrooms allocateClassrooms)
        {
            var departmentList = allocateManager.GetAllDepartment();
            ViewBag.ALLDepartment = departmentList;
            var roomList = GetRoomList();
            ViewBag.ALLRoom = roomList;

            var dayList = GetDayList();
            ViewBag.ALLDay = dayList;

            string message = allocateManager.Insert(allocateClassrooms);
            ViewBag.message = message;
            return View();
        }


        private List<SelectListItem> GetDepartmentList()
        {
            List<Department> getDepartmentList = allocateManager.GetAllDepartment();

            List<SelectListItem> departmentList = new List<SelectListItem>();
            foreach (var adepartment in getDepartmentList)
            {
                departmentList.Add(new SelectListItem() { Value = adepartment.Id.ToString(), Text = adepartment.Name });
            }
            return departmentList;
        }

        private IList<Course> GetAllCourse(int deptId)
        {
            return allocateManager.GetAllCourse().Where(m => m.Department == deptId).ToList();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetCourseListByDeptId(int deptId)
        {
            var courseList = this.GetAllCourse(deptId);
           var courseData=  courseList.Select(m => new SelectListItem()
             {
                 Text = m.Code,
                 Value = m.Id.ToString()
             });

            return Json(courseData, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetRoomList()
        {
            List<Room> getRoomList = allocateManager.GetAllRoom();

            List<SelectListItem> roomList = new List<SelectListItem>();
            foreach (var aroom in getRoomList)
            {
                roomList.Add(new SelectListItem() { Value = aroom.Id.ToString(), Text = aroom.Name });
            }
            return roomList;
        }

        private List<SelectListItem> GetDayList()
        {

            
            List<Day> getDayList = allocateManager.GetAllDay();

            List<SelectListItem> dayList = new List<SelectListItem>();
            foreach (var aday in getDayList)
            {
                dayList.Add(new SelectListItem() { Value = aday.Id.ToString(), Text = aday.Name });
            }
            return dayList;
        }

        public ActionResult ClassSchedule()
        {
            //List<AllocateClassrooms> allocateInfoList = allocateManager.GetAllocateInfo();
            //ViewData["AllocateInfo"] = allocateInfoList;

            var departmentList = allocateManager.GetAllDepartment();
            ViewBag.ALLDepartment = departmentList;

            return View();
        }

        public JsonResult GetAllocatedInfoForShow(int deptId)
        {
            var allocatedList = allocateManager.GetAllAllocatedCourses();
            var allocated = allocatedList.Where(m => m.Department == deptId).ToList();
            //foreach (var course in allocated)
            //{
            //    if (!(course.FromTime == null && course.ToTime == null))
            //    {
            //        DateTime dt = new DateTime(course.FromTime);
            //        course.FromTime = course.FromTime.ToString("hh:mm tt");
            //    }
            //}
            return Json(allocated, JsonRequestBehavior.AllowGet);
        }
	}
}