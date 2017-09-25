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
    public partial class FRM_ADD_STUDENT : Form
    {
        public FRM_ADD_STUDENT()
        {
            InitializeComponent();
        }

        // cancle ..
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Add Button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tool.Command = new MySqlCommand("INSERT INTO tbl_student (Name,Addres,Date) VALUES (@Name,@Address,@Date)", tool.MySqlCon);
                MySqlParameter[] Parm = new MySqlParameter[3];

                Parm[0] = new MySqlParameter("@Name", MySqlDbType.VarChar, 50);
                Parm[1] = new MySqlParameter("@Address", MySqlDbType.VarChar, 100);
                Parm[2] = new MySqlParameter("@Date", MySqlDbType.Date);

                Parm[0].Value = txtName.Text;
                Parm[1].Value = txtAddress.Text;
                Parm[2].Value = dtBirthDate.Value.Date;

                tool.Command.Parameters.AddRange(Parm);

                tool.MySqlCon.Open();

                tool.Command.ExecuteNonQuery();

                MessageBox.Show(    "اضافة الطالب بنجاح"
                                     , "تسجيل الدخول "
                                     , MessageBoxButtons.OK
                                     , MessageBoxIcon.Information
                                );
            }
            catch ( Exception ex )
            {
                MessageBox.Show(     ex.Message
                                     , "اضافة طالب "
                                     , MessageBoxButtons.OK
                                     , MessageBoxIcon.Warning
                            );
            }
            finally
            {
                tool.MySqlCon.Close();
            }


        }
    }
}
