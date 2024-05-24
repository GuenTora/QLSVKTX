using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.DAO
{
    internal class TienDienDAO
    {

        private static TienDienDAO instance;
        public static TienDienDAO Instance
        {
            get { if (instance == null) instance = new TienDienDAO(); return TienDienDAO.instance; }
            private set => TienDienDAO.instance = value;
        }

   

        public DataTable timTienDien(string Maphong, string thang)
        {
            string sql = string.Format("SELECT * FROM tiendien WHERE Maphong = N'{0}' and thang = {1}", Maphong, thang);
            DataTable data = DBConnection.Instance.ExecuteQuery(sql);
            TienDien td = new TienDien();
            foreach (DataRow row in data.Rows)
                td = new TienDien(row);
            return data;
        }
        DBConnection dbConnec = new DBConnection();
        public DataTable DanhSach(string toa)
        {
            return dbConnec.FormLoad("SELECT * FROM TienDien  where MaPhong like N'%" + toa + "%'");
        }
        public void Them(TienDien ns)
        {
            string sql = string.Format("USP_ThemHoaDonDien @MaPhong , @Thang , @SoDienDauThang , @SoDienCuoiThang ");
            dbConnec.Use_PROC(sql, new object[] { ns.MaPhong, ns.Thang , ns.SoDienDauThang, ns.SoDienCuoiThang });
           
        }
        public void Xoa(TienDien ns)
        {
            string sqlStr = string.Format("DELETE FROM TienDien WHERE MaPhong = '{0}' and Thang = '{1}';", ns.MaPhong,ns.Thang);
            dbConnec.ThucThi(sqlStr);

        }
        public DataTable DanhSach()
        {
            return dbConnec.FormLoad("SELECT * FROM TienDien  ");
        }
    }
}
