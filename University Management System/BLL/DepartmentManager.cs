using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_System.Models;
using University_Management_System.DAL;

namespace University_Management_System.BLL
{
    public class DepartmentManager
    {
       DepartmentGetway departmentGetway = new DepartmentGetway();
        public string Insert(Department department)
        {
            

            string message = "Insertion Faield";

            bool isCode = departmentGetway.IsUniqueCode(department);
            bool isName = departmentGetway.IsUniqueName(department);
            
            if (isCode)
            {
                message = "Department Code is Already Exists";
                return message;
            }
            else if (isName)
            {
                message = "Department Name is Already Exists";
                return message;
            }
            else
            {
                int isSaved = departmentGetway.InsertDepartment(department);
                if (isSaved > 0)
                {
                    message = "Save Successfully";
                }
                return message;
            }

        }

        public List<Department> GetDepartmentInfo()
        {
            return departmentGetway.GetDepartmentInfo();
        } 



    }
}