using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_Management_System.DAL
{
    public class Connection
    {
        public string GetConnection()
        {
            string connectionString = @"Server=.\SQLEXPRESS; Database = UniversityManagement; Integrated Security=true";


            return connectionString;

        }
    }
}