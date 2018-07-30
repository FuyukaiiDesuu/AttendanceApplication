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
            
            using (dbconnection = dbconnect.connecter())
            {
                dbconnection.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM userlist WHERE username = '"+textBox1.Text+"'and password = '"+textBox2.Text+"';", dbconnection);
                MySqlDataAdapter listener = new MySqlDataAdapter(query);
                DataTable holder = new DataTable();
                listener.Fill(holder);

                //MessageBox.Show(perm.Substring(0,1));

                if (holder.Rows.Count > 0)
                {
                    string perm = holder.Rows[0]["restrictions"].ToString();
                    //var uname = holder.Rows[0]["last_name"].ToString() + ", " + holder.Rows[0]["first_name"].ToString();
                    MessageBox.Show("Succesful Login!");
                    md = new MainDashboard(perm);
                    md.Show();
                    md.pointToLogin = this;
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Wrong Credentials!");
                }
            }
               
            
        }
    }
}
