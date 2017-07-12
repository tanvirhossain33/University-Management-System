using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Management_System.Models;

namespace University_Management_System.DAL
{
    public class StudentGateWay
    {

          private static Connection connection = new Connection();

        private string connectionString = connection.GetConnection();


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
                string code = reader["Code"].ToString();

                Department department = new Department(id, code);
                departmentList.Add(department);
            }

            return departmentList;


        }



  
        public string GetDepartmentCode(int departmentId)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select Department.Code from Department where Id='" + departmentId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //command.Parameters.Clear();
            //command.Parameters.Add("departmentId", SqlDbType.Int);
            //command.Parameters["departmentId"].Value = departmentId;
            //command.CommandText = query;
            //command.Connection = connection;


            while (reader.Read())
            {

                string code = reader["Code"].ToString();
                return code;

            }
            return null;



        }


        public int CountAllStudent(int departmentId, int year)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select  * from  RegisterStudent where DepartmentId='" + departmentId + "'and  Year='" + year + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
                
            }
            return count;
        }

        public bool insertStudent(Student aStudent,string regno,int year)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query ="Insert into RegisterStudent(RegNO,Name,ContactNo,date,Address,DepartmentId,Email,Year) values(@regno,@name,@contactNo,@date,@address,@departmentId,@email,@year)";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.Parameters.Clear();
            command.Parameters.Add("regno", SqlDbType.VarChar);
            command.Parameters["regno"].Value =  regno;

            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = aStudent.Name;

            command.Parameters.Add("contactNO", SqlDbType.VarChar);
            command.Parameters["contactNO"].Value = aStudent.ContactNumber;

            command.Parameters.Add("date", SqlDbType.Date);
            command.Parameters["date"].Value = aStudent.Date;

            command.Parameters.Add("address", SqlDbType.VarChar);
            command.Parameters["address"].Value =  aStudent.Address;

            command.Parameters.Add("departmentId", SqlDbType.Int);
            command.Parameters["departmentId"].Value =  aStudent.DepartmentId;

            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = aStudent.Email;

            command.Parameters.Add("year", SqlDbType.Int);
            command.Parameters["year"].Value = year;
             
            int rowAffected = command.ExecuteNonQuery();
            if (rowAffected>0)
            {
                return true;
            }
            connection.Close();
            return false;


        }

        public bool IsUniq(Student aStudent)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select  * from RegisterStudent Where Email='" +  aStudent.Email + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            connection.Close();
            return false;
             
        }
    }


}



 