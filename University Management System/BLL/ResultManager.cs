using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_Management_System.DAL;
using University_Management_System.Models;

namespace University_Management_System.BLL
{
    public class ResultManager
    {
        private ResultGateway resultGateway = new ResultGateway();


        public string Insert(Result aResult)
        {
            string message = "Insertion Field!";
            bool isEnrollUniq = resultGateway.IsUniqEnrollCourse(aResult);

            if (isEnrollUniq)
            {
                message = "This Subject Result Allocated Already Exists";
            }
            else
            {
                bool isSaved = resultGateway.Insert(aResult);
                if (isSaved)
                {
                    message = "Save successfully!";
                }

            }

            return message;

        }
        
        public List<Grade> GetAllGrade()
        {
            List<Grade> allGrade = resultGateway.GetAllGrade();
            return allGrade;
        }

        public List<EnrollCourse> GetStudentCourse(int id)
        {
            return resultGateway.GetStudentCourse(id);
        }
    }
}


