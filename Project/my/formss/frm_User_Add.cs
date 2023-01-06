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
    public partial class frm_User_Add : Form
    {
        public frm_User_Add()
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
        public void Add_User()
        {
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("@StatementType", SqlDbType.NVarChar, 20);
            prm[0].Value = "Insert";
            prm[1] = new SqlParameter("@user1_id", SqlDbType.Int);
            prm[1].Value = textBox_Id_User.Text.Trim();
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
            DataTable dt; dt = op.excute("ins_sel_upd_del_user", prm);
            
        }
        private void frm_User_Add_Load(object sender, EventArgs e)
        {
            textBox_Id_User.Text = Convert.ToString(count + 1);
            textBox_Id_User.Enabled = false;
        }

        private void btn_Add_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "صـــور ‎(*.jpg)|*.jpg|imag (*.png)|*.png|كافة الملفات (*.*)|*.*";
            ofd.ShowDialog();
            Bitmap b = new Bitmap(ofd.FileName);
            pictureBox_Image_User.Image =Image.FromFile(ofd.FileName);
            Image_ToByte();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Save_User_Click(object sender, EventArgs e)
        {
            if (textBox_Id_User.Text.Trim() != null &&
                textBox_Nmae_User.Text.Trim() != null &&
                textBox_Password_User.Text.Trim() != null &&
                textBox_Id_Oprtion.Text.Trim() != null &&
                comboBox_Staute_User.SelectedItem != null &&
                comboBox_Type_User.SelectedItem != null)
            {
                Add_User();
                
                DialogResult d;
                d = MessageBox.Show("تمت إضافة المستخدم بنجاح", "إضافة", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (d==DialogResult.Yes)
                {

                    textBox_Nmae_User.Clear();
                    textBox_Password_User.Clear();
                    textBox_Id_Oprtion.Clear();
                    comboBox_Staute_User.SelectedIndex=0;
                    comboBox_Type_User.SelectedItem = null;
                    frm_User.se.Select_All_User();
                   
                   // textBox_Id_User.Text = frm_User.se.Dgv_User.RowCount.ToString();
                   // frm_User.se.Dgv_User.Rows[Convert.ToInt16( textBox_Id_User.Text)-1].Selected = true;
                }
                
            }
        }
    }
}
