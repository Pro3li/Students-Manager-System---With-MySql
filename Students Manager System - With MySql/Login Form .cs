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


namespace Students_Manager_System___With_MySql
{
    public partial class MainForm : Form
    {
        MySqlConnection _MySqlCon = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString);

        public MainForm()
        {
            InitializeComponent();
        }


        // when the form Load .... 
        private void MainForm_Load(object sender, EventArgs e)
        {
         
        }


        // Login Button .. 
        private void btnLogin_Click(object sender, EventArgs e)
        {

        }


        // Cancle Button ..
        private void btnCancle_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
