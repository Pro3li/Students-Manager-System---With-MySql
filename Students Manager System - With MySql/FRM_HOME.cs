using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students_Manager_System___With_MySql
{
    public partial class FRM_HOME : Form
    {
        public FRM_HOME()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(12);
        }


        // Close Button ..
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Close();
        }


        // Sing Out button ..  
        private void btnSinOut_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Show();
            Close();
        }

        // add new student button ..
        private void btnAddNewSt_Click(object sender, EventArgs e)
        {
            FRM_ADD_STUDETN FRM = new FRM_ADD_STUDETN();
            FRM.Show();
        }


        // when the form closed ..
        private void FRM_HOME_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["MainForm"].Close();
        }
    }
}
