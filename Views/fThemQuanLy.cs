using Microsoft.IdentityModel.Tokens;
using QLSV.DTO;
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
    public partial class fThemQuanLy : Form
    {
        public fThemQuanLy()
        {
            InitializeComponent();
            loadcb();
        }

        void loadcb()
        {
            cbToaQuanLi.DataSource = DBConnection.Instance.ExecuteQuery("USP_TimToaChuaCoNguoiQuanLi");
            cbToaQuanLi.DisplayMember = "MaToa";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = cbToaQuanLi.Text;
            if (!a.IsNullOrEmpty())
                try
                {
                    DBConnection.Instance.ExecuteQuery("USP_ThemQuanLy @maql , @ten , @maToa , @chucVu ", new object[] { txtQuanli.Text, txthoTen.Text, cbToaQuanLi.Text, txtChucVu.Text });
                    MessageBox.Show("Thêm quản lí thành công", "Message");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Message"); }
            else
                MessageBox.Show("Điền đầy đủ thông tin", "Message");

        }
    }
}
