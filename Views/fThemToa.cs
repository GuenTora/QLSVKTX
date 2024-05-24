using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.Views.UC
{
    public partial class fThemToa : Form
    {
        public fThemToa()
        {
            InitializeComponent();
            loadcb();
        }

        void loadcb()
        {
            cbToaQuanLi.Items.Add("Nam");
            cbToaQuanLi.Items.Add("Nữ");
            cbToaQuanLi.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = txtQuanli.Text;
            if (!a.IsNullOrEmpty())
                try
                {
                    string gioitinh = (cbToaQuanLi.Text == "Nam") ? "nam" : "nu";
                    DBConnection.Instance.ExecuteQuery("USP_ThemToa @matoa , @tentoa , @gioitinh ", new object[] { txtQuanli.Text, txthoTen.Text, gioitinh });
                    MessageBox.Show("Thêm tòa thành công", "Message");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Message"); }
            else
                MessageBox.Show("Điền đầy đủ thông tin", "Message");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
