using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Students_Manager_System___With_MySql
{
    public partial class MainForm : Form
    {

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
                    
                    Tool.Adapter = new MySqlDataAdapter("SELECT * FROM tbl_users WHERE username = @User AND password = @Pass", Tool.MySqlCon);

                    // using MySql Parameter 
                    MySqlParameter[] _Parm = new MySqlParameter[2];
                    _Parm[0] = new MySqlParameter("@User", MySqlDbType.VarChar, 50);
                    _Parm[1] = new MySqlParameter("@Pass", MySqlDbType.VarChar, 50);
                    _Parm[0].Value = txtUserName.Text;
                    _Parm[1].Value = txtPassword.Text;

                    // add parameter to command ..
                    Tool.Adapter.SelectCommand.Parameters.AddRange(_Parm);

                    // new instance 
                    Tool.Table = new DataTable();

                    Tool.Adapter.Fill(Tool.Table);

                    if (Tool.Table.Rows.Count > 0)
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
                        FRM_HOME FRM_HOME = new FRM_HOME();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
