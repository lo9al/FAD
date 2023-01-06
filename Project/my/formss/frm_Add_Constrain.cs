using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using System.Data.SqlClient;

namespace my.formss
{
    public partial class frm_Add_Constrain : DevExpress.XtraEditors.XtraForm
    {
        public frm_Add_Constrain()
        {
            InitializeComponent();

        }
        mastar op =new mastar();
        public  frm_acount frm_aco;
        public DataTable get_tab_ar_en( string statment , string type)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@type", SqlDbType.NVarChar, 5);
            parm[0].Value = statment;
            parm[1] = new SqlParameter("@viwe", SqlDbType.NVarChar, 50);
            parm[1].Value = type;
           return op.excute("fill_comp", parm);
        }

        public void add_exchange(string id,string st,string sors ,string ty ,string date ,string amoun)
        {
            SqlParameter[] prma = new SqlParameter[1];
            prma[0] = new SqlParameter("@StatementType", SqlDbType.NVarChar, 20);
            prma[0].Value = "Select";
            DataTable dt = op.excute("ins_sel_upd_del_exchange", prma);
            string f = "";
            foreach (DataRow v in dt.Rows)
            {
                f = v["FQ_id"].ToString();
                if (f == id)
                {
                    break;
                }
            }
            SqlParameter[] prm = new SqlParameter[7];
            if (f == id)
            {
                //SqlParameter[] prm = new SqlParameter[7];
                prm[0] = new SqlParameter("@StatementType", SqlDbType.NVarChar, 20);
                prm[0].Value = "Update";
                prm[1] = new SqlParameter("@fq_id", SqlDbType.Int);
                prm[1].Value = id;
                prm[2] = new SqlParameter("@fq_statment", SqlDbType.VarChar, 200);
                prm[2].Value = st;
                prm[3] = new SqlParameter("@fq_source", SqlDbType.VarChar, 50);
                prm[3].Value = sors;
                prm[4] = new SqlParameter("@fq_type", SqlDbType.VarChar, 50);
                prm[4].Value = ty;
                prm[5] = new SqlParameter("@fq_date", SqlDbType.Date);
                prm[5].Value = date;
                prm[6] = new SqlParameter("@fq_amount", SqlDbType.Float);
                prm[6].Value = amoun;
                DataTable dt1 = op.excute("ins_sel_upd_del_exchange", prm);
                MessageBox.Show("تم تحديث بيانات الاستمارة بنجاح");
            }
            else
            {
                prm[0] = new SqlParameter("@StatementType", SqlDbType.NVarChar, 20);
                prm[0].Value = "Insert";
                prm[1] = new SqlParameter("@fq_id", SqlDbType.Int);
                prm[1].Value = id;
                prm[2] = new SqlParameter("@fq_statment", SqlDbType.VarChar, 200);
                prm[2].Value = st;
                prm[3] = new SqlParameter("@fq_source", SqlDbType.VarChar, 50);
                prm[3].Value = sors;
                prm[4] = new SqlParameter("@fq_type", SqlDbType.VarChar, 50);
                prm[4].Value = ty;
                prm[5] = new SqlParameter("@fq_date", SqlDbType.Date);
                prm[5].Value = date;
                prm[6] = new SqlParameter("@fq_amount", SqlDbType.Float);
                prm[6].Value = amoun;
                DataTable dt1 = op.excute("ins_sel_upd_del_exchange", prm);
                MessageBox.Show("تمت إضافة الاستمارة بنجاح");
            }
            
           
        }

