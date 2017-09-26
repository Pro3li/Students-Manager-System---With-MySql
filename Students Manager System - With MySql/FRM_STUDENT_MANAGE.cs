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
    public partial class FRM_STUDENT_MANAGE : Form
    {

        // Data View For filtering
        DataView Dview = new DataView();


        // constractor 
        public FRM_STUDENT_MANAGE()
        {
            InitializeComponent();
        }


        // add student 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRM_ADD_STUDENT FRM = new FRM_ADD_STUDENT();
            FRM.ShowDialog();
            fillDGVStudent();
        }


        // close
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        //Form load ...
        private void FRM_STUDENT_MANAGE_Load(object sender, EventArgs e)
        {
            fillDGVStudent();
            ReNameDGVcolums();
        }


        // fill DGV ...
        void fillDGVStudent()
        {
            Tool.Adapter = new MySqlDataAdapter("SELECT * FROM tbl_student", Tool.MySqlCon);
            Tool.Table = new DataTable();
            Tool.Adapter.Fill(Tool.Table);
            dgvStudent.DataSource = Tool.Table;
            
        }


        // ReName DGV Columns ...
        private void ReNameDGVcolums()
        {
            dgvStudent.Columns[0].Width = 80;
            dgvStudent.Columns[1].Width = 230;
            dgvStudent.Columns[0].HeaderText = "المعرف";
            dgvStudent.Columns[1].HeaderText = "اسم الطالب";
            dgvStudent.Columns[2].HeaderText = "عنوان الطالب";
            dgvStudent.Columns[3].HeaderText = "تاريخ الميلاد";
        }


        // Search Function ...
        void Serach()
        {
            try
            {
                Dview = Tool.Table.DefaultView;
                Dview.RowFilter = "Name+Addres LIKE '%" + txtSearch.Text + "%'";
                dgvStudent.DataSource = Dview;
            }
            catch (Exception ex)
            {

                return;
            }
        }


        // Delete Student
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل انت متأكد من حذف الطالب : " + dgvStudent.CurrentRow.Cells[1].Value
                                           , "حذف طالب"
                                           , MessageBoxButtons.OK
                                           , MessageBoxIcon.Information
                                         )
                          == DialogResult.OK
                   )
                {
                    string Query = "DELETE FROM `tbl_student` WHERE `tbl_student`.`ID` = " + dgvStudent.CurrentRow.Cells[0].Value;
                    Tool.Command = new MySqlCommand(Query, Tool.MySqlCon);
                    Tool.Connect();   // open
                    Tool.Command.ExecuteNonQuery();

                    // Update
                    fillDGVStudent();

                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show(    ex.Message 
                                  , "حذف طالب"
                                  , MessageBoxButtons.OK
                                  , MessageBoxIcon.Information
                               );
            }
            finally
            {
                Tool.DisConnect();  // close connection 
            }

                
        }


        // Serach operation
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Serach();
        }


        // Edit Operation
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FRM_ADD_STUDENT FRM = new FRM_ADD_STUDENT();

            // Edit some thing .. 
            FRM.Choise = "Edit"; 
            FRM.Student_ID = dgvStudent.CurrentRow.Cells[0].Value.ToString();

            FRM.btnAdd.Text = "تعديل";
            FRM.lblLogoText.Text = "تعديل احد الطلاب";
            FRM.Text = "تعديل الطالب : " + dgvStudent.CurrentRow.Cells[1].Value.ToString();
            FRM.txtName.Text = dgvStudent.CurrentRow.Cells[1].Value.ToString();
            FRM.txtAddress.Text = dgvStudent.CurrentRow.Cells[2].Value.ToString();
            FRM.dtBirthDate.Value = Convert.ToDateTime(dgvStudent.CurrentRow.Cells[3].Value.ToString());
            
            FRM.ShowDialog();
            fillDGVStudent();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
