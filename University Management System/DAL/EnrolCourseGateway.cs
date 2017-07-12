using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using University_Management_System.Models;

namespace University_Management_System.DAL
{
    public class EnrolCourseGateway
    {
        static Connection aConnection = new Connection();

        string connectionString = aConnection.GetConnection();


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
            return student;

        }

        public List<EnrollCourse> GetCourse(int id)
        {

            List<EnrollCourse> courseslList = new List<EnrollCourse>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select Course.Name,Course.Id from Course  JOIN  RegisterStudent ON RegisterStudent.DepartmentId = Course.DepartmentId where RegisterStudent.id =" + id + "";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                int courseId = (int)reader["Id"];
                string name = reader["Name"].ToString();
                EnrollCourse aCourse = new EnrollCourse(courseId, name);
                courseslList.Add(aCourse);
            }

            connection.Close();
            return courseslList;

        }

        public bool Insert(EnrollCourse aEnrollCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO EnrollCourse(StudentId,CourseId,Date)VALUES('" + aEnrollCourse.StudentId + "','" + aEnrollCourse.CourseId + "','" + aEnrollCourse.Date + "')";
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



        public bool IsUniqEnrollCourse(EnrollCourse aEnrollCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM EnrollCourse WHERE StudentId=" + aEnrollCourse.StudentId + "   AND CourseId=" + aEnrollCourse.CourseId;
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