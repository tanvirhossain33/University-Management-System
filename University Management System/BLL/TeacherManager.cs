using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_System.DAL;
using University_Management_System.Models;

namespace University_Management_System.BLL
{
    public class TeacherManager
    {

        private TeacherGetway teacherGetWay = new TeacherGetway();

        public List<TeacherDesignation> GetAllDesignation()
        {
            return teacherGetWay.GetAllDesignation();
        }

        public List<Department> GetAllDepartment()
        {
            return teacherGetWay.GetAllDepartment();
        }

        public string Insert(Teacher teacher)
        {
            string message = "Insertion Faield";

            bool isUnique = teacherGetWay.IsUniqueEmail(teacher);

            if (isUnique)
            {
                message = "Teacher is already Inserted";
                return message;
            }

            else
            {
                int isSaved = teacherGetWay.Insert(teacher);
                if (isSaved > 0)
                {
                    message = "Save Successfully";
                }
                return message;
            }

        }

        public List<Teacher> GetAllTeacher(int departmentId)
        {
          List<Teacher> allTeacher = teacherGetWay.GetallTeachers(departmentId);
          return allTeacher;
        }




    }
}