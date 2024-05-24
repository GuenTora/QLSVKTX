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
    public partial class UcToa : UserControl
    {
        private int selected = -1;
        public UcToa()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            dtgvToa.DataSource = DBConnection.Instance.ExecuteQuery("select * from toa");
            selected = -1;
        }

        private void dtgvToa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selected = 1;
                object value = dtgvToa.Rows[e.RowIndex].Cells[0].Value;
                if (value != DBNull.Value)
                {
                    DataGridViewRow row = dtgvToa.Rows[e.RowIndex];

                    // Hiển thị dữ liệu lên các đối tượng TextBox
                    txtQuanli.Text = row.Cells[0].Value.ToString();
                    txthoTen.Text = row.Cells[1].Value.ToString();
                    txtToaQuanLi.Text = row.Cells[2].Value.ToString();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selected != -1)
            {
                try
                {
                    string gioitinh = (txtToaQuanLi.Text == "Nam") ? "nam" : "nu";
                    DBConnection.Instance.ExecuteQuery("UTP_SuaToa @matoa , @tentoa , @Gioitinh ", new object[] { txtQuanli.Text, txthoTen.Text, gioitinh});
                    Load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Message");
                }
            }
            else
                MessageBox.Show("Chọn 1 dòng để sửa");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemToa fThemToa = new fThemToa();
            fThemToa.ShowDialog();
        }
    }
}
