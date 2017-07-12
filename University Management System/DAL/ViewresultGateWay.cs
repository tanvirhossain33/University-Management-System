using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Management_System.Models;

namespace University_Management_System.DAL
{
    public class ViewresultGateWay
    {
        static Connection aConnection = new Connection();
        private string connectionString = aConnection.GetConnection();

        public List<ResultView> GetAllStudentsRegNo()
        {
            List<ResultView> students = new List<ResultView>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * From RegisterStudent";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
               int id = (int)reader["Id"];
               string regNo = reader["RegNo"].ToString();
               ResultView result = new ResultView(id, regNo);
               students.Add(result);

            }
            connection.Close();
            return students;
        }
        public Student GetStudentById(int id)
        {
            Student student = null;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select rs.Name,rs.Email,d.Code From RegisterStudent rs JOIN Department d ON d.Id = rs.DepartmentId where rs.id =" + id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                student = new Student { Name = reader["Name"].ToString(), Email = reader["Email"].ToString(), Department = new Department { Code = reader["Code"].ToString() } };
            }
            connection.Close();
            if (student != null)
            {
                student.StudentResults = GetResults(id);
            }
            return student;
        }

        public List<StudentResult> GetResults(int id)
        {
            List<StudentResult> studentResults = new List<StudentResult>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"select c.Code,c.Name,g.Grade from Result r join RegisterStudent s on s.Id = r.StudentId join Course c on c.Id = r.CourseId
                            join Dic_Grade g on g.Id = r.GradeId where r.StudentId ="+id; 
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
           while (reader.Read())
            {
                StudentResult result = new StudentResult{Course =new Course{Code =reader["Code"].ToString(),Name = reader["Name"].ToString()}};
                Grade grade = null;
                if (reader["Grade"]==DBNull.Value)
                {
                     grade=new Grade{GradeName ="Not Grade Yet." };
                }

                else
                {
                      grade = new Grade { GradeName = reader["Grade"].ToString()};
                }

                result.Grade = grade;
               studentResults.Add(result);
            }
            connection.Close();
            return studentResults;
        }

        public ResultView StudenPdftById(int id)
        {
            ResultView aResultView=new ResultView();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select  RegisterStudent.Id, RegisterStudent.RegNo, RegisterStudent.Name, RegisterStudent.Email,Department.Name from RegisterStudent Left join Department on  RegisterStudent.DepartmentId=Department.Id where RegisterStudent.Id=" + id + "";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return aResultView;
            }
            connection.Close();
            return aResultView;
            
        }





    }

}
