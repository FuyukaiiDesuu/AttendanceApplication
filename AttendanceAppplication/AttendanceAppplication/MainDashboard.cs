using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceAppplication
{
    public partial class MainDashboard : Form
    {
        public LOGIN pointToLogin { get; set; }
        public MainDashboard()
        {
            InitializeComponent();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {

        }
        public attendanceApp ap;
        private void button1_Click(object sender, EventArgs e)
        {
            ap = new attendanceApp();
            ap.Show();
            ap.pointToDboard = this;
            this.Hide();
        }
    }
}
