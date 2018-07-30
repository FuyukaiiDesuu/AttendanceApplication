
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MainSystem
{
    class connector
    {
        public MySqlConnection connecter()
        {
            String connecttodb = "server=localhost;username=root;password=root;database=silasystemdb";
            MySqlConnection conn = new MySqlConnection(connecttodb);
            return conn;
        }
    }
}