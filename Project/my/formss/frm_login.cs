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
    public partial class frm_login : Form
    {

        int user_count_lo = 0;
        public frm_login()
        {
            InitializeComponent();
        }
        mastar op;
        public frm_main1 fm;
        public void loginl()
        {
            //f = new frm_main_form();
             op = new mastar();

            try
            {
                if (user_count_lo < 3)
                {
                    SqlParameter[] prm = new SqlParameter[2];
                    prm[0] = new SqlParameter("@usar_name", SqlDbType.NVarChar, 50);
                    prm[0].Value = TextBox_user_name.Text.Trim();
                    prm[1] = new SqlParameter("@usar_pass", SqlDbType.NVarChar, 50);
                    prm[1].Value = TextBox_password.Text.Trim();
                    DataTable dt = op.excute("login_user", prm);

                    if (dt.Rows.Count == 1)
                    {
                        if (dt.Columns[0].ColumnName.ToString().Trim() != "e_id")
                        {
                            //if(f==null || f.IsDisposed)
                            //{
                            //  //  f = new main_form(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                            //    //f.Show();
                            //    f = new main_form();
                            //    f.toolStripMenuItem1.Enabled = true;
                            //    f.toolStripMenuItem2.Enabled = true;
                            //    f.toolStripMenuItem3.Enabled = true;
                            //}
                            //else
                            //{
                            //    f.Focus();
                            //}
                           
                            fm.Panal_Tital.Enabled = true;

                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show(dt.Rows[0][1].ToString(), "رسالة خطاء", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            user_count_lo++;
                            lab_forget_pass_username.Visible = true;
                            int count = 3 - user_count_lo;
                            lab_forget_pass_username.Text = "بيانات الدخول غير صحيحة \n تبقئ لديك " + count + "محاولة";
                        }
                    }
                    else
                    {
                        MessageBox.Show("اعد المحاولة");
                    }
                }
                else
                {
                    Application.Exit();
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message.ToString() +"\n===============\n"+ ex.Source.ToString());
            }
        }
        private void login_Load(object sender, EventArgs e)
        {
            ////f.toolStripMenuItem1.Enabled = false;
            ////f.toolStripMenuItem2.Enabled = false;
            ////f.toolStripMenuItem3.Enabled = false;
            //this.TopLevel = false;
            //f.panel3.Controls.Add(this);
            //f.lab_data.Text = DateTime.Now.ToString("ddd");
            //f.lab_data2.Text = DateTime.Now.ToShortDateString();
            //this.Location = new Point((f.panel3.Width / 2), (f.panel3.Height / 2) - this.Height / 2);
            //BringToFront();
            //this.Focus();
            //f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_setting_server fs = new frm_setting_server();
            mastar op = new mastar();

            try
            {
                if (op.IsServerConnected()== false)
                {
                    fs.ShowDialog();
                }
                else
                {
                    if (TextBox_user_name.Text.ToString().Trim() != null && TextBox_password.Text.ToString().Trim() != null)
                    loginl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"خطاء");
            }
            TextBox_user_name.Clear();
            TextBox_password.Clear();
            TextBox_user_name.Focus();


        }



        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            label4.Image = Properties.Resources.eye1;
            TextBox_password.UseSystemPasswordChar = false;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {

        }

        private void label4_MouseClick_1(object sender, MouseEventArgs e)
        {
            label4.Image = Properties.Resources.hide_21;
            TextBox_password.UseSystemPasswordChar = true;

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
