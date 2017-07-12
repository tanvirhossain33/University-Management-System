using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_System.DAL;
using University_Management_System.Models;

namespace University_Management_System.BLL
{
    public class AllocateManager
    {
        private AllocateGetway allocateGateWay = new AllocateGetway();       

        public List<Department> GetAllDepartment()
        {
            return allocateGateWay.GetAllDepartment();
        }

        public List<Course> GetAllCourse()
        {
            return allocateGateWay.GetAllCourse();
        }

        public List<Room> GetAllRoom()
        {
            return allocateGateWay.GetAllRoom();
        }

        public List<Day> GetAllDay()
        {
            return allocateGateWay.GetAllDay();
        }

        public string Insert(AllocateClassrooms allocateRoom )
        {
            string message = "Save Failed!";

            List<AllocateClassrooms> allocatedRooms = allocateGateWay.GetAllocateInfo() ;

            string aFromTime = DateTime.Parse(allocateRoom.FromTime.ToString()).ToString("dd-MM-yyyy hh:mm tt");
            string aToTime = DateTime.Parse(allocateRoom.ToTime.ToString()).ToString("dd-MM-yyyy hh:mm tt");

            string bFromTime = aFromTime.Substring(10);
            string bToTime = aToTime.Substring(10);

            DateTime nFromTime = Convert.ToDateTime(bFromTime);
            DateTime nToTime = Convert.ToDateTime(bToTime);



            string scheduleTime = "";
            bool found = false;

            foreach (AllocateClassrooms allocate in allocatedRooms)
            {
                DateTime existingFromTime = Convert.ToDateTime(allocate.FromTime);
                DateTime existingToTime = Convert.ToDateTime(allocate.ToTime);

                bool matchRoom = allocate.RoomNoId == allocateRoom.RoomNoId;
                bool matchDay = allocate.DayId == allocateRoom.DayId;

                bool matchFromTime = existingFromTime == nFromTime;
                bool matchToTime = existingToTime == nToTime;

                bool coverExistingRange = nFromTime < existingFromTime & nToTime > existingFromTime;
                bool coverExistingRange2 = nFromTime < existingToTime & nToTime > existingToTime;

                bool toTimeInTheRange = nToTime > existingFromTime & nToTime < existingToTime;
                bool fromTimeInTheRange = nFromTime > existingFromTime & nFromTime < existingToTime;

                bool matchTime = matchFromTime || matchToTime;
                bool coverTime = coverExistingRange || coverExistingRange2;
                bool overlapTime = toTimeInTheRange || fromTimeInTheRange;

                if (matchRoom & matchDay & (matchTime || overlapTime || coverTime))
                {
                    //allocate.RoomNoId + " " + allocate.DayId + " " +
                    scheduleTime =  allocate.FromTime + " - " + allocate.ToTime;
                    found = true;
                }

            }

            if (found)
            {
                message = scheduleTime + " has been already scheduled!";
                return message;
            }

            bool isSaved = allocateGateWay. Insert(allocateRoom);

            if (isSaved)
            {
                message = "Saved successfully!";
            }
            return message;
        }

        //public string Insert(AllocateClassrooms allocateClassrooms, string Ftime,string Ttime)
        //{
        //    string message = "Insertion Faield";

        //    bool isUnique = allocateGateWay.IsUniqueRoom(allocateClassrooms);

        //    if (isUnique)
        //    {
        //        message = "Room is already Assign";
        //        return message;
        //    }

        //    else
        //    {
        //        int isSaved = allocateGateWay.Insert(allocateClassrooms, Ftime, Ttime);
        //        if (isSaved > 0)
        //        {
        //            message = "Save Successfully";
        //        }
        //        return message;
        //    }

        //}


        public string GetDepartmentCode(int departmentId)
        {

            return allocateGateWay.GetDepartmentCode(departmentId);


        }

        public List<AllocateClassrooms> GetAllocateInfo()
        {
            return allocateGateWay.GetAllocateInfo();
        }

        public List<Course> GetAllAllocatedCourses()
        {
            return allocateGateWay.GetAllAllocatedCourseInfo();
        }
    }
}