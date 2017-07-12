using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_System.DAL;
using University_Management_System.Models;

namespace University_Management_System.BLL
{
    public class AssignCourseManager
    {
        AssignCourseGateway assignCourseGateway=new AssignCourseGateway();

        public string InsertAssignedCourse(AssignCourse assignCourse)
        {
            string message = "Course Assign Faield";

            bool isCode = assignCourseGateway.IsCourseCodeExist(assignCourse);

            if (isCode)
            {
                message = "Course is Already Assigned";
                return message;
            }
            else
            {
                int isSaved = assignCourseGateway.InsertCourseAssignInfo(assignCourse);
                if (isSaved > 0)
                {
                    message = "Course Assigned Successful";
                }
                return message;
            }

        }

        public List<Department> GetAllDepartment()
        {
            return assignCourseGateway.GetAllDepartments();
        }
        public List<Course> GetAllCourse()
        {
            return assignCourseGateway.GetAllCourse();
        }

        public List<Teacher> GetAllTeacher()
        {    
            return assignCourseGateway.GetAllTeacher();
        }

        public decimal GetTeacherTakenCredit(int deptId, int teacherId)
        {
            return assignCourseGateway.GetTeacherTakenCredit(deptId, teacherId);
        }

        public List<Course> GetCourseAssignInfo()
        {
           return assignCourseGateway.GetCourseAssignInfo();
        }
       
    }
}