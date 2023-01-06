using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace my
{
    public partial class frm_User_Edit : Form
    {
        public frm_User_Edit()
        {
            InitializeComponent();
        }
        mastar op = new mastar();
        MemoryStream ms;
        public int count;
        byte[] byteImage;

        public void Image_ToByte()
        {
            ms = new MemoryStream();
            pictureBox_Image_User.Image.Save(ms, pictureBox_Image_User.Image.RawFormat);
            byteImage = ms.ToArray();
        }
        //public void Clic_Rows_Edit()
        //{
        //    //d.Image= Dgv_User[4, e.RowIndex].;
        //    frm_User.se.Dgv_User[0,frm_User.Number_Row].Value = textBox_Id_User.Text;
        //    frm_User.se.Dgv_User[1, frm_User.Number_Row].Value = textBox_Nmae_User.Text;
        //    frm_User.se .Dgv_User[2, frm_User.Number_Row].Value = textBox_Password_User.Text;
        //    frm_User.se.Dgv_User[3,frm_User.Number_Row].Value = comboBox_Type_User.Text;
        //    //Bitmap ma = new Bitmap(Dgv_User[4, e.RowIndex].Value.ToString());
        //    //fue.pictureBox_Image_User = Dgv_User[4, e.RowIndex].;
        //    frm_User.se.Dgv_User[5, frm_User.Number_Row].Value = comboBox_Staute_User.Text;
        //    frm_User.se.Dgv_User[6, frm_User.Number_Row].Value = textBox_Id_Oprtion.Text;
        //}
        public void Update_User()
        {
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("@StatementType", SqlDbType.NVarChar, 20);
            prm[0].Value = "Update";
            prm[1] = new SqlParameter("@user1_id", SqlDbType.Int);
            prm[1].Value = Convert.ToInt16(textBox_Id_User.Text.Trim());
            prm[2] = new SqlParameter("@user1_name", SqlDbType.VarChar, 200);
            prm[2].Value = textBox_Nmae_User.Text.Trim();
            prm[3] = new SqlParameter("@user1_pass", SqlDbType.VarChar, 50);
            prm[3].Value = textBox_Password_User.Text.Trim();
            prm[4] = new SqlParameter("@user1_type", SqlDbType.VarChar, 50);
            prm[4].Value = comboBox_Type_User.Text.Trim();
            prm[5] = new SqlParameter("@user1_image", SqlDbType.Image);
            prm[5].Value = byteImage;
            prm[6] = new SqlParameter("@user1_staute", SqlDbType.Bit);
            prm[6].Value = comboBox_Staute_User.Text.Trim();
            prm[7] = new SqlParameter("@operation1_id", SqlDbType.Int);
            prm[7].Value = textBox_Id_Oprtion.Text.Trim();
            DataTable dt = op.excute("ins_sel_upd_del_user", prm);
        }
        private void frm_User_Edit_Load(object sender, EventArgs e)
        {
            textBox_Id_User.Enabled = false;
        }

        private void btn_Add_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "صـــور ‎(*.jpg)|*.jpg|imag (*.png)|*.png|كافة الملفات (*.*)|*.*";
            ofd.ShowDialog();
            Bitmap b = new Bitmap(ofd.FileName);
            pictureBox_Image_User.Image = Image.FromFile(ofd.FileName);
            Image_ToByte();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Update_User_Click_1(object sender, EventArgs e)
        {

            if (textBox_Id_User.Text.Trim() != null &&
               textBox_Nmae_User.Text.Trim() != null &&
               textBox_Password_User.Text.Trim() != null &&
               textBox_Id_Oprtion.Text.Trim() != null &&
               comboBox_Staute_User.SelectedItem != null &&
               comboBox_Type_User.SelectedItem != null)
            {
                Update_User();

                DialogResult d;
                d = MessageBox.Show("تمت إضافة المستخدم بنجاح", "إضافة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    //Clic_Rows_Edit();
                }

            }
        }
    }
}
