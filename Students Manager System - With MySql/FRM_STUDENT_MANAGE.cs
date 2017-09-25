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
    public partial class FRM_STUDENT_MANAGE : Form
    {
        public FRM_STUDENT_MANAGE()
        {
            InitializeComponent();
        }

        // add student 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRM_ADD_STUDENT FRM = new FRM_ADD_STUDENT();
            FRM.ShowDialog();
        }

        // close
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
