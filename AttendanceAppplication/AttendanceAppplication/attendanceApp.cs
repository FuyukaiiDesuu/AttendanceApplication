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
        public MainDashboard pointToDboard { get; set; }
 
        public attendanceApp()
        {
            InitializeComponent();
            timer1.Start();
            
            
        }

        private void attendanceApp_Load(object sender, EventArgs e)
        {
            textBox6.Select();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblTime.Text = dt.ToString("        MMMM dd, yyyy HH:mm:ss tt        ");
        }

        private void attendanceApp_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Select();
        }
    }
}