        public void add_amunt_to_any_acount(string cul_name)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@fq_id_name", SqlDbType.NVarChar, 256);
            prm[0].Value = "FQ_id";
            prm[1] = new SqlParameter("@coulmn_name", SqlDbType.NVarChar, 256);
            prm[1].Value = cul_name;
            prm[2] = new SqlParameter("@fq_id", SqlDbType.NVarChar, 256);
            prm[2].Value = Text_Ex_Id.Text.Trim();
            prm[3] = new SqlParameter("@coulmn_amount", SqlDbType.NVarChar, 256);
            prm[3].Value = Text_Ex_Amount.Text.Trim();
            DataTable dt;
           dt= op.excute("ins_any_table", prm);
           
        }
        public DataTable fill_comp (string s)
        {
            DataTable dt0 = new DataTable();
            DataTable dt1 = new DataTable();
            dt0 = get_tab_ar_en("en", s);
            dt1 = get_tab_ar_en("ar", s);
            dt0.Columns.Add("Column_Name_Ar", dt1.Columns[0].DataType);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt0.Rows[i]["Column_Name_Ar"] = dt1.Rows[i][0];
            }

            return dt0;
        }
        public void combo(System.Windows.Forms.ComboBox cb,string viwe_name)
        {
            cb.DisplayMember = "Column_Name_Ar";
            cb.ValueMember = "COLUMN_NAME";
            cb.DataSource = fill_comp(viwe_name);
            cb.SelectedIndex = -1;
        }
        private void WindowsUIButtonPanelMain_Click(object sender, EventArgs e)
        {
           
        }

        private void TileBarItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage1;
            
            combo(comb_Ex_Of, "view_fill_comp_Ex_of");
            combo(comb_Ex_Of_1, "view_fill_comp_Ex_of");
            combo(comb_Ex_Of_2, "view_fill_comp_Ex_of");
            combo(comb_Ex_To, "view_fill_comp_Ex_to");
            combo(comb_Ex_To_1, "view_fill_comp_Ex_to");
            combo(comb_Ex_To_2, "view_fill_comp_Ex_to");
        }

        private void TileBarItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage2;
            combo(comb_Ar_of, "view_fill_comp_Ar_of");
            combo(comb_Ar_to, "view_fill_comp_Ar_to");
           
        }

        private void TileBarItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage3;
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Comb_Set_of_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Comb_Ex_Of_SelectedValueChanged(object sender, EventArgs e)
        {if(comb_Ex_Of.SelectedItem != null) label1.Text = comb_Ex_Of.SelectedValue.ToString();
        }

        private void Comb_Ex_To_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comb_Ex_To.SelectedItem != null) label2.Text = comb_Ex_To.SelectedValue.ToString();
        }

        private void WindowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Delete")
            {
                this.Close();
            }
            if (e.Button.Properties.Caption == "Save")
            {
                try
                {
                    {
                        if (navigationFrame1.SelectedPage == navigationPage1)
                        {
                            if (!toggleSwitch1.IsOn && !toggleSwitch2.IsOn && comb_Ex_Of.SelectedIndex != -1 && comb_Ex_To.SelectedIndex != -1)
                            {
                                add_exchange(Text_Ex_Id.Text, Text_Ex_Stat.Text, comb_Ex_sors.Text, groupBox1.Text, date_Ex_Date.Text, Text_Ex_Amount.Text);
                                add_amunt_to_any_acount(comb_Ex_Of.SelectedValue.ToString());
                                add_amunt_to_any_acount(comb_Ex_To.SelectedValue.ToString());
                                frm_aco.select_exchange();

                            }
                            else if (toggleSwitch1.IsOn && !toggleSwitch2.IsOn && comb_Ex_Of.SelectedIndex != -1 && comb_Ex_To.SelectedIndex != -1 && comb_Ex_Of_1.SelectedIndex != -1 && comb_Ex_To_1.SelectedIndex!=-1)
                            {
                                add_exchange(Text_Ex_Id.Text, Text_Ex_Stat.Text, comb_Ex_sors.Text, groupBox1.Text, date_Ex_Date.Text, Text_Ex_Amount.Text);
                                //add_amunt_to_any_acount(comb_Ex_Of.SelectedValue.ToString());
                               // add_amunt_to_any_acount(comb_Ex_To.SelectedValue.ToString());
                                add_amunt_to_any_acount(comb_Ex_Of_1.SelectedValue.ToString());
                                add_amunt_to_any_acount(comb_Ex_To_1.SelectedValue.ToString());
                                frm_aco.select_exchange();
                            }
                            else if (toggleSwitch1.IsOn && toggleSwitch2.IsOn && comb_Ex_Of.SelectedIndex != -1 && comb_Ex_To.SelectedIndex != -1 && comb_Ex_Of_1.SelectedIndex != -1 && comb_Ex_To_1.SelectedIndex != -1 && comb_Ex_Of_2.SelectedIndex != -1 && comb_Ex_To_2.SelectedIndex != -1)
                            {
                                add_exchange(Text_Ex_Id.Text, Text_Ex_Stat.Text, comb_Ex_sors.Text, groupBox3.Text, date_Ex_Date.Text, Text_Ex_Amount.Text);
                               // add_amunt_to_any_acount(comb_Ex_Of.SelectedValue.ToString());
                               // add_amunt_to_any_acount(comb_Ex_To.SelectedValue.ToString());
                               // add_amunt_to_any_acount(comb_Ex_Of_1.SelectedValue.ToString());
                               // add_amunt_to_any_acount(comb_Ex_To_1.SelectedValue.ToString());
                                add_amunt_to_any_acount(comb_Ex_Of_2.SelectedValue.ToString());
                                add_amunt_to_any_acount(comb_Ex_To_2.SelectedValue.ToString());
                                frm_aco.select_exchange();
                            }
                            else
                            {
                                MessageBox.Show("يرجئ تعبئة كل الحقول المطلوبة");
                            }
                            MessageBox.Show("تم الحفظ بنجاح");
                        }
                       else if (navigationFrame1.SelectedPage == navigationPage2)
                        {
                            if (comb_Ar_of.SelectedIndex!=-1 && comb_Ar_to.SelectedIndex!=-1)
                            {
                                add_exchange(Text_Ar_id.Text, Text_Ar_stat.Text, Comb_Ar_sors.Text, groupBox2.Text, Date_Ar_date.Text, Text_Ex_Amount.Text);
                                add_amunt_to_any_acount(comb_Ar_of.SelectedValue.ToString());
                                add_amunt_to_any_acount(comb_Ar_to.SelectedValue.ToString());
                                frm_aco.select_exchange();
                            }
                            else
                            {
                                MessageBox.Show("يرجئ تعبئة كل الحقول المطلوبة");
                            }
                        }
                        else if (navigationFrame1.SelectedPage == navigationPage3)
                        {
                            if (Comb_Set_of.SelectedIndex != -1 && Comb_Set_to.SelectedIndex != -1)
                            {
                                add_exchange(Text_Set_id.Text, Text_Set_stat.Text, Comb_Set_sors.Text, groupBox1.Text, Date_Set_date.Text, Text_Set_amount.Text);
                                add_amunt_to_any_acount(Comb_Set_of.SelectedValue.ToString());
                                add_amunt_to_any_acount(Comb_Set_to.SelectedValue.ToString());
                                frm_aco.select_exchange();
                            }
                            else
                            {
                                MessageBox.Show("يرجئ تعبئة كل الحقول المطلوبة");
                            }
                        }
                        else
                        {
                            MessageBox.Show("يرجئ تحديد نوع الإستمارة المراد إضافتها");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("" + ex.Message + "\n ادخل بيانات الاستمارة بشكل صحيح");
                }
            }     
        }
        public void remove_comb()
        {try
            {
                comb_Ex_Of_1.Items.RemoveAt(comb_Ex_Of.SelectedIndex);
                comb_Ex_Of_2.Items.RemoveAt(comb_Ex_Of.SelectedIndex);
                comb_Ex_Of_2.Items.RemoveAt(comb_Ex_Of_1.SelectedIndex);

                comb_Ex_To_1.Items.RemoveAt(comb_Ex_To.SelectedIndex);
                comb_Ex_To_2.Items.RemoveAt(comb_Ex_To.SelectedIndex);
                comb_Ex_To_2.Items.RemoveAt(comb_Ex_To_1.SelectedIndex);
            }
            catch (SqlException ex)
            { }
        }


        private void Comb_Ex_Of_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Comb_Ex_Of_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ToggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                comb_Ex_Of_1.Visible = true;
                comb_Ex_To_1.Visible = true; 
                lab_Ex_Of_1.Visible=true;
                lab_Ex_To_1.Visible = true;

                toggleSwitch2.Visible = true;
                //comb_Ex_Of_2.Visible = true;
                //comb_Ex_To_2.Visible = true;
                //lab_Ex_Of_2.Visible = true;
                //lab_Ex_To_2.Visible = true;
               // remove_comb();
            }
            else
            {
                comb_Ex_Of_1.Visible = false;
                comb_Ex_To_1.Visible = false;
                lab_Ex_Of_1.Visible = false;
                lab_Ex_To_1.Visible = false;

                toggleSwitch2.Visible = false;
                comb_Ex_To_2.Visible = false;
                comb_Ex_Of_2.Visible = false;
                lab_Ex_Of_2.Visible = false;
                lab_Ex_To_2.Visible = false;
            }
        }

        private void ToggleSwitch2_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch2.IsOn)
            {
                comb_Ex_Of_2.Visible = true;
                comb_Ex_To_2.Visible = true;
                lab_Ex_Of_2.Visible = true;
                lab_Ex_To_2.Visible = true;

               // remove_comb();

            }
            else
            {
                comb_Ex_To_2.Visible = false;
                comb_Ex_Of_2.Visible = false;
                lab_Ex_Of_2.Visible = false;
                lab_Ex_To_2.Visible = false;

               
            }
        }
    }
}