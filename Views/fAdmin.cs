using QLSV.Views.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.Views
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }
        private void AddUc(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;

            pn_main.Controls.Clear();
            pn_main.Controls.Add(uc);

            uc.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UcQuanLi uCTask = new UcQuanLi();
            AddUc(uCTask);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UcToa uCToa = new UcToa();
            AddUc(uCToa);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UcDienNuoc uCDN = new UcDienNuoc();
            AddUc(uCDN);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UcHopDong uCHD = new UcHopDong();
            AddUc(uCHD);
        }
    }
}
