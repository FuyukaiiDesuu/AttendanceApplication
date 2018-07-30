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
        public void txtboxesclear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        public void loaddata1()
        {
            
            var connector = new connector();
            string query = "SELECT * FROM attendance_in INNER JOIN students_list ON attendance_in.studentID = students_list.idList ORDER BY attendance_in.date_in DESC;";
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

        public void txtboxpopulate()
        {
            IDictionary<string, string> dict = dic();
            textBox1.Text = dict["LN"];
            textBox2.Text = dict["FN"];
            textBox3.Text = dict["MI"];
            textBox5.Text = dict["Dpt"];
            textBox4.Text = dict["level"];
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
        private IDictionary<string, string> dic()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            var dbconnect = new connector();

            using (dbconnection = dbconnect.connecter())
            {
                dbconnection.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM students_list WHERE stud_code = '" + textBox6.Text + "';", dbconnection);
                MySqlDataAdapter listener = new MySqlDataAdapter(query);
                DataTable holder = new DataTable();
                listener.Fill(holder);
                dict.Add("FN", holder.Rows[0]["firstname"].ToString());
                dict.Add("LN", holder.Rows[0]["lastname"].ToString());
                var initial = holder.Rows[0]["middlename"].ToString().Substring(0, 1) + ".";
                dict.Add("MI", initial);
                
                switch(holder.Rows[0]["department"].ToString())
                {
                    case "1":
                        dict.Add("Dpt", "Pre-school");
                        break;
                    case "2":
                        dict.Add("Dpt", "Grade-school");
                        break;
                    case "3":
                        dict.Add("Dpt", "High-school");
                        break;
                }
                switch(holder.Rows[0]["level"].ToString())
                {
                    case "11":
                        dict.Add("level", "Toddler");
                        break;
                    case "12":
                        dict.Add("level", "Nursery");
                        break;
                    case "13":
                        dict.Add("level", "Kinder");
                        break;
                    case "14":
                        dict.Add("level", "Preparatory");
                        break;
                    case "21":
                        dict.Add("level", "Grade 1");
                        break;
                    case "22":
                        dict.Add("level", "Grade 2");
                        break;
                    case "23":
                        dict.Add("level", "Grade 3");
                        break;
                    case "24":
                        dict.Add("level", "Grade 4");
                        break;
                    case "25":
                        dict.Add("level", "Grade 5");
                        break;
                    case "26":
                        dict.Add("level", "Grade 6");
                        break;
                    case "31":
                        dict.Add("level", "Grade 7");
                        break;
                    case "32":
                        dict.Add("level", "Grade 8");
                        break;
                    case "33":
                        dict.Add("level", "Grade 9");
                        break;
                    case "34":
                        dict.Add("level", "Grade 10");
                        break;
                }
            }
            return dict;
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
            dt2 = DateTime.Now;
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
                        command.Parameters.AddWithValue("@date", dt2.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.ExecuteNonQuery();
                    }

                   
                }
                loaddata1();
                txtboxpopulate();
                
                //System.Threading.Thread.Sleep(1500);
                timer2.Start();
                //timer2.Stop();
            }
        }
        public int a = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if(a < 3)
            {
                a++;
                //MessageBox.Show("");
            }
            else
            {
                textBox6.Clear();
                txtboxesclear();
                a = 0;
                timer2.Stop();
            }
            
        }
    }
}
