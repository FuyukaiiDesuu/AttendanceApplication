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
    public partial class attendanceApp : Form
    {
        public MySqlConnection dbconnection;
        public MainDashboard pointToDboard { get; set; }
 
        public attendanceApp()
        {
            InitializeComponent();
            
            timer1.Start();
            loaddata1();
            dataGridView1.ClearSelection();

        }

        public void loaddata1()
        {
            var connector = new connector();
            string query = "SELECT * FROM attendance_in INNER JOIN students_list ON attendance_in.studentID = students_list.idList;";
            using (dbconnection = connector.connecter())
            {
                dbconnection.Open();
                MySqlDataAdapter ad = new MySqlDataAdapter(query, dbconnection);
                DataSet data = new DataSet();
                ad.Fill(data);
                dataGridView1.DataSource = data.Tables[0];
                dataGridView1.Columns["idList"].Visible = false;
                dataGridView1.Columns["stud_code"].Visible = true;
                dataGridView1.Columns["firstname"].Visible = true;
                dataGridView1.Columns["lastname"].Visible = true;
                dataGridView1.Columns["middlename"].Visible = true;
                dataGridView1.Columns["department"].Visible = false;
                dataGridView1.Columns["level"].Visible = false;
                dataGridView1.Columns["date_in"].Visible = true;
                dataGridView1.Columns["inID"].Visible = false;
                dataGridView1.Columns["studentID"].Visible = false;
                dataGridView1.AutoResizeColumns();
            }
        }
        private void attendanceApp_Load(object sender, EventArgs e)
        {
            textBox6.Select();
        }
        public DateTime dt;
        private void timer1_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            lblTime.Text = dt.ToString("        MMMM dd, yyyy hh:mm:ss tt        ");
        }

        private void attendanceApp_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Select();
        }
        private string studentgetter()
        {
            var dbconnect = new connector();

            using (dbconnection = dbconnect.connecter())
            {
                dbconnection.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM students_list WHERE stud_code = '"+textBox6.Text+"';", dbconnection);
                MySqlDataAdapter listener = new MySqlDataAdapter(query);
                DataTable holder = new DataTable();
                listener.Fill(holder);
                return holder.Rows[0]["idList"].ToString();
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
            //studentgetter();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void attendanceApp_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        public DateTime dt2;
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var dbconnect = new connector();
                using (dbconnection = dbconnect.connecter())
                {
                    dbconnection.Open();
                    string query = "INSERT INTO attendance_in(studentID, date_in) VALUES(@ayd, @date);";
                    using (var command = new MySqlCommand(query, dbconnection))
                    {
                        command.Parameters.AddWithValue("@ayd", studentgetter());
                        command.Parameters.AddWithValue("@date", dt2.ToString("yyyy-mm-dd HH:mm:ss"));
                        command.ExecuteNonQuery();
                    }

                   
                }
                loaddata1();
                textBox6.Clear();
            }
        }
    }
}
