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
    public partial class FRM_MARKS : Form
    {

        // Tables ..
        DataTable Student = new DataTable();
        DataTable Cources = new DataTable();
        DataTable Marks = new DataTable();


        // constractor ..
        public FRM_MARKS()
        {
            InitializeComponent();
        }


        // fill Combo function ..
        void FillCombo( DataTable tb , string tableName , ComboBox Cb)
        {
            Tool.Adapter = new MySqlDataAdapter("SELECT * FROM "+ tableName , Tool.MySqlCon);
            Tool.Adapter.Fill(tb);

            Cb.DataSource = tb;
            Cb.DisplayMember = "Name";
            Cb.ValueMember = "ID";
        }


        // close ..
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        // Form load ..
        private void FRM_MARKS_Load(object sender, EventArgs e)
        {
            
                    // Data table , Table name in DataBase , ComboBooks Control
            FillCombo( Student , "tbl_student", cmbSName );
            FillCombo( Cources , "tbl_cources", cmbCName );

            if (!string.IsNullOrWhiteSpace(cmbCName.Text))
            {
                FillDGV();
                ChangeDGVname();
            }
        }


        // Save button ..
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCName.Text.Trim() != "" && cmbSName.Text.Trim() != "" && txtMarks.Text.Trim() != "")
            {
                try
                {
                    string Query = "INSERT INTO `tbl_marks` (`S_ID`, `C_ID`, `MARK`) VALUES (@SID, @CID, @MARKS)";
                    Tool.Command = new MySqlCommand(Query, Tool.MySqlCon);
                    MySqlParameter[] Parm = new MySqlParameter[3];

                    Parm[0] = new MySqlParameter("@SID", MySqlDbType.Int32);
                    Parm[1] = new MySqlParameter("@CID", MySqlDbType.Int32);
                    Parm[2] = new MySqlParameter("@MARKS", MySqlDbType.Int32);

                    Parm[0].Value = cmbSName.SelectedValue;
                    Parm[1].Value = cmbCName.SelectedValue;
                    Parm[2].Value = txtMarks.Text;

                    Tool.Command.Parameters.AddRange(Parm);

                    Tool.Connect();
                    Tool.Command.ExecuteNonQuery();

                    MessageBox.Show("تمت العملية بنجاح"
                                         , "ادارة الدرجات"
                                         , MessageBoxButtons.OK
                                         , MessageBoxIcon.Information
                                    );

                    FillDGV();
                }
                catch (MySqlException ex )
                {
                    MessageBox.Show(     "هذا الطالب لديه درجة مُسجلة في نفس المادة"
                                         , "ادارة الدرجات"
                                         , MessageBoxButtons.OK
                                         , MessageBoxIcon.Warning
                                );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(     ex.Message
                                         , "ادارة الدرجات"
                                         , MessageBoxButtons.OK
                                         , MessageBoxIcon.Warning
                                );
                }
                finally
                {
                    Tool.DisConnect();
                }

            }
            else
            {
                MessageBox.Show("لايمكن ترك احد الحقول فارغاً"
                                     , "ادارة الدرجات"
                                     , MessageBoxButtons.OK
                                     , MessageBoxIcon.Warning
                                );

            }
        }


        // Fill DGV
        void FillDGV()
        {
            Marks.Clear();
            Tool.Adapter = new MySqlDataAdapter("SELECT tbl_student.Name, tbl_marks.MARK " +
                                                "FROM tbl_student ,tbl_marks, tbl_cources " +
                                                "WHERE tbl_marks.S_ID = tbl_student.ID AND tbl_marks.C_ID = tbl_cources.ID And tbl_marks.C_ID = " + cmbCName.SelectedValue                                            
                                                , Tool.MySqlCon);
            
            Tool.Adapter.Fill(Marks);
            dgvMarks.DataSource = Marks;

        }


        // Change DGV Columns Name 
        void ChangeDGVname()
        {
            dgvMarks.Columns[0].HeaderText = "اسم الطالب";
            dgvMarks.Columns[1].HeaderText = "الدرجة";
        }


        // chois Cource ... 
        private void cmbCName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillDGV();
                ChangeDGVname();

            }
            catch (Exception)
            {

                return;
            }
        }
    }
}
