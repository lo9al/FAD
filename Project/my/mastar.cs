using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace my
{
    class mastar
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;


        public mastar()
        {
            // con = new SqlConnection(@"Data Source = DESKTOP-9M9DRUM\L09AL; Initial Catalog = department_U_Ibb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            //Data Source = DESKTOP - 9M9DRUM\L09AL; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False
            // Data Source = DESKTOP - 9M9DRUM\L09AL; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False
            // con = new SqlConnection(@"Data Source=DESKTOP-O8LP43A;Initial Catalog=department_U_Ibb;Integrated Security=True");
            con = new SqlConnection(connectionString: @"Data Source=" + Properties.Settings.Default.Servar_name + ";Initial Catalog=" + Properties.Settings.Default.DataBase_name + ";Integrated Security=True");
        }
        public bool IsServerConnected()
        {
            try
            {
                con.Open();
                if (con.State==ConnectionState.Open)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 40 || ex.Number == 26)
                {
                    return false;
                }
                else
                {
                    return false;
                }
                

            }

        }

        public DataTable excute(string pro, SqlParameter[] prm)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                if (prm != null)
                {
                    cmd.Parameters.AddRange(prm);
                }
                cmd.CommandText = pro;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;

                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\n===========\n" + ex.Server.ToString() + "\n===========\n" + ex.Source.ToString() + "\n===========\n" + ex.Data.ToString(), "+++");
                return null;

            }
        }
        public int f = 0;
        public void open_frm(frm_main_form m, frm_acount b) // دالة تعرض الفورم a بداخل الفورم الرئيسي
        {

            if (f == 0)
            {
                b = new frm_acount();
                b.TopLevel = false;
                m.panel_Vewi_Form.Controls.Add(b);
                b.BringToFront();
                b.Show();
                f = 1;
            }

            else if (f == 1)
            {
                b.Close();
                b = new frm_acount();
                b.TopLevel = false;
                m.panel_Vewi_Form.Controls.Add(b);
                b.BringToFront();
                b.Show();
                f = 1;
            }
            else
            {
                m.panel_Vewi_Form.Refresh();
            }

            //bool isopon = false;


            //foreach (Form f in Application.OpenForms)
            //{
            //    if (f.Text == m.Text && )
            //    {
            //        isopon = true;
            //        // f.BringToFront();
            //        break;
            //    }

            //}
            //if (isopon == false)
            //{
            //    b.TopLevel = false;
            //    m.panel3.Controls.Add(b);
            //    b.BringToFront();
            //    b.Show();

            //}


        }



    }
}
