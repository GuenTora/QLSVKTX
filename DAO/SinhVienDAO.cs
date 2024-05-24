using QLSV.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.DAO
{
    internal class SinhVienDAO
    {
        private static SinhVienDAO instance;
        public static SinhVienDAO Instance
        {
            get { if (instance == null) instance = new SinhVienDAO(); return SinhVienDAO.instance; }
            private set => SinhVienDAO.instance = value;
        }


        DBConnection dbConnec = new DBConnection();
        public DataTable DanhSach(string Toa)
        {
            string lenh = string.Format("select * from XemBangSinhVien('{0}')", Toa);
            return dbConnec.FormLoad(lenh);
        }
        public DataTable DanhSachDuyet(string Toa)
        {
            string lenh = string.Format("select * from SinhVien where MaToa = '{0}' and duyet = 0", Toa);
            return dbConnec.FormLoad(lenh);
           
        }

        public void Duyet(string ma)
        {
            string lenh = string.Format("update SinhVien set duyet = 1 where MaSV = '{0}'", ma);
            dbConnec.ThucThi(lenh);
        }

        public List<SinhVien> Search(string TK, string value,string toa)
        {
            List<SinhVien> list = new List<SinhVien>();

            string query = "select * from SinhVien where " + TK + " like N'%" + value + "%'" + "and MaToa = '" + toa +"' and where duyet = 1";

            DataTable data = DBConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                SinhVien sv = new SinhVien(row);
                list.Add(sv);
            }

            return list;
        }
        public void Them(SinhVien ns)
        {
            string sqlStr = string.Format("INSERT INTO SinhVien(MaSV, HoTen, NgaySinh,GioiTinh, CCCD,DiaChi, SDT, MaPhong, MaToa) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", ns.Mssv, ns.Ten, ns.ngaySinh, ns.Gioitinh, ns.Cccd, ns.Diachi, ns.Sdt, ns.Maphong, ns.Matoa);
            dbConnec.ThucThi(sqlStr);

        }

        public void Xoa(SinhVien ns)
        {
            string sqlStr = string.Format("DELETE FROM SinhVien WHERE MaSV = '{0}';", ns.Mssv);
            dbConnec.ThucThi(sqlStr);

        }



        public SinhVien Loc(string masv)
        {

            string sql = string.Format("SELECT * FROM SinhVien WHERE masv = N'{0}'", masv);
            DataTable data = DBConnection.Instance.ExecuteQuery(sql);
            SinhVien sv = new SinhVien(data.Rows[0]);
            return sv;
        }
        public int Sua(string ten, DateTime ngaysinh, string gioitinh, string cccd, string diachi, string sdt, byte[] anh, string mssv)
        {
            try
            {
                string sqlStr = string.Format("UTP_SuaSVDoSvThucHien @Hoten , @Ngaysinh , @gioitinh , @cccd , @diachi , @sdt , @anh , @MaSV");
                int count = DBConnection.Instance.ExecuteNonQuery(sqlStr, new object[] { ten, ngaysinh, gioitinh, cccd, diachi, sdt, anh, mssv });
                return count;
            }
            catch (SqlException ex){
                MessageBox.Show("Error" + ex);
                return 0; 
            }
        }

        public void CapNhat(SinhVien ns)
        {
            string sqlStr = string.Format("UTP_CapNhatSinhVien @MaSV , @HoTen , @NgaySinh , @GioiTinh , @CCCD , @DiaChi , @SDT , @MaPhong , @MaToa");
            dbConnec.Use_PROC(sqlStr, new object[] { ns.Mssv, ns.Ten, ns.ngaySinh, ns.Gioitinh, ns.Cccd, ns.Diachi, ns.Sdt, ns.Maphong, ns.Matoa });

        }
        public DataTable DanhSach()
        {
            string lenh = string.Format("select * from SinhVien where duyet = 1");
            return dbConnec.FormLoad(lenh);
        }
        public DataTable DanhSachDuyet()
        {
            string lenh = string.Format("select * from SinhVien where duyet = 0");
            return dbConnec.FormLoad(lenh);

        }
    }
}
