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
    public partial class UcQuanLi : UserControl
    {
        private int selected = -1;
        public UcQuanLi()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            dtgvQuanLi.DataSource = DBConnection.Instance.ExecuteQuery("select * from quanly");
            selected = -1;
        }

        private void dtgvQuanLi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selected = 1;
                object value = dtgvQuanLi.Rows[e.RowIndex].Cells[0].Value;
                if (value != DBNull.Value)
                {
                    DataGridViewRow row = dtgvQuanLi.Rows[e.RowIndex];

                    // Hiển thị dữ liệu lên các đối tượng TextBox
                    txtQuanli.Text = row.Cells[0].Value.ToString();
                    txthoTen.Text = row.Cells[1].Value.ToString();
                    txtToaQuanLi.Text = row.Cells[2].Value.ToString();
                    txtChucVu.Text = row.Cells[3].Value.ToString();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemQuanLy f = new fThemQuanLy();
            f.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selected != -1)
            {
                DBConnection.Instance.ExecuteQuery(string.Format("delete from quanly where MaQL = '{0}'", txtQuanli.Text));
                Load();
            }
            else
                MessageBox.Show("Chọn 1 dòng để xóa");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selected != -1)
            {
                try
                {
                    DBConnection.Instance.ExecuteQuery("UTP_SuaQuanLy @maql , @ten , @maToa , @chucVu ", new object[] { txtQuanli.Text, txthoTen.Text, txtToaQuanLi.Text, txtChucVu.Text });
                    Load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message,"Message");
                }
            }
            else
                MessageBox.Show("Chọn 1 dòng để sửa");
        }
    }
}
