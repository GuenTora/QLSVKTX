using QLSV.DAO;
using QLSV.DTO;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QLSV
{
    public partial class fDangKy : Form
    {//hello
        public fDangKy()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            LoadDTPK();
            LoadGioiTinh();
            LoadSoKy();
        }

        void LoadDTPK()
        {
            dtpkNgaySinh.Value = new DateTime(2000, 1, 1);
        }
        void LoadGioiTinh()
        {
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedIndex = 0;
        }
        void LoadMaToa()
        {
            string gioitinh = (cbGioiTinh.Text == "Nam") ? "nam":"nu";
            cbMaToa.DataSource = ToaDAO.Instance.layMaToa(gioitinh);
            cbMaToa.DisplayMember = "TenToa";

        }

        void LoadSoKy()
        {
            for (int i = 1; i < 5; i++)
                cbSoKy.Items.Add(i);
            cbSoKy.SelectedIndex = 0;
        }
        void LoadMaPhong()
        {
            string matoa = (cbMaToa.SelectedItem as Toa).MaToa;
            cbMaPhong.DataSource = PhongDAO.Instance.layMaPhong(matoa);
            cbMaPhong.DisplayMember = "MaPhong";
        }
        private void cbMaToa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMaPhong();
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && Convert.ToInt32(e.KeyChar) != 8)
                e.Handled = true;

        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string masv = txtMaSv.Text;
            string hoten = txtHoTen.Text;
            DateTime ngaysinh = dtpkNgaySinh.Value;
            string gioitinh = cbGioiTinh.SelectedItem.ToString();
            string cccd = txtCCCD.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string matoa = (cbMaToa.SelectedItem as Toa).MaToa;
            string maphong = (cbMaPhong.SelectedItem as Phong).MaPhong;
            byte[] anh = ImageToByteArray(txtAnh.Text);
            int soky = Convert.ToInt32(cbSoKy.SelectedItem.ToString());

            try { 
                string sql = string.Format("UTP_ThemSinhVien @masv , @hoten , @ngaysinh , @gioitinh , @cccd , @diachi , @sdt , @matoa , @maphong , @soky , @anh ");
                DBConnection.Instance.Use_PROC(sql, new object[] { masv, hoten,ngaysinh, gioitinh, cccd, diachi, sdt, matoa, maphong, soky, anh });
                MessageBox.Show("Đăng Ký thành công" , "Message");
                this.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message,"Message");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ODL.Title = "Image";
            ODL.Filter = "Image|*.png;*.jpg;*.gif";
            if (ODL.ShowDialog() == DialogResult.OK)
            {
                txtAnh.Text = ODL.FileName;
                ODL.Dispose();//thu hồi bộ nhớ
            }
        }
        byte[] ImageToByteArray(string path)
        {
            byte[] a = null;
            try
            {
                
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    a = new byte[fs.Length];
                    fs.Read(a, 0, (int)fs.Length);
                }
                return a;
            }
            catch { 
            
            }
            return a;
        }

        private void fDangKy_Load(object sender, EventArgs e)
        {

        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMaToa();
        }
    }
}
