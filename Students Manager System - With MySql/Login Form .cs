using System;
using System.Data;
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
            if (txtUserName.Text.Trim() != "" && txtPassword.Text.Trim() != "")
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

                    if (_Table.Rows.Count > 0)
                    {
                        MessageBox.Show("تم تسجيل الدخول بنجاح ، اهلا وسهلا بك"
                                     , "تسجيل الدخول "
                                     , MessageBoxButtons.OK
                                     , MessageBoxIcon.Information
                                    );
                        
                        // clear ..
                        txtUserName.Clear();
                        txtPassword.Clear();

                        this.Hide();
                        Home FRM_HOME = new Home();
                        FRM_HOME.Show();
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
                    MessageBox.Show(   ex.Message
                                     , "تسجيل الدخول "
                                     , MessageBoxButtons.OK
                                     , MessageBoxIcon.Information
                                    );
                } 
            }
            else
            {
                MessageBox.Show("لا يُمكن تَرك احد الحقول فارغاً"
                 , "تسجيل الدخول "
                 , MessageBoxButtons.OK
                 , MessageBoxIcon.Warning
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
