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
    public partial class frm_main_form : Form
    {
        public static frm_main_form self;

        public frm_main_form()
        {
            InitializeComponent();
            self = this;
        }
        //mastar op  = new mastar();
      
        public frm_main_form(int v_user_id, string v_user_name, string v_user_type)
        {
           
            //InitializeComponent();
          // enb(); // الغاء التفعيل
           // frm_initaize();
            //Search_Data_User_Now(v_user_id, v_user_name,v_user_type); // جلب بيانات المستخدم الحالي واعداد الواجهة الرئيسية

        }
       
        
            
        

        private void strip_control_Click(object sender, EventArgs e)
        {
            frm_control co = new frm_control();
            co.TopLevel = false;
            panel_Vewi_Form.Controls.Add(co);
            co.BringToFront();
            co.Show();
            //op.open_frm(this, co);


        }


        private void Strip_Account_Click(object sender, EventArgs e)
        {                     
            frm_acount ac = new frm_acount();
            ac.TopLevel = false;
            panel_Vewi_Form.Controls.Add(ac);
            ac.BringToFront();
            ac.Show();
        }
        frm_login f;

        private void main_form_Load(object sender, EventArgs e)
        {

            lab_data.Text = DateTime.Now.ToString("ddd") + "\n" + DateTime.Now.ToShortDateString();
            //lab_data2.Text = DateTime.Now.ToShortDateString();
           f = new frm_login();
            f.TopLevel = false;
           f.MdiParent = this;
            panel_Vewi_Form.Controls.Add(f);
            f.Location = new Point((panel_Vewi_Form.Width / 2) - (f.Width / 2), (panel_Vewi_Form.Height / 2) - (f.Height / 2));
            f.BringToFront();
           // f.Focus();
            f.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
          frm_report re = new frm_report();
            re.TopLevel = false;
            panel_Vewi_Form.Controls.Add(re);
            re.BringToFront();
            re.Show();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel_Vewi_Form.Controls.Clear();
            this.panel_Tool_Strip.Enabled = false;
            if (f!=null)
            {
                f = new frm_login();
                f.TopLevel = false;
                f.MdiParent = this;
                panel_Vewi_Form.Controls.Add(f);
                f.Location = new Point((panel_Vewi_Form.Width / 2) - (f.Width / 2), (panel_Vewi_Form.Height / 2) - (f.Height / 2));
                f.BringToFront();
                f.Show();
            }
            else
            {
                f.Focus();
            }

        }
    }
}
