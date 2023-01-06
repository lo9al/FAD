using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.IO;

namespace my
{
    public partial class frm_User : Form
    {
        public static frm_User se;
        public static int Number_Row;

        public frm_User()
        {
            InitializeComponent();
            se = this;
        }
        frm_User_Edit fue;
        mastar op = new mastar();

        public void Clic_Rows_Edit() // دالة ترجع بيانات المستخدم لداخل تكستات
        {
            // عاده في مشكلة بأخذ الصورة من الداتا جراد للبكيتشر بوكس   
           // if (fue != null)
            //{
                //fue.BringToFront();
                //d.Image= Dgv_User[4, e.RowIndex].;
                fue.textBox_Id_User.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn1.FieldName.ToString()));
                fue.textBox_Nmae_User.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn2.FieldName.ToString()));
                // fue.textBox_Password_User.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn2.FieldName.ToString()));
                fue.comboBox_Type_User.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn3.FieldName.ToString()));
                //Bitmap ma = new Bitmap(Dgv_User[4, e.RowIndex].Value.ToString());
                //fue.pictureBox_Image_User.Image = Image.FromFile(Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn3.FieldName.ToString())));
                //fue.comboBox_Staute_User.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn1.FieldName.ToString()));
                // fue.textBox_Id_Oprtion.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn1.FieldName.ToString()));

           // }
        }

        public void Delete_User() // دالة حذف مستخدم
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@StatementType", SqlDbType.NVarChar, 20);
            prm[0].Value = "Delete";
            prm[1] = new SqlParameter("@user1_id", SqlDbType.Int);
            prm[1].Value = Number_Row;
            DataTable dt = op.excute("ins_sel_upd_del_user", prm);
        }

        public void Select_All_User() // دالة عرض المستخدمين
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@StatementType", SqlDbType.NVarChar, 20);
            prm[0].Value = "Select";
            DataTable dt = op.excute("ins_sel_upd_del_user", prm);
            Dgv_User.DataSource = dt;
        }

        private void frm_User_Load(object sender, EventArgs e)
        {
            Select_All_User();
        }

        private void Btn_New_User_Click(object sender, EventArgs e)
        {
            frm_User_Add fua = new frm_User_Add();
            fua.count = tileView1.RowCount;
            //  fua.count = Dgv_User.RowCount;
            fua.ShowDialog();
        }

        private void Btn_Viwe_All_Click(object sender, EventArgs e)
        {
             Select_All_User();
        }

        private void Btn_Edit_User_Click(object sender, EventArgs e)
        {
         // if (tileView1.SelectedRowsCount != 0)
            //{
                fue = new frm_User_Edit();
            fue.textBox_Id_User.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn1.FieldName.ToString()));
            fue.textBox_Nmae_User.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn2.FieldName.ToString()));
            // fue.textBox_Password_User.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn2.FieldName.ToString()));
            fue.comboBox_Type_User.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn3.FieldName.ToString()));// fue.textBox_Id_User.Text = Convert.ToString(tileView1.GetRowCellValue(t, tileViewColumn1.FieldName.ToString()));
            fue.ShowDialog();
             Clic_Rows_Edit();
           // }
           // else
           // {
           //     MessageBox.Show("يرجئ تحديد المستخدم المراد تعديل بيانته");
           // }
        }
       
        private void Dgv_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // Clic_Rows_Edit();
            Number_Row = e.RowIndex;
        }

        private void Btn_Delete_User_Click(object sender, EventArgs e)
        {
            //if (Dgv_User != 0)
            //{
            //    DialogResult d;
            //    d = MessageBox.Show("هل تريد الحذف", "حذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (d == DialogResult.OK)
            //    {
 
            //            Delete_User();
            //            Dgv_User.Rows.RemoveAt(Dgv_User.CurrentRow.Index);
            //            MessageBox.Show("تم حذف المستخدم بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("تم إلغاء حذف المستخدم", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("يرجئ تحديد المستخدم المراد حذف بيانته");
            //}
        }
        public int t ;
      
        private void TileView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            t = e.FocusedRowHandle;
        }

        private void Dgv_User_Click(object sender, EventArgs e)
        {

        }
    }
}
