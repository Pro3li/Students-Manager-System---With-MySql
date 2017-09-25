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
            tool.Adapter = new MySqlDataAdapter("SELECT Name,Addres,Date FROM tbl_student", tool.MySqlCon);
            tool.Table = new DataTable();
            tool.Adapter.Fill(tool.Table);
            dgvStudent.DataSource = tool.Table;
            
        }


        // ReName DGV Columns ...
        private void ReNameDGVcolums()
        {
            dgvStudent.Columns[0].Width = 280;
            dgvStudent.Columns[0].HeaderText = "اسم الطالب";
            dgvStudent.Columns[1].HeaderText = "عنوان الطالب";
            dgvStudent.Columns[2].HeaderText = "تاريخ الميلاد";
        }

        // Search Function ...
        void Serach()
        {
            try
            {
                Dview = tool.Table.DefaultView;
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
            
        }


        // Serach operation
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Serach();
        }
    }
}
