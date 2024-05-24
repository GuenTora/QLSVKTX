using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.DAO
{
    internal class HoaDonDAO
    {

        DBConnection dbConnec = new DBConnection();




        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            private set => HoaDonDAO.instance = value;
        }

        public DataTable DanhSach(string toa)
        {
            return dbConnec.FormLoad("SELECT * FROM HoaDonDN where MaPhong like N'%" + toa + "%'");
        }
        public void Them(int MaHD, string MaPhong, int Thang)
        {
            //insert into HoaDonDN values(1,'A-01',1,0,0)
            string sqlStr = string.Format("insert into HoaDonDN values (" + MaHD + ",'" + MaPhong + "'," + Thang + ",0,0)");
            dbConnec.ThucThi(sqlStr);

        }
        public void Xoa(int MaHD)
        {
            string sqlStr = string.Format("DELETE FROM HoaDonDN WHERE MaHD = " + MaHD);
            dbConnec.ThucThi(sqlStr);

        }
        public void XacNhan(int MaHD, string MaPhong, int Thang)
        {
            string sqlStr = string.Format("UPDATE HoaDonDN SET TrangThai = " + 1 + " Where MaHD =" + MaHD);
            dbConnec.ThucThi(sqlStr);
        }
        public DataTable TimKiem(int ktr, string MaPhong, int Thang, string toa)
        {
            
            string sqlStr = null;
            if (MaPhong != "" && Thang == -1 && ktr == 0) sqlStr = string.Format("SELECT * FROM HoaDonDN Where MaPhong = '" + MaPhong + "'");
            if (MaPhong != "" && Thang == -1 && ktr == 1) sqlStr = string.Format("SELECT * FROM HoaDonDN Where MaPhong = '" + MaPhong + "' and TrangThai =1");
            if (MaPhong != "" && Thang == -1 && ktr == 2) sqlStr = string.Format("SELECT * FROM HoaDonDN Where MaPhong = '" + MaPhong + "' and TrangThai =0");

            if (MaPhong == "" && Thang != -1 && ktr == 0) sqlStr = string.Format("SELECT * FROM HoaDonDN Where Thang = " + Thang);
            if (MaPhong == "" && Thang != -1 && ktr == 1) sqlStr = string.Format("SELECT * FROM HoaDonDN Where Thang = " + Thang + " and TrangThai =1");
            if (MaPhong == "" && Thang != -1 && ktr == 2) sqlStr = string.Format("SELECT * FROM HoaDonDN Where Thang = " + Thang + " and TrangThai =0");

            if (MaPhong == "" && Thang == -1 && ktr == 0) return DanhSach(toa);


            if (MaPhong == "" && Thang == -1 && ktr == 1) sqlStr = string.Format("SELECT * FROM HoaDonDN Where TrangThai= 1");
            if (MaPhong == "" && Thang == -1 && ktr == 2) sqlStr = string.Format("SELECT * FROM HoaDonDN Where TrangThai= 0");

            if (MaPhong != "" && Thang != -1 && ktr == 0) sqlStr = string.Format("SELECT * FROM HoaDonDN Where MaPhong = '" + MaPhong + "' and Thang =" + Thang);
            if (MaPhong != "" && Thang != -1 && ktr == 1) sqlStr = string.Format("SELECT * FROM HoaDonDN Where MaPhong = '" + MaPhong + "' and Thang =" + Thang + "and TrangThai =1");
            if (MaPhong != "" && Thang != -1 && ktr == 2) sqlStr = string.Format("SELECT * FROM HoaDonDN Where MaPhong = '" + MaPhong + "' and Thang =" + Thang + "and TrangThai =0");



            return dbConnec.FormLoad(sqlStr);
        }

        internal List<HoaDonDN> XemHoaDonSV(string maphong, int thang)
        {
            try
            {
                List<HoaDonDN> list = new List<HoaDonDN>();
                string sql = string.Format("UTP_XemHoaDonSV @maphong , @thang ");
                DataTable data = DBConnection.Instance.ExecuteQuery(sql, new object[] { maphong, thang });
                foreach (DataRow dr in data.Rows)
                {
                    HoaDonDN hoaDon = new HoaDonDN(dr);

                    list.Add(hoaDon);
                }
                return list;


            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Message");
                return null;
            }
        }
        public DataTable DanhSach()
        {
            return dbConnec.FormLoad("SELECT * FROM HoaDonDN");
        }

        public Decimal TongTien(int thang,string MaPhong)
        {
            string sqlStr = string.Format("SELECT * FROM HoaDonDN Where MaPhong like N'%" + MaPhong + "%'");
            DataTable a = dbConnec.FormLoad(sqlStr);
            Decimal sum = 0;
            foreach (DataRow row in a.Rows)
            {
                sum += Convert.ToDecimal(row["TongTien"]);
            }

            return sum;
        }

        public Decimal TienDaDong(int thang, string MaPhong)
        {
            string sqlStr = string.Format("SELECT * FROM HoaDonDN Where MaPhong like N'%" + MaPhong + "%' and TrangThai = 1" );
            DataTable a = dbConnec.FormLoad(sqlStr);
            Decimal sum = 0;
            foreach (DataRow row in a.Rows)
            {
                sum += Convert.ToDecimal(row["TongTien"]);
            }

            return sum;
        }
    }
}
