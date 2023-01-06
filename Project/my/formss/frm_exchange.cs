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

namespace my
{
    public partial class frm_exchange : Form
    {
        mastar op;
        public frm_exchange()
        {
            InitializeComponent();
            //mastar op = new mastar();
        }
        public void tools_enabel_add()
        {
            label2.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            textBox_dis_add.Enabled = true;
            textBox_amo_add.Enabled = true;
            comboBox_from_add.Enabled = true;
            comboBox_to_add.Enabled = true;
            dateTimePicker_add.Enabled = true;
        }
        public void tools_enabel_edit()
        {
            label2.Enabled = true;
            
            label3.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            textBox_id_add.Enabled = true;
            textBox_dis_add.Enabled = true;
            textBox_amo_add.Enabled = true;
            comboBox_from_add.Enabled = true;
            comboBox_to_add.Enabled = true;
            dateTimePicker_add.Enabled = true;
        }

        //public void add_exchange(int exch, string dis_exch, string sors_exch,string type_exch, DateTime date_exch, float amo_exch)

        public void add_exchange()
        {




            SqlParameter[] prm = new SqlParameter[7];
            prm[0] = new SqlParameter("@StatementType", SqlDbType.NVarChar, 20);
            prm[0].Value = "Insert";
            prm[1] = new SqlParameter("@fq_id", SqlDbType.Int);
            prm[1].Value = textBox_id_add.Text.Trim();
            prm[2] = new SqlParameter("@fq_statment", SqlDbType.VarChar, 200);
            prm[2].Value = textBox_dis_add.Text.Trim();
            prm[3] = new SqlParameter("@fq_source", SqlDbType.VarChar, 50);
            prm[3].Value = textBox_sors_add.Text.Trim();
            prm[4] = new SqlParameter("@fq_type", SqlDbType.VarChar, 50);
            prm[4].Value = 'd';
            prm[5] = new SqlParameter("@fq_date", SqlDbType.Date);
            prm[5].Value = dateTimePicker_add.Text.Trim();
            prm[6] = new SqlParameter("@fq_amount", SqlDbType.Float);
            prm[6].Value = textBox_amo_add.Text.Trim();


            DataTable dt = op.excute("ins_sel_upd_del_exchange", prm);

        }

        public void edit_exchange()
        {


            SqlParameter[] prm = new SqlParameter[7];
            prm[0] = new SqlParameter("@fq_id", SqlDbType.Int);
            prm[0].Value = textBox_id_edit.Text.Trim();
            prm[1] = new SqlParameter("@fq_statment", SqlDbType.VarChar, 200);
            prm[1].Value = textBox_dis_edit.Text.Trim();
            prm[2] = new SqlParameter("@fq_source", SqlDbType.VarChar, 50);
            prm[2].Value = textBox_sors_edit.Text.Trim();
            prm[3] = new SqlParameter("@fq_type", SqlDbType.VarChar, 50);
            prm[3].Value = 'd';
            prm[4] = new SqlParameter("@fq_date", SqlDbType.Date);
            prm[4].Value = dateTimePicker_edit.Text.Trim();
            prm[5] = new SqlParameter("@fq_amount", SqlDbType.Float);
            prm[5].Value = textBox_amo_edit.Text.Trim();
            prm[6] = new SqlParameter("@StatementType", SqlDbType.NVarChar, 20);
            prm[6].Value = "Update";
            DataTable dt = op.excute("ins_sel_upd_del_exchange", prm);


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void exchange_Load(object sender, EventArgs e)
        {
            op = new mastar();

            SqlParameter[] param = new SqlParameter[0];
            DataTable dt = op.excute("count_id", param);
            string count= dt.Rows[0][0].ToString().Trim();
            int i = Convert.ToInt32(count);
            i++;
            textBox_id_add.Text = Convert.ToString(i);


            
            //main_form mf = new main_form();
           // Location = new Point((mf.panel3.Width / 5), (mf.panel3.Height / 3)); //لكي لا يتغير موقع الفورم في كل ضغطة زر 
         


            
        }

        private void button7_Click(object sender, EventArgs e)
        {

            // tools_enabel_add();
            if (panel_edit.Visible == true)
            {

                panel_edit.Visible = false;
            }

            panel_add.Visible = true;
          
            
            
            
           

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            //tools_enabel_edit();

            if (panel_add.Visible == true)
            {
                panel_add.Visible = false;
            }


            panel_edit.Visible = true;
                //panel_face.Controls.Add(panel_edit);
                //panel_add.BringToFront();
            
            
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

       

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void comboBox_from_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

       


       

        private void button4_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (panel_edit.Visible == false)
                {
                    if (textBox_id_add.Text != null && textBox_dis_add.Text != null && textBox_amo_add.Text != null && dateTimePicker_add.Text != null)
                    {
                       add_exchange();
                        MessageBox.Show("تم الحفظ بنجاح");

                    }
                }
                else
                {
                    if (textBox_id_edit.Text != null && textBox_amo_edit.Text != null && dateTimePicker_edit.Text != null)
                    {
                      edit_exchange();
                        MessageBox.Show("تم التعديل بنجاح");


                    }


                }
                    
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex.Message+"\n ادخل بيانات الاستمارة بشكل صحيح");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            frm_acount ac = new frm_acount();
           

            this.Close();
           // ac.dataGridView1.Refresh();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_id_edit_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_id_edit_Leave(object sender, EventArgs e)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@id_exh", SqlDbType.Int);
            prm[0].Value = textBox_id_edit.Text.Trim();
            DataTable dt = op.excute("edit_selecte", prm);
            textBox_dis_edit.Text = dt.Rows[0][0].ToString();
            textBox_amo_edit.Text = dt.Rows[0][4].ToString();
            textBox_sors_edit.Text = dt.Rows[0][1].ToString();
            dateTimePicker_edit.Text = dt.Rows[0][3].ToString();

        }
    }
}
