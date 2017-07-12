using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using University_Management_System.Models;

namespace University_Management_System.DAL
{
    public class CourseGetWay
    {

        static Connection connection = new Connection();
        
        string connectionString = connection.GetConnection();

        DepartmentGetway departmentGetway = new DepartmentGetway();

        public List<Department> GetAllDepartment()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Department";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Department> departmentList = new List<Department>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string name = reader["name"].ToString();

                Department department = new Department(id, name);
                departmentList.Add(department);
            }


            return departmentList;
        }

        public List<Semester> GetAllSemester()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Dic_Semester";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Semester>  semesterList = new List<Semester>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string name = reader["name"].ToString();

                Semester semester = new Semester(id, name);
                semesterList.Add(semester);
            }


            return semesterList;

        }


        public int Insert(Course course)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Course (Code, Name, Credit, Description, DepartmentId, SemesterId) VALUES (@code, @name, @credit, @description, @departmentId, @semesterId)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("code", SqlDbType.VarChar);
            command.Parameters["code"].Value = course.Code;

            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = course.Name;

            command.Parameters.Add("credit", SqlDbType.Float);
            command.Parameters["credit"].Value = course.Credit;

            command.Parameters.Add("description", SqlDbType.VarChar);
            command.Parameters["description"].Value = course.Description;          

            command.Parameters.Add("departmentId", SqlDbType.Int);
            command.Parameters["departmentId"].Value = course.Department;

            command.Parameters.Add("semesterId", SqlDbType.Int);
            command.Parameters["semesterId"].Value = course.Semester;



            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;

        }

        public bool IsUniqueCode(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Course where Code =(@code)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("code", SqlDbType.VarChar);
            command.Parameters["code"].Value = course.Code;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsUniqueName(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Course where Name =(@name)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = course.Name;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        




    }
}