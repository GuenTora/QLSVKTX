using QLSV.DAO;
using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSV.Views
{
    public partial class fQuanLy : Form
    {
        SinhVienDAO svDao = new SinhVienDAO();
        SinhVien ns = new SinhVien();

        TienDienDAO tdDao = new TienDienDAO();
        TienDien TienDien = new TienDien();

        TienNuocDAO tnDao = new TienNuocDAO();
        TienNuoc TienNuoc = new TienNuoc();

        HoaDonDAO hdDAO = new HoaDonDAO();
        HoaDonDN hd = new HoaDonDN();

        HopDongDAO HopDongDAO = new HopDongDAO();

        QuanLyDAO qlDao = new QuanLyDAO();

        KyLuatDAO klDao = new KyLuatDAO();
        KyLuat kl = new KyLuat();

        giahanDAO gdDao = new giahanDAO();

        PhongDAO pDao = new PhongDAO();
        Phong p;

        string currAcc = null;
        QuanLy ql ;
        static int dem = 0;
        public static string masv = null ;
        public fQuanLy()
        {
            InitializeComponent();
        }

        private void tbQLSV_Click(object sender, EventArgs e)
        {

        }

        private void fQuanLy_Load(object sender, EventArgs e)
        {
            try
            {
                currAcc = fDangNhap.currAcc;
    
               
                    Console.WriteLine(currAcc);

                    ql = TaiKhoanDAO.Instance.layTT(currAcc);

                    TaiKhoan();
                    dgvSinhVien.DataSource = svDao.DanhSach(ql.MaToa);                  
                    dgvTienDien.DataSource = tdDao.DanhSach(ql.MaToa);
                    dgvTienNuoc.DataSource = tnDao.DanhSach(ql.MaToa);
                    dgvHoaDon.DataSource = hdDAO.DanhSach(ql.MaToa);
                    dgvHopDong.DataSource = HopDongDAO.DanhSach(ql.MaToa);
                    dgvKyLuat.DataSource = klDao.DanhSach(ql.MaToa);
                    txtMaToaKL.Text = ql.MaToa;
                    dgvPhong.DataSource =PhongDAO.Instance.layMaPhong(ql.MaToa);

                    DoiTenGV();
                    DoiTenDN();
                
         
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            try
            {
                DBConnection.Instance.DangNhap("sa", "haiduong");
                ns = new SinhVien(txtMSV.Text, txtTen.Text, dtpNgaySinh.Value.Date, txtGT.Text, txtCCCD.Text, txtDiaChi.Text, txtSdt.Text, txtMaPhong.Text, txtMaToa.Text);
                svDao.Xoa(ns);

                   dgvSinhVien.DataSource = svDao.DanhSach(ql.MaToa);
                    DBConnection.Instance.DangNhap(ql.Maql, ql.Maql);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if(txtMaToa.Text != ql.MaToa )
            {
                MessageBox.Show("Sinh viên phải thuộc tòa " + ql.MaToa);
                return;
            }

            try
            {
                ns = new SinhVien(txtMSV.Text, txtTen.Text, dtpNgaySinh.Value.Date, txtGT.Text, txtCCCD.Text, txtDiaChi.Text, txtSdt.Text, txtMaPhong.Text, txtMaToa.Text);

                SinhVienDAO.Instance.CapNhat(ns);

                dgvSinhVien.DataSource = svDao.DanhSach(ql.MaToa);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DoiTenGV()
        {
            string[] thuoctinh = { "Mã Sinh Viên", "Họ Tên", "Ngày Sinh", "Giới tính", "CCCD", "Địa Chỉ", "Số điện thoại", "Mã Phòng", "Mã Tòa" };
            for (int i = 0; i < thuoctinh.Length; i++)
            {
                dgvSinhVien.Columns[i].HeaderText = thuoctinh[i];
            }

        }
        private void DoiTenDN()
        {
            string[] thuoctinh = { "Mã Phòng", "Tháng", "Số Điện đàu tháng", "Số điện cuối tháng", "Tiền Điện" };
            for (int i = 0; i < thuoctinh.Length; i++)
            {
                dgvTienDien.Columns[i].HeaderText = thuoctinh[i];
            }
            string[] thuoctinh1 = { "Mã Phòng", "Tháng", "Số Nước đàu tháng", "Số Nước cuối tháng", "Tiền Nước" };
            for (int i = 0; i < thuoctinh1.Length; i++)
            {
                dgvTienNuoc.Columns[i].HeaderText = thuoctinh1[i];
            }

            string[] thuoctinh2 = { "Mã Hóa Đơn", "Mã Phòng", "Tháng", "Tổng Tiền", "Trạng Thái" };
            for (int i = 0; i < thuoctinh2.Length; i++)
            {
                dgvHoaDon.Columns[i].HeaderText = thuoctinh2[i];
            }

            string[] thuoctinh3 = { "Mã Kỷ Luật", "Mã Sinh Viên", "Mã Tòa", "Lỗi Vi Phạm", "Ngày Kỷ Luật" };
            for (int i = 0; i < thuoctinh3.Length; i++)
            {
                dgvKyLuat.Columns[i].HeaderText = thuoctinh3[i];
            }

            string[] thuoctinh4 = { "Mã Phòng", "Loại Phòng", "Mã Tòa", "Số Người Đang Ở"};
            for (int i = 0; i < thuoctinh4.Length; i++)
            {
                dgvKyLuat.Columns[i].HeaderText = thuoctinh4[i];
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dgvSinhVien.SelectedRows[0];

                txtMSV.Text = r.Cells[0].Value.ToString();
                txtTen.Text = r.Cells[1].Value.ToString();
                dtpNgaySinh.Text = r.Cells[2].Value.ToString();
                txtGT.Text = r.Cells[3].Value.ToString();
                txtCCCD.Text = r.Cells[4].Value.ToString();
                txtDiaChi.Text = r.Cells[5].Value.ToString();
                txtSdt.Text = r.Cells[6].Value.ToString();
                txtMaPhong.Text = r.Cells[7].Value.ToString();
                txtMaToa.Text = r.Cells[8].Value.ToString();
            }
            catch(Exception ex) { }
        }

        private void cboLoaiTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                dgvSinhVien.DataSource = svDao.DanhSach(ql.MaToa);
                return;
            }
            string timkiem = "";
            if (cboLoaiTimKiem.Text == "Tên") timkiem = "HoTen";
            if (cboLoaiTimKiem.Text == "Mã SV") timkiem = "MaSV";
            if (cboLoaiTimKiem.Text == "Phòng") timkiem = "MaPhong";


            dgvSinhVien.DataSource = svDao.Search(timkiem, txtTimKiem.Text,ql.MaToa);
        }



        private void dgvTienDien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow a = dgvTienDien.SelectedRows[0];

                txtMaPhongTD.Text = a.Cells[0].Value.ToString();
                cboThangTD.Text = a.Cells[1].Value.ToString();
                txtDienDauThang.Text = a.Cells[2].Value.ToString();
                txtDienCuoiThang.Text = a.Cells[3].Value.ToString();
                txtTienDien.Text = a.Cells[4].Value.ToString();
            }
            catch { }
        }

        private void btnThemTD_Click(object sender, EventArgs e)
        {
            string content = txtMaPhongTD.Text;

                 if (!content.Contains(ql.MaToa))
                 {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
                 }
            try
            {
                TienDien = new TienDien(txtMaPhongTD.Text, int.Parse(cboThangTD.Text), int.Parse(txtDienDauThang.Text), int.Parse(txtDienCuoiThang.Text));
                tdDao.Them(TienDien);

                dgvTienDien.DataSource = tdDao.DanhSach(ql.MaToa);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaTD_Click(object sender, EventArgs e)
        {
            string content = txtMaPhongTD.Text;

            if (!content.Contains(ql.MaToa))
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
            }
            try
            {
                TienDien = new TienDien(txtMaPhongTD.Text, int.Parse(cboThangTD.Text), int.Parse(txtDienDauThang.Text), int.Parse(txtDienCuoiThang.Text));

                dgvTienDien.DataSource = tdDao.DanhSach(ql.MaToa);

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (cboLoaiTimKiem.Text == "") return;
            if (txtTimKiem.Text == "")
            {
                dgvSinhVien.DataSource = svDao.DanhSach(ql.MaToa);
                return;
            }
            string timkiem = "";
            if (cboLoaiTimKiem.Text == "Tên") timkiem = "HoTen";
            if (cboLoaiTimKiem.Text == "Mã SV") timkiem = "MaSV";
            if (cboLoaiTimKiem.Text == "Phòng") timkiem = "MaPhong";


            dgvSinhVien.DataSource = svDao.Search(timkiem, txtTimKiem.Text,ql.MaToa);
        }

        private void btnTimKiemTD_Click(object sender, EventArgs e)
        {
            string content = txtMaPhongTD.Text;

            if(!content.Contains(ql.MaToa))
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
            }

            try
            {
                dgvTienDien.DataSource = tdDao.timTienDien(txtMaPhongTD.Text, cboThangTD.Text);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        } 

        private void dgvTienNuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow a = dgvTienNuoc.SelectedRows[0];

                txtMaPhongTN.Text = a.Cells[0].Value.ToString();
                cboThangTN.Text = a.Cells[1].Value.ToString();
                txtNuocDauThang.Text = a.Cells[2].Value.ToString();
                txtNuocCuoiThang.Text = a.Cells[3].Value.ToString();
                txtTienNuoc.Text = a.Cells[4].Value.ToString();
            }
            catch { }
        }

        private void btnThemTN_Click(object sender, EventArgs e)
        {
            string content = txtMaPhongTN.Text;

                if (!content.Contains(ql.MaToa))
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
            }
            try
            {
                TienNuoc = new TienNuoc(txtMaPhongTN.Text, int.Parse(cboThangTN.Text), int.Parse(txtNuocDauThang.Text), int.Parse(txtNuocCuoiThang.Text));
                tnDao.Them(TienNuoc);

                    dgvTienNuoc.DataSource = tnDao.DanhSach(ql.MaToa);

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnXoaTN_Click(object sender, EventArgs e)
        {
            string content = txtMaPhongTN.Text;

                if (!content.Contains(ql.MaToa))
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
            }
            try
            {
                TienNuoc = new TienNuoc(txtMaPhongTN.Text, int.Parse(cboThangTN.Text), int.Parse(txtNuocDauThang.Text), int.Parse(txtNuocCuoiThang.Text));
                tnDao.Xoa(TienNuoc);

                    dgvTienNuoc.DataSource = tnDao.DanhSach(ql.MaToa);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message) ;
            }

        }

        private void btnTimKiemTN_Click(object sender, EventArgs e)
        {
            string content = txtMaPhongTN.Text;

                if (!content.Contains(ql.MaToa))
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
            }
            try
            {
                dgvTienNuoc.DataSource = tnDao.timTienNuoc(txtMaPhongTN.Text, cboThangTN.Text);
            }
            catch
            { }
         }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow a = dgvHoaDon.SelectedRows[0];

                txtMaHD.Text = a.Cells[0].Value.ToString();
                txtMaPhongHD.Text= a.Cells[1].Value.ToString();
                cboThangHD.Text = a.Cells[2].Value.ToString();
                txtTongTien.Text = a.Cells[3].Value.ToString();
                txtTrangThai.Text = a.Cells[4].Value.ToString();
            }
            catch { }
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            string content = txtMaPhongHD.Text;

                if (!content.Contains(ql.MaToa))
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
            }
            try
            {
                hdDAO.Them(Convert.ToInt32(txtMaHD.Text), txtMaPhongHD.Text, Convert.ToInt32(cboThangHD.Text));

                dgvHoaDon.DataSource = hdDAO.DanhSach(ql.MaToa);

            }
            catch(Exception ex) {MessageBox.Show(ex.Message); }
        }

        private void btnXacNhanDT_Click(object sender, EventArgs e)
        {
            string content = txtMaPhongHD.Text;

                if (!content.Contains(ql.MaToa))
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
            }
            try
            {
                hdDAO.XacNhan(Convert.ToInt32(txtMaHD.Text), txtMaPhongHD.Text, Convert.ToInt32(cboThangHD.Text));

                    dgvHoaDon.DataSource = hdDAO.DanhSach(ql.MaToa);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCD_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            int second = currentTime.Second;
            int minute = currentTime.Minute;
            int hour = currentTime.Hour;
            int day = currentTime.Day;
            int month = currentTime.Month;

            int ramdomNumber = second + minute * 60 + hour * 60 * 60 + day * 24 * 60 * 60 + month * 30 * 24 * 60 * 60;
            
            txtMaHD.Text = ramdomNumber.ToString();
            txtMaPhongHD.Text = txtMaPhongTN.Text;
            cboThangHD.Text = cboThangTN.Text;

        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            string content = txtMaPhongHD.Text;

                if (!content.Contains(ql.MaToa))
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
            }
            try
            {
                hdDAO.Xoa(Convert.ToInt32(txtMaHD.Text));

                dgvHoaDon.DataSource = hdDAO.DanhSach(ql.MaToa);

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            string content = txtMaPhongHD.Text;

                if (!content.Contains(ql.MaToa))
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
            }
            try
            {
                int ktr = 0;
                int thang;

                if (cboLoai.Text == "Đã Đóng Tiền") ktr = 1;
                if (cboLoai.Text == "Chưa Đóng Tiền") ktr = 2;
                if (cboThangHD.Text == "") thang = -1;
                else thang = Convert.ToInt32(cboThangHD.Text);

                dgvHoaDon.DataSource = hdDAO.TimKiem(ktr, txtMaPhongHD.Text, thang,ql.MaToa);

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void grpHopDong_Enter(object sender, EventArgs e)
        {

        }

        private void txtTimKiemHD_TextChanged(object sender, EventArgs e)
        {
            string content = txtTimKiemHD.Text;
            if (txtTimKiemHD.Text == "")
            {
                dgvHopDong.DataSource = HopDongDAO.DanhSach(ql.MaToa);
                return;
            }
            if (cboLoaiTKHD.Text == "") return;
            if (!content.Contains(ql.MaToa) && cboLoaiTKHD.Text == "Mã Phòng")
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
                return;
            }

            
        
            string timkiem = "";
            if (cboLoaiTKHD.Text == "Mã Phòng") timkiem = "MaPhong";
            if (cboLoaiTKHD.Text == "Mã Sinh Viên") timkiem = "MaSV";


            dgvHopDong.DataSource = HopDongDAO.TimKiem(timkiem, txtTimKiemHD.Text, ql.Maql) ;
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoaHopDong_Click(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_Click(object sender, EventArgs e)
        {
                if(txtMSV.Text == "")
            {
                MessageBox.Show("Nhập mã số sinh viên");
                return;
            }            
                masv = txtMSV.Text;
                fTaiKhoan tk = new fTaiKhoan();
                tk.ShowDialog();
            
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void grpTienDien_Enter(object sender, EventArgs e)
        {

        }

        private void TaiKhoan()
        {
            txtMaQL.Text = ql.Maql;
            txtTenQL.Text =ql.Ten;
            txtToaQL.Text = ql.MaToa;
            txtChucVu.Text = ql.ChucVu;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
           
            fDoiMatKhau f = new fDoiMatKhau(ql);

            f.ShowDialog();
        }

        private void btnSuaTTQL_Click(object sender, EventArgs e)
        {
            try
            {
                qlDao.Sua(txtTenQL.Text, txtMaQL.Text);

                ql = TaiKhoanDAO.Instance.layTT(currAcc);
                TaiKhoan();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemKL_Click(object sender, EventArgs e)
        {
            kl = new KyLuat(txtMaKyLuat.Text, txtMaSVKL.Text, txtMaToaKL.Text,txtLoiViPham.Text ,dtpNgayViPham.Value.Date);
            klDao.Them(kl);
            dgvKyLuat.DataSource = klDao.DanhSach(ql.MaToa);

        }

        private void dgvKyLuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dgvKyLuat.SelectedRows[0];

                txtMaKyLuat.Text = r.Cells[0].Value.ToString();
                txtMaSVKL.Text = r.Cells[1].Value.ToString();
                txtMaToaKL.Text = r.Cells[2].Value.ToString();
                txtLoiViPham.Text = r.Cells[3].Value.ToString();
                dtpNgayViPham.Text = r.Cells[4].Value.ToString();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnXoaKL_Click(object sender, EventArgs e)
        {
            kl = new KyLuat(txtMaKyLuat.Text, txtMaSVKL.Text, txtMaToaKL.Text, txtLoiViPham.Text, dtpNgayViPham.Value.Date);
            klDao.Xoa(kl);
            dgvKyLuat.DataSource = klDao.DanhSach(ql.MaToa);
        }

        private void txtmaKL_TextChanged(object sender, EventArgs e)
        {
            dgvKyLuat.DataSource = klDao.Loc(txtmaKL.Text,txtMaToaKL.Text);
        }

        private void cboLoaiTKHD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDSduyet_Click(object sender, EventArgs e)
        {
            if (dem == 0)
            {

                dgvSinhVien.DataSource = svDao.DanhSachDuyet(ql.MaToa);

                dem = 1;
                grpDanhSach.Text = "Danh Sách Duyệt";
            }
            else
            {

                dgvSinhVien.DataSource = svDao.DanhSach(ql.MaToa);

                grpDanhSach.Text = "Danh Sách";
                dem = 0;
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dem == 1)
                {
                    svDao.Duyet(txtMSV.Text);
                    dgvSinhVien.DataSource = svDao.DanhSachDuyet(ql.MaToa);
                }
                if (dem1 == 1)
                {
                    gdDao.duyet(txtMSV.Text);
                    dgvSinhVien.DataSource = gdDao.DanhSach();
                }

                

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        static int dem1 = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (dem1 == 0)
            {

                dgvSinhVien.DataSource = gdDao.DanhSach();
                dem1 = 1;
                grpDanhSach.Text = "Danh Sách Gia Hạn";
            }
            else
            {

                dgvSinhVien.DataSource = svDao.DanhSach(ql.MaToa);

                grpDanhSach.Text = "Danh Sách";
                dem1 = 0;
            }
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dgvPhong.SelectedRows[0];

                txtMaPhongp.Text = r.Cells[0].Value.ToString();
                txtLoaiPhong.Text = r.Cells[1].Value.ToString();
                txtMaToap.Text = r.Cells[2].Value.ToString();
                txtSoNguoiO.Text = r.Cells[3].Value.ToString();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnXoaP_Click(object sender, EventArgs e)
        {
            pDao.Xoa(txtMaToap.Text,txtSoNguoiO.Text);
            dgvPhong.DataSource = PhongDAO.Instance.layMaPhong(ql.MaToa);
        }

        private void btnThemP_Click(object sender, EventArgs e)
        {
            if(txtMaToap.Text != ql.MaToa)
            {
                MessageBox.Show("Phòng không thuộc tòa quản lý");
            }
            pDao.them(txtMaPhongp.Text, txtLoaiPhong.Text, txtMaToap.Text);
            dgvPhong.DataSource = PhongDAO.Instance.layMaPhong(ql.MaToa);

        }

        private void txtTKPhong_TextChanged(object sender, EventArgs e)
        {
            if (txtTKPhong.Text == "") 
            {
                dgvPhong.DataSource = PhongDAO.Instance.layMaPhong(ql.MaToa);
                return;
            }
            dgvPhong.DataSource = pDao.tim(txtTKPhong.Text);

        }

        private void cboThangTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboThangTT.Text == "" )
            {
                txtTongTDN.Text = "";
                txtTienDaThu.Text = "";
                txtTienConLai.Text = "";

                return;
            }
            txtTongTDN.Text = hdDAO.TongTien(int.Parse(cboThangTT.Text),ql.MaToa).ToString();
            txtTienDaThu.Text = hdDAO.TienDaDong(int.Parse(cboThangTT.Text), ql.MaToa).ToString();
            txtTienConLai.Text = (int.Parse(txtTongTDN.Text) - int.Parse(txtTienDaThu.Text)).ToString();        }
    }   
}
