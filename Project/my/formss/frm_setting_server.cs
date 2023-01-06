using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my
{
    public partial class frm_setting_server : Form
    {
        public frm_setting_server()
        {
            InitializeComponent();
        }
        mastar op;
      
        private void Btn_check_conection(object sender, EventArgs e)
        {
            if (text_Server_Name.Text.Trim() != null && text_DataBase_name.Text.Trim() != null)
            {
                Properties.Settings.Default.Servar_name = text_Server_Name.Text.Trim();
                Properties.Settings.Default.DataBase_name = text_DataBase_name.Text.Trim();
                op = new mastar();
                if (op.IsServerConnected()== true)
                {
                    MessageBox.Show("تم الاتصال بالسيرفر بنجاح ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (op.IsServerConnected()==false)
                {
                    MessageBox.Show("فشل الاتصال بالسيرفر", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("يرجئ تعبئة الاعدادت الجديده كاملة");
            }
        }

        private void btn_Save_New_Sitting_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (text_Server_Name.Text.Trim() != null && text_DataBase_name.Text.Trim() != null)
            {
                Properties.Settings.Default.Servar_name = text_Server_Name.Text.Trim();
                Properties.Settings.Default.DataBase_name = text_DataBase_name.Text.Trim();
                op = new mastar();
                if (op.IsServerConnected()== true)
                {
                    res= MessageBox.Show("تم الاتصال بالسيرفر بنجاح \n هل تريد حفظ الإعدادت الجديدة واغلاق النافذة ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                }
                else if (op.IsServerConnected()== false)
                {
                    MessageBox.Show("فشل الاتصال بالسيرفر يرجئ ادخال بيانات السرفر بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Properties.Settings.Default.Reset();
                    text_Server_Name.Clear();
                    text_Server_Name.Focus();
                    text_DataBase_name.Clear();
                }
            }
            else
            {
                MessageBox.Show("يرجئ تعبئة الاعدادت الجديده كاملة");
            }
        }
    }
}
