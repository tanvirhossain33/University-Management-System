using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University_Management_System.Models;

namespace University_Management_System.DAL
{
    public class AssignCourseGateway
    {
        private AssignCourse assignCourse = new AssignCourse();
        private static Connection connection = new Connection();

        private string connectionString = connection.GetConnection();

        public int InsertCourseAssignInfo(AssignCourse assignCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Insert into CourseAssign(DepartmentId,TeacherId,CreditToBeTaken,CourseCodeId,Name,Credit) " +
                           "Values(@DepartmentId, @TeacherId, @CreditToBeTaken, @CourseCodeId, @CourseName, @CourseCredit)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = assignCourse.DepartmentId;

            command.Parameters.Add("TeacherId", SqlDbType.Int);
            command.Parameters["TeacherId"].Value = assignCourse.TeacherId;

            command.Parameters.Add("CreditToBeTaken", SqlDbType.Decimal);
            command.Parameters["CreditToBeTaken"].Value = assignCourse.CreditToBeTaken;         

            command.Parameters.Add("CourseCodeId", SqlDbType.Int);
            command.Parameters["CourseCodeId"].Value = assignCourse.CourseCodeId;

            command.Parameters.Add("CourseName", SqlDbType.VarChar);
            command.Parameters["CourseName"].Value = assignCourse.CourseName;

            command.Parameters.Add("CourseCredit", SqlDbType.Decimal);
            command.Parameters["CourseCredit"].Value = assignCourse.CourseCredit;

            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }

        public bool IsCourseCodeExist(AssignCourse assignCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from CourseAssign where CourseCodeId =(@courseCodeId)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("courseCodeId", SqlDbType.Int);
            command.Parameters["courseCodeId"].Value = assignCourse.CourseCodeId;

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

        public List<Department> GetAllDepartments()
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

        public List<Teacher> GetAllTeacher()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query1 = "Select * from Teacher";
           
            connection.Open();
            SqlCommand command = new SqlCommand(query1, connection);
          
            SqlDataReader reader = command.ExecuteReader();

            List<Teacher> teachersList = new List<Teacher>();          
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();
                    double creditToBeTaken = Convert.ToDouble(reader["CreditToBeTaken"]);
                    int departmentId = Convert.ToInt32(reader["DepartmentId"]);
                    double remainCredit = creditToBeTaken;

                    Teacher teacher = new Teacher(id, name, departmentId, creditToBeTaken, remainCredit);
                    teachersList.Add(teacher);
                }
                connection.Close();
                return teachersList;
        }

        //public List<AssignCourse> GetAllAssignCourseInfo()
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "Select * from CourseAssign";
        //    connection.Open();
        //    SqlCommand command = new SqlCommand(query, connection);

        //    SqlDataReader reader = command.ExecuteReader();
        //    List<AssignCourse> assignCoursesList = new List<AssignCourse>();
        //    while (reader.Read())
        //    {
                
        //            int id = Convert.ToInt32(reader["Id"]);
        //            int departmentId = Convert.ToInt32(reader["DepartmentId"]);
        //            int teacherId = Convert.ToInt32(reader["TeacherId"]);
        //            double creditToBeTaken = Convert.ToDouble(reader["CreditTobeTaken"]);
        //            double remainCredit = Convert.ToDouble(reader["RemainCredit"]);
        //            int courseCodeId = Convert.ToInt32(reader["CourseCodeId"]);
        //            string courseName = reader["Name"].ToString();
        //            double courseCredit = Convert.ToDouble(reader["Credit"]);


        //            AssignCourse assignCourse = new AssignCourse();
        //            assignCourse.Id = id;
        //            assignCourse.CourseCredit = courseCredit;
        //            assignCourse.CreditToBeTaken = creditToBeTaken;
        //            assignCourse.RemainingCredit = remainCredit;
        //            assignCourse.TeacherId = teacherId;
        //            assignCourse.CourseCodeId = courseCodeId;
        //            assignCourse.CourseName = courseName;
        //            assignCourse.DepartmentId = departmentId;

        //            assignCoursesList.Add(assignCourse);

        //    }
        //    return assignCoursesList;
        //}

        public decimal GetTeacherTakenCredit(int deptId, int teacherId)
        {
            decimal takenCredit = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from CourseAssign where DepartmentId=(@deptId) AND TeacherId=(@teacherId)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("deptId", SqlDbType.Int);
            command.Parameters["deptId"].Value =deptId;

            command.Parameters.Add("teacherId", SqlDbType.Int);
            command.Parameters["teacherId"].Value = teacherId;

            command.CommandText = query;
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                takenCredit += Convert.ToDecimal(reader["Credit"]);
            }

            return takenCredit;
        }

        public List<Course> GetCourseAssignInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select Course.Id, Course.DepartmentId, Course.Code, Course.Name, Dic_Semester.Name as Semester, Teacher.Name as AssignTo from Course " +
                           "left outer join CourseAssign on Course.Id=CourseAssign.CourseCodeId left outer join Dic_Semester on Course.SemesterId=Dic_Semester.Id " +
                           "left outer join Teacher on CourseAssign.TeacherId=Teacher.Id";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Course> getAllAssignInfo=new List<Course>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                int deptId = Convert.ToInt32(reader["DepartmentId"]);
                string code = reader["Code"].ToString();
                string name = reader["Name"].ToString();
                string semester = reader["Semester"].ToString();
                string assignTo = reader["AssignTo"].ToString();

                Course assignCourse=new Course();
                assignCourse.Id = id;
                assignCourse.Department = deptId;
                assignCourse.Code = code;
                assignCourse.Name = name;
                assignCourse.SemesterName = semester;
                assignCourse.AssignTo = assignTo;

                getAllAssignInfo.Add(assignCourse);
            }
            return getAllAssignInfo;
        } 
    }
}