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
        // connection 
        MySqlConnection _MySqlCon = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString);


        // MySql DataReader .. 
        MySqlDataAdapter _Adapter;

        // Table ..
        DataTable _Table = new DataTable();

        // Constractor .. 
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
            try
            {
                _Table.Clear();
                _Adapter = new MySqlDataAdapter("SELECT * FROM tbl_users WHERE username = @User AND password = @Pass", _MySqlCon);
                
                // using MySql Parameter 
                MySqlParameter[] _Parm = new MySqlParameter[2];
                _Parm[0] = new MySqlParameter("@User", MySqlDbType.VarChar, 50);
                _Parm[1] = new MySqlParameter("@Pass", MySqlDbType.VarChar, 50);
                _Parm[0].Value = txtUserName.Text;
                _Parm[1].Value = txtPassword.Text;

                // add parameter to command ..
                _Adapter.SelectCommand.Parameters.AddRange(_Parm);

                _Adapter.Fill(_Table);

                if (_Table.Rows.Count > 0 )
                {
                    MessageBox.Show("تم تسجيل الدخول بنجاح ، اهلا وسهلا بك"
                                 , "تسجيل الدخول "
                                 , MessageBoxButtons.OK
                                 , MessageBoxIcon.Information
                                );
                }
                else
                {
                    MessageBox.Show("تأكد من اسم المستخدم او كلمة المرور قد يحتوي احدهما على خطأ"
                                 , "تسجيل الدخول "
                                 , MessageBoxButtons.OK
                                 , MessageBoxIcon.Warning
                                );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "حصل خطأ ما!"
                                 , "تسجيل الدخول " 
                                 , MessageBoxButtons.OK
                                 , MessageBoxIcon.Information
                                );
            }
        }


        // Cancle Button ..
        private void btnCancle_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
