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

        public string Choise = "Add";

        public string Student_ID;

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
            string Query = ""; 

            // check if this form is for add or Edit Student .. 
            if ( Choise == "Add")
                Query = "INSERT INTO tbl_student (Name,Addres,Date) VALUES (@Name,@Address,@Date)";
            else if ( Choise == "Edit" )
                Query = "UPDATE `tbl_student` SET `Name` = @Name, `Addres` = @Address, `Date` = @Date WHERE `tbl_student`.`ID` = " + Student_ID ;

            try
            {
                if ( txtName.Text.Trim() != "" && txtAddress.Text.Trim() != "")
                {
                    Tool.Command = new MySqlCommand(Query, Tool.MySqlCon);
                    MySqlParameter[] Parm = new MySqlParameter[3];

                    Parm[0] = new MySqlParameter("@Name", MySqlDbType.VarChar, 50);
                    Parm[1] = new MySqlParameter("@Address", MySqlDbType.VarChar, 100);
                    Parm[2] = new MySqlParameter("@Date", MySqlDbType.Date);

                    Parm[0].Value = txtName.Text;
                    Parm[1].Value = txtAddress.Text;
                    Parm[2].Value = dtBirthDate.Value.Date;

                    Tool.Command.Parameters.AddRange(Parm);

                    Tool.MySqlCon.Open();

                    Tool.Command.ExecuteNonQuery();

                    MessageBox.Show("تمت العملية بنجاح"
                                         , "ادارة الطلاب"
                                         , MessageBoxButtons.OK
                                         , MessageBoxIcon.Information
                                    ); 
                }
                else
                {
                    MessageBox.Show(     "لايمكن ترك احد الحقول فارغاً"
                                         , "ادارة الطلاب"
                                         , MessageBoxButtons.OK
                                         , MessageBoxIcon.Warning
                                    );

                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show(     ex.Message
                                     , "ادارة الطلاب"
                                     , MessageBoxButtons.OK
                                     , MessageBoxIcon.Warning
                            );
            }
            finally
            {
                Tool.MySqlCon.Close();
            }


        }
    }
}
