using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel_Management_System
{
    public class DatabaseConnection
    {
        public  SqlConnection CreateDBConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=isharaPC\\SQLEXPRESS;Initial Catalog=HostelDB;Integrated Security=True");
            conn.Open();
            return conn;
        }
    }
}
