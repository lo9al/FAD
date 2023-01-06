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
    public partial class frm_main1 : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public frm_main1()
        {
            InitializeComponent();
        }
        frm_acount fa;
        frm_control fc;
        frm_report fr;
        frm_login lo;

        private void TileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (fc== null || fc.IsDisposed)
            {
                fc = new frm_control();
                fc.TopLevel = false;
                fc.fm = this;
                panel_viwe.Controls.Add(fc);
                fc.BringToFront();
                fc.Show();
            }
            else
            {
                fc.BringToFront();
            }
        }

   
        private void Frm_main1_Load(object sender, EventArgs e)
        {
            if (lo == null || lo.IsDisposed)
            {
                lo = new frm_login();
                lo.TopLevel = false;
                lo.fm = this;
                panel_viwe.Controls.Add(lo);
                lo.Location = new Point((panel_viwe.Width / 2) - (lo.Width / 2), (panel_viwe.Height / 2) - (lo.Height / 2));
                lo.BringToFront();
                // f.Focus();
                lo.Show();
            }
            else
            {
                lo.BringToFront();
            }
        }

        private void TileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (fa == null || fa.IsDisposed)
            {
                fa = new frm_acount();
                fa.TopLevel = false;
                panel_viwe.Controls.Add(fa);
                fa.BringToFront();
                fa.Show();
            }
            else
            {
                fa.BringToFront();
            }
        }

        private void TileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new frm_report();
                fr.TopLevel = false;
                panel_viwe.Controls.Add(fr);
                fr.BringToFront();
                fr.Show();
            }
            else
            {
                fr.BringToFront();
            }
        }

        private void Panel_viwe_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
