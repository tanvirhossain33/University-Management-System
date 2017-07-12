using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Management_System.Models;

namespace University_Management_System.DAL
{
    public class TeacherGetway
    {
       static Connection connection = new Connection();

        private string connectionString = connection.GetConnection();



        public List<TeacherDesignation> GetAllDesignation()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Dic_Designation";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<TeacherDesignation> designationList = new List<TeacherDesignation>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string name = reader["name"].ToString();

                TeacherDesignation teacherDesignation = new TeacherDesignation(id, name);
                designationList.Add(teacherDesignation);
            }


            return designationList;
        }

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

        public int Insert(Teacher teacher)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Teacher (Name, Address, Email, ContactNo, DesignationId, DepartmentId, CreditToBeTaken) VALUES (@name, @address, @email, @contactNo, @designationId, @departmentId, @credit)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = teacher.Name;

            command.Parameters.Add("address", SqlDbType.VarChar);
            command.Parameters["address"].Value = teacher.Address;

            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = teacher.Email;

            command.Parameters.Add("contactNo", SqlDbType.VarChar);
            command.Parameters["contactNo"].Value = teacher.ContactNo;

            command.Parameters.Add("designationId", SqlDbType.Int);
            command.Parameters["designationId"].Value = teacher.Designation;

            command.Parameters.Add("departmentId", SqlDbType.Int);
            command.Parameters["departmentId"].Value = teacher.Department;

            command.Parameters.Add("credit", SqlDbType.Decimal);
            command.Parameters["credit"].Value = teacher.Credit;



            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;

        }

        public bool IsUniqueEmail(Teacher teacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Teacher where Email =(@email)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = teacher.Email;

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


        public List<Teacher> GetallTeachers( int  departmentId )
        {

            List<Teacher>allTeachers=new List<Teacher>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from  teacher where departmentId=(@departmentid )";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();
             
           
            command.Parameters.Add("departmentId", SqlDbType.Int);
            command.Parameters["departmentId"].Value = departmentId;
            command.CommandText = query;
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
          
                int id = (int) reader["Id"];
                string name = reader["Name"].ToString();

                Teacher aTeacher = new Teacher(id,name);
                allTeachers.Add(aTeacher);

            }
            return allTeachers;
            

        }




    }
}