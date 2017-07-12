using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_System.DAL;
using University_Management_System.Models;

namespace University_Management_System.BLL
{
    public class CourseManager
    {
        CourseGetWay courseGetWay = new CourseGetWay();

        public List<Department> GetAllDepartment()
        {
            return courseGetWay.GetAllDepartment();
        }

        public List<Semester> GetGetAllSemester()
        {
            return courseGetWay.GetAllSemester();
        }



        public string Insert(Course course)
        {
            string message = "Insertion Faield";

            
            bool isUniqueCode = courseGetWay.IsUniqueCode(course);
            bool isUniqueName = courseGetWay.IsUniqueName(course);

            if (isUniqueCode)
            {
                message = "Course Code is already Inserted";
                return message;
            }

            else if (isUniqueName)
            {
                message = "Course Name is already Inserted";
                return message;
            }
            else
            {
                int isSaved = courseGetWay.Insert(course);
                if (isSaved > 0)
                {
                    message = "Save Successfully";
                }
                return message;
            }

        }
    }
}