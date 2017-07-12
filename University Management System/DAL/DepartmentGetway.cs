using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using University_Management_System.Models;

namespace University_Management_System.DAL
{
    public class DepartmentGetway
    {
        static Connection con = new Connection();

        string connectionString = con.GetConnection();



        public int InsertDepartment(Department department)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Department (Code, Name) VALUES (@code, @name)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("code", SqlDbType.VarChar);
            command.Parameters["code"].Value = department.Code;

            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = department.Name;

            

            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;

        }

        public bool IsUniqueCode (Department department)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Department where Code =(@code)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("code", SqlDbType.VarChar);
            command.Parameters["code"].Value = department.Code;

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

        public bool IsUniqueName(Department department)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Department where Name =(@name)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = department.Name;

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



        public List<Department> GetDepartmentInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Department";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Department> departmentInfoList = new List<Department>();

            while (reader.Read())
            { 

                string code = reader["code"].ToString();
                string name = reader["name"].ToString();

                Department department = new Department(code, name);
                departmentInfoList.Add(department);
            }
            return departmentInfoList;
        } 





    }
}