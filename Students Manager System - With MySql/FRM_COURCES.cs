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
    public partial class FRM_COURCES : Form
    {
        
        public FRM_COURCES()
        {
            InitializeComponent();
        }


        // close button
        private void btnCancle_Click(object sender, EventArgs e)
        {
            Close();
        }


        // Form load
        private void FRM_COURCES_Load(object sender, EventArgs e)
        {
            FillDGV();
            ReNameDGV();
        }


        // Fill DGV
        void FillDGV()
        {
            try
            {
                Tool.Adapter = new MySqlDataAdapter("SELECT * FROM `tbl_cources`", Tool.MySqlCon);
                Tool.Table = new DataTable();
                Tool.Adapter.Fill(Tool.Table);

                dgvCources.DataSource = Tool.Table;
            }
            catch (Exception ex)
            {
                  MessageBox.Show( ex.Message
                                 , "ادارة المواد"
                                 , MessageBoxButtons.OK
                                 , MessageBoxIcon.Warning
                                 );
            }

        }


        // ReName columns name 
        void ReNameDGV()
        {
            dgvCources.Columns[0].Width = 150;
            dgvCources.Columns[0].ReadOnly = true;
            dgvCources.Columns[0].HeaderText = "معرف المادة";
            dgvCources.Columns[1].HeaderText = "اسم المادة";
        }


        // Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Tool.Builder = new MySqlCommandBuilder(Tool.Adapter);
                Tool.Adapter.Update(Tool.Table);
                MessageBox.Show( "تم الحفظ بنجاح"
                               , "ادارة المواد"
                               , MessageBoxButtons.OK
                               , MessageBoxIcon.Information
                               );
                FillDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message
                               , "ادارة المواد"
                               , MessageBoxButtons.OK
                               , MessageBoxIcon.Warning
                               );
            }
        }
    }
}
