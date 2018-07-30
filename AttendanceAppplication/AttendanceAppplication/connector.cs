
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AttendanceAppplication
{
    class connector
    {
        public MySqlConnection connecter()
        {
            String connecttodb = "server=localhost;username=root;password=root;database=attendancedb";
            MySqlConnection conn = new MySqlConnection(connecttodb);
            return conn;
        }
    }
}