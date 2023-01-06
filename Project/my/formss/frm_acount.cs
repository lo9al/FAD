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
using my.formss;
using DevExpress.XtraSplashScreen;


namespace my
{
    public partial class frm_acount : Form
    {
        
        mastar op;
        frm_main_form frm = new frm_main_form();
        public frm_acount()
        {
            op = new mastar();
            InitializeComponent();
           

          
        }

        public void select_exchange()
        {


            SqlParameter[] prm = new SqlParameter[0];
            //prm[0] = new SqlParameter("@fq_id", SqlDbType.Int);
            //prm[0].Value = DBNull.Value;
            //prm[1] = new SqlParameter("@fq_statment", SqlDbType.VarChar, 200);
            //prm[1].Value = DBNull.Value;
            //prm[2] = new SqlParameter("@fq_source", SqlDbType.VarChar, 50);
            //prm[2].Value = DBNull.Value;
            //prm[3] = new SqlParameter("@fq_type", SqlDbType.VarChar, 50);
            //prm[3].Value = DBNull.Value;
            //prm[4] = new SqlParameter("@fq_date", SqlDbType.Date);
            //prm[4].Value = DBNull.Value;
            //prm[5] = new SqlParameter("@fq_amount", SqlDbType.Float);
            //prm[5].Value = DBNull.Value;
            //prm[6] = new SqlParameter("@StatementType", SqlDbType.NVarChar, 20);
            //prm[6].Value = "Select";


            DataTable dt = op.excute("show", prm);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            


        }
        private void acount_Load(object sender, EventArgs e)
        {
            select_exchange();
            //select_exchange();
           // dataGridView1.Refresh();
         
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
        //    button1.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //panel4.Visible= true;
            
            frm_exchange ex = new frm_exchange();

            //ex.TopLevel = false;
            //panel4.Controls.Add(ex);
            //ex.BringToFront();
            ex.ShowDialog() ;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            //frm.f = 0;
            
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            select_exchange();
            dataGridView1.Refresh();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void TileNavPane1_Click(object sender, EventArgs e)
        {
                    }

        private void LabelControl1_Click(object sender, EventArgs e)
        {

        }

        private void WindowsUIButtonPanel2_Click(object sender, EventArgs e)
        {

        }

        private void TileBarItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            //navigationFrame1.SelectedPage = navigationPage3;
        }

        private void WindowsUIButtonPanel2_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "إضافة")
            {
                
                frm_Add_Constrain fac = new frm_Add_Constrain();
                fac.frm_aco = this;

                fac.ShowDialog();

            }
            if (e.Button.Properties.Caption == "حذف")
            {
                this.Close();
            }
            if (e.Button.Properties.Caption == "تحديث")
            {
                select_exchange();
            }
        }
    }
}
