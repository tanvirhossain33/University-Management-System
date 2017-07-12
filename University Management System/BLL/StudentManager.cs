using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using University_Management_System.DAL;
using University_Management_System.Models;

namespace University_Management_System.BLL
{
    
    public class StudentManager
    {
        StudentGateWay studentGateWay=new StudentGateWay();

        //public List<Department> GetAllDepartments()
        //{
        //  List<Department> allDep = studentGateWay.GetAllDepartments();
        //    return allDep;
        //}

        public List<Department> GetAllDepartment()
        {
            return studentGateWay.GetAllDepartment();
        }


        public string Insert(Student aStudent, string regNo,int year)
        {
            string mess = "Insertion Field";
            bool isUniq = studentGateWay.IsUniq(aStudent);
            if (!isUniq)
            {
               bool isSaved = studentGateWay.insertStudent(aStudent, regNo, year);
                if (isSaved)
                {
                    return mess = "Registration is Successfully Done";
                }
            }
            else
            {
                mess = "Email Already Exixts";
            }

            return mess;

        }

        //private  string GetDepartmentCode(int departmentId)
        //{
        //    return studentGateWay.GetDepartmentCode(departmentId);

        //}

        public string GetDepartmentCode(int departmentId)
        {

            return studentGateWay.GetDepartmentCode(departmentId);


        }
    }
}