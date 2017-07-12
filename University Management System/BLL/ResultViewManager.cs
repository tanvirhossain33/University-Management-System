using System.Collections.Generic;
using University_Management_System.DAL;
using University_Management_System.Models;

namespace University_Management_System.BLL
{
    public class ResultViewManager
    {
        ViewresultGateWay viewresultGateWay = new ViewresultGateWay();
        public List<ResultView> StudentsRegNo()
        {
            List<ResultView> alLReg = viewresultGateWay.GetAllStudentsRegNo();
            return alLReg;
        }


        public Student GetStudentById(int id)
        {
            return viewresultGateWay.GetStudentById(id);
        }

        internal ResultView GetStudenPdftById(int p)
        {
            throw new System.NotImplementedException();
        }
    }
}