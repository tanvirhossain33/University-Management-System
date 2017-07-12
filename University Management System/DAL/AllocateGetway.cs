using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using University_Management_System.Models;

namespace University_Management_System.DAL
{
    public class AllocateGetway
    {

        static Connection connection = new Connection();

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
                string name = reader["Name"].ToString();

                Department department = new Department(id, name);
                departmentList.Add(department);
            }

            return departmentList;


        }
        public List<Course> GetAllCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Course";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Course> courseList = new List<Course>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string code = reader["Code"].ToString();
                string name = reader["Name"].ToString();
                double credit = Convert.ToDouble(reader["Credit"]);
                int departmentId = Convert.ToInt32(reader["DepartmentId"]);

                Course course = new Course();
                course.Id = id;
                course.Code = code;
                course.Name = name;
                course.Credit = credit;
                course.Department = departmentId;
                courseList.Add(course);
            }


            return courseList;
        }
        //public List<AllocateClassrooms> GetAllCourse()
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "select * from Course";
        //    connection.Open();
        //    SqlCommand command = new SqlCommand(query, connection);
        //    SqlDataReader reader = command.ExecuteReader();

        //    List<AllocateClassrooms> courseList = new List<AllocateClassrooms>();

        //    while (reader.Read())
        //    {
        //        int id = Convert.ToInt32(reader["Id"]);
        //        int deptId = Convert.ToInt32(reader["DepartmentId"]);
        //        string name = reader["Name"].ToString();

        //        AllocateClassrooms allocateClassrooms = new AllocateClassrooms(id, deptId, name);
        //        courseList.Add(allocateClassrooms);
        //    }


        //    return courseList;
        //}

        public List<Room> GetAllRoom()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Dic_Room";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Room> roomtList = new List<Room>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string name = reader["name"].ToString();

                Room room = new Room(id, name);
                roomtList.Add(room);
            }

            return roomtList;


        }

        public List<Day> GetAllDay()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Dic_Day";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Day> dayList = new List<Day>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string name = reader["name"].ToString();

                Day day = new Day(id, name);
                dayList.Add(day);
            }

            return dayList;


        }

        public bool Insert(AllocateClassrooms allocateClassrooms)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO AllocateClassroom (DepartmentId, CourseId, RoomNoId, DayId, FromTime, ToTime) VALUES (@departmentId, @courseId, @roomNoId, @dayId, @fromTime, @toTime)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("departmentId", SqlDbType.Int);
            command.Parameters["departmentId"].Value = allocateClassrooms.DepartmentId;

            command.Parameters.Add("courseId", SqlDbType.Int);
            command.Parameters["courseId"].Value = allocateClassrooms.CourseId;

            command.Parameters.Add("roomNoId", SqlDbType.Int);
            command.Parameters["roomNoId"].Value = allocateClassrooms.RoomNoId;

            command.Parameters.Add("dayId", SqlDbType.VarChar);
            command.Parameters["dayId"].Value = allocateClassrooms.DayId;

            command.Parameters.Add("fromTime", SqlDbType.VarChar);
            command.Parameters["fromTime"].Value = allocateClassrooms.FromTime;

            command.Parameters.Add("toTime", SqlDbType.VarChar);
            command.Parameters["toTime"].Value = allocateClassrooms.ToTime;




            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();

            if (rowAffected > 0)
            {
                return true;
            }
            return false;

        }


        //public bool IsUniqueRoom(AllocateClassrooms allocateClassrooms)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "Select * from AllocateClassroom where RoomNoId =(@roomNoId)";

        //    connection.Open();

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.Add("roomNoId", SqlDbType.VarChar);
        //    command.Parameters["roomNoId"].Value = allocateClassrooms.RoomNoId;

        //    command.CommandText = query;
        //    command.Connection = connection;
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}



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

        public List<AllocateClassrooms> GetAllocateInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from AllocateClassroom";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<AllocateClassrooms> allocateInfoList = new List<AllocateClassrooms>();

            while (reader.Read())
            {
                int id = (int)reader["Id"];
                int roomnoId = (int)reader["RoomNoId"];
                int dayId = (int)reader["DayId"];
                DateTime ftime = (DateTime)reader["FromTime"];
                DateTime ttime = (DateTime)reader["ToTime"];

                //string name = reader["Name"].ToString();

                AllocateClassrooms allocateClassrooms = new AllocateClassrooms(id, roomnoId, dayId, ftime, ttime);
                allocateInfoList.Add(allocateClassrooms);
            }
            return allocateInfoList;
        }

        public List<Course> GetAllAllocatedCourseInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select Course.Id as Id, Course.Code as Code, Course.DepartmentId as DeptId, Course.Name as Name," +
                           "AllocateClassroom.FromTime as fromTime, AllocateClassroom.ToTime as " +
                           "toTime, Dic_Day.Name as Day, Dic_Room.Name as RoomNo from Course " +
                           "left outer join AllocateClassroom on Course.Id=AllocateClassroom.CourseId " +
                           "left outer join Dic_Day on AllocateClassroom.DayId=Dic_Day.Id left " +
                           "outer join Dic_Room on AllocateClassroom.RoomNoId=Dic_Room.Id";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Course> assignedCourseList=new List<Course>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string courseCode = reader["Code"].ToString();
                int deptId = Convert.ToInt32(reader["DeptId"]);
                string courseName = reader["Name"].ToString();
                DateTime? fTime = reader["fromTime"] as DateTime?;
                DateTime? tTime = reader["toTime"] as DateTime?;
                string day = reader["Day"].ToString();
                string roomNo = reader["RoomNo"].ToString();

                Course aCourse =new Course(id, courseCode, deptId, courseName, roomNo, day, fTime, tTime);

                assignedCourseList.Add(aCourse);
            }
            connection.Close();
            return assignedCourseList;
        }
    }
}