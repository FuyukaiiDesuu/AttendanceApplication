using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AttendanceAppplication
{
    public partial class LOGIN : Form
    {
        public MySqlConnection dbconnection;
        public LOGIN()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }
        public MainDashboard md;
        private void button1_Click(object sender, EventArgs e)
        {
            var dbconnect = new connector();
            string query = "select * from studentprofile inner join studdetails on studentprofile.idstudentprofile = studdetails.idstddet WHERE studentprofile.Status = 1;";
            using (dbconnection = dbconnect.connector())
            {

            }
                md = new MainDashboard();
            md.Show();
            md.pointToLogin = this;
            this.Hide();
            
        }
    }
}
