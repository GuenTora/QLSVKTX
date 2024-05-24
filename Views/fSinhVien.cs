using QLSV.DAO;
using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.Views
{


    internal partial class fSinhVien : Form
    {
        SinhVien sv;

        private TaiKhoan tk;

        internal TaiKhoan Tk { get => tk; set => tk = value; }

        private byte[] anh;
        public fSinhVien()
        {
            InitializeComponent();
            sv = UserSession.LoggedInUser;
            Load();

        }

        void Load()
        {
            DateTime today = DateTime.Now;
            for (int i = 1; i <= 12; i++)
            {
                cbThang.Items.Add(i);
                cbThang2.Items.Add(i);
                cbThang3.Items.Add(i);
            }
            sv = SinhVienDAO.Instance.Loc(sv.Mssv);
            txtTen.Text = sv.Ten;
            txtMaPhong.Text = sv.Maphong;
            cbThang.Text = today.Month.ToString();
            txtTen2.Text = sv.Ten;
            txtMaPhong2.Text = sv.Maphong;
            cbThang2.Text = today.Month.ToString();
            LoadSV();



        }
        void LoadSVTheoPhong()
        {
            dtgvXemThanhVien.DataSource = DBConnection.Instance.ExecuteQuery("UTP_XemThanhVien @maphong",new object[] {sv.Maphong});
        }
        void LoadSV()
        {
            sv = SinhVienDAO.Instance.Loc(sv.Mssv);
            txtMaSv.Text = sv.Mssv;
            txtHoTen.Text = sv.Ten;
            dtpkNgaySinh.Value = sv.ngaySinh;
            txtCCCD.Text = sv.Cccd;
            txtDiaChi.Text = sv.Diachi;
            txtGioiTinh.Text = sv.Gioitinh;
            txtSDT.Text = sv.Sdt;
            txtMaToa.Text = sv.Matoa;
            txtPhong.Text = sv.Maphong;
            anh = sv.Anh;
            try
            {
                PB.Image = ByteArrayToImage(sv.Anh);
            }
            catch (Exception e) { }
            lbxemthanhvien.Text = lbxemthanhvien.Text + sv.Maphong;
            LoadHopDong();
            LoadSVTheoPhong();
        }
        
        void LoadHopDong()
        {
            HopDong hopDong = HopDongDAO.Instance.TimKiemHopDongTheoSV(sv.Mssv);
            if (hopDong != null)
            {
                tbMaPhong.Text = hopDong.MaPhong;
                tbMssv.Text = hopDong.MaSV;
                dtpkNhanPhong.Value = hopDong.NgayNhanPhong;
                dtpkTraPhong.Value = hopDong.NgayTraPhong;
                tbSoTien.Text = hopDong.Tien.ToString();
                tbSoKy.Text = hopDong.SoKy.ToString();
            }
        }

        private void btnXemDien_Click(object sender, EventArgs e)
        {
            string MaPhong = txtMaPhong.Text;
            string thang = cbThang.Text;
            dtgvDien.DataSource = TienDienDAO.Instance.timTienDien(MaPhong, thang);
        }

        private void btnXem2_Click(object sender, EventArgs e)
        {
            string MaPhong = txtMaPhong2.Text;
            string thang = cbThang2.Text;
            dtgvNuoc.DataSource = TienNuocDAO.Instance.timTienNuoc(MaPhong, thang);
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            string masv = txtMaSv.Text;
            string hoten = txtHoTen.Text;
            string gioitinh = txtGioiTinh.Text;
            string cccd = txtCCCD.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;

            DateTime ngaysinh = dtpkNgaySinh.Value;
            int count = SinhVienDAO.Instance.Sua(hoten, ngaysinh, gioitinh, cccd, diachi, sdt, anh, masv);
            if (count > 0)
            {
                MessageBox.Show("Sửa thành công");
                LoadSV();
            }
            else
                MessageBox.Show("Sửa thất bại");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            sv = SinhVienDAO.Instance.Loc(sv.Mssv);
            this.Tk = TaiKhoanDAO.Instance.layTK(sv.Mssv);
            fDoiMatKhau f = new fDoiMatKhau(sv);
            f.UpdateTK += F_UpdateTK;
            f.ShowDialog();
        }

        private void F_UpdateTK(object sender, SVEvent e)
        {

            if (tk.MatKhau != e.Sv.MatKhau)
            {
                MessageBox.Show("Vui lòng đăng nhập lại", "Thông Báo");
                this.Close();
                btnDangXuat.Click += btnDangXuat_Click;
            }
        }
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            ODL.Title = "Image";
            ODL.Filter = "Image|*.png;*.jpg;*.gif";
            if (ODL.ShowDialog() == DialogResult.OK)
            {
                anh = ImageToByteArray(Image.FromFile(ODL.FileName));
                txtAnh.Text = ODL.FileName;
                ODL.Dispose();//thu hồi bộ nhớ
            }
        }

        private void fXemPhong_Load(object sender, EventArgs e)
        {

        }


        private void fXemPhong_Load_1(object sender, EventArgs e)
        {
            
        }

        private void cbthang3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<HoaDonDN> list = HoaDonDAO.Instance.XemHoaDonSV(sv.Maphong, Convert.ToInt32(cbThang3.Text));
            if (list != null)
            {
                dtgvHoaDon.DataSource = list;
                dtgvHoaDon.Columns[0].Visible = false;
            }

        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            fGiaHan f = new fGiaHan();
            f.ShowDialog();
            Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fXemKyLuat f = new fXemKyLuat();
            f.ShowDialog();
        }
    }
}
