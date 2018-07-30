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
        public MainDashboard(string perm)
        {
            InitializeComponent();
            disableButtons();
            checkerRestriction(perm);
        }
        public void disableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        public void enableButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            
        }

        public void checkerRestriction(string perm)
        {
            string aa = perm.Substring(0, 1);
            string um = perm.Substring(1, 1);
            string dm = perm.Substring(2, 1);

            if(aa == "1")
            {
                button1.Enabled = true;
            }
            if(um == "1")
            {
                button3.Enabled = true;
            }
            if(dm == "1")
            {
                button2.Enabled = true;
            }
            if(perm == "111")
            {
                enableButtons();
            }
        }
        public attendanceApp ap;
        private void button1_Click(object sender, EventArgs e)
        {
            ap = new attendanceApp();
            ap.Show();
            ap.pointToDboard = this;
            this.Hide();
        }

        private void lgoutbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            pointToLogin.Show();
        }
    }
}
