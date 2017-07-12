using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_System.DAL;
using University_Management_System.Models;

namespace University_Management_System.BLL
{
    public class EnrollCourseManager
    {
        EnrolCourseGateway enrolCourseGateway=new EnrolCourseGateway();
        public Student GetStudentByById(int id)
        {
            return enrolCourseGateway.GetStudentById(id);
        }

        public List<EnrollCourse> GetCourse(int id)
        {
            List<EnrollCourse> GetCourse = enrolCourseGateway.GetCourse(id);
            return GetCourse;
        }

        public string Insert(EnrollCourse aEnrollCourse)
        {
            string message = "Insertion Field!";
            bool isEnrollUniq = enrolCourseGateway.IsUniqEnrollCourse(aEnrollCourse);

            if (isEnrollUniq)
            {
                message = "This Student Courses Already Exists";
            }
            else
            {
                bool isSaved = enrolCourseGateway.Insert(aEnrollCourse);
                if (isSaved)
                {
                    message = "Save successfully!";
                }
                
            }

            return message;
            
        }
    }
}