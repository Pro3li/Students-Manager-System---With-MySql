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

        // constractor ..
        public FRM_HOME()
        {
            InitializeComponent();
        }


        // Form Load
        private void Home_Load(object sender, EventArgs e)
        {
            // notifcation on load ..
            //notifyIcon.ShowBalloonTip(12);

            // Date Time 
            lblDate.Text += " " + DateTime.Now.ToString();

            // computer name
            lblComputer.Text += " " + System.Environment.UserName;
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
            FRM_ADD_STUDENT FRM = new FRM_ADD_STUDENT();
            FRM.MdiParent = this;
            FRM.Show();
        }


        // when the form closed ..
        private void FRM_HOME_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["MainForm"].Close();
        }


        // Manage Student Button
        private void btnSMange_Click(object sender, EventArgs e)
        {
            StudentMangeForm();
        }

       
        // Student Manage button ShortCat
        private void btnStudentMange_Click(object sender, EventArgs e)
        {
            StudentMangeForm();
        }


        // call Student Mange Form
        private void StudentMangeForm()
        {
            FRM_STUDENT_MANAGE FRM = new FRM_STUDENT_MANAGE();
            FRM.MdiParent = this;
            FRM.Show();
        }
    }
}
