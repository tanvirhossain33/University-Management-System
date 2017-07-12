using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Management_System.Models;

namespace University_Management_System.DAL
{
    public class ResultGateway
    {

        static Connection connection = new Connection();

        string connectionString = connection.GetConnection();

        public List<Grade> GetAllGrade()
        {
            List<Grade> allGrade = new List<Grade>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Dic_Grade";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string grade = reader["Grade"].ToString();

                Grade aGrade = new Grade(id, grade);
                allGrade.Add(aGrade);

            }
            connection.Close();
            return allGrade;
        }


        public List<EnrollCourse> GetStudentCourse(int id)
        {
             List<EnrollCourse> allGrade = new List<EnrollCourse>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select Course.Id,Course.Name from EnrollCourse join  Course  on  EnrollCourse.CourseId=Course.Id where  EnrollCourse.StudentId="+id+"";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int Id = (int)reader["Id"];
                string name = reader["Name"].ToString();

                EnrollCourse course = new EnrollCourse(Id,name);
                allGrade.Add(course);
                
            }
            connection.Close();
            return allGrade;
         
        }


        public bool Insert(Result aResult)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Result (StudentId,CourseId,GradeId )VALUES('" + aResult.StudentId + "','" + aResult.CourseId + "','" + aResult.GradeId + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                return true;
            }
            connection.Close();
            return false;

        }



        public bool IsUniqEnrollCourse(Result aResult)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Result WHERE StudentId=" + aResult.StudentId + "   AND CourseId=" + aResult.CourseId;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                return true;
            }
            connection.Close();
            return false;

        }


    }
}