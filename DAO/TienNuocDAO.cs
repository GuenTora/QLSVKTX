using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DAO
{
    internal class TienNuocDAO
    {

        private static TienNuocDAO instance;
        public static TienNuocDAO Instance
        {
            get { if (instance == null) instance = new TienNuocDAO(); return TienNuocDAO.instance; }
            private set => TienNuocDAO.instance = value;
        }



        public DataTable timTienNuoc(string Maphong, string thang)
        {
            string sql = string.Format("SELECT * FROM tiennuoc WHERE Maphong = N'{0}' and thang = {1}", Maphong, thang);
            DataTable data = DBConnection.Instance.ExecuteQuery(sql);
            return data;
        }
        DBConnection dbConnec = new DBConnection();
        public DataTable DanhSach(string toa)
        {
            string sql = string.Format("SELECT * FROM TienNuoc where MaPhong like N'%" + toa + "%'");

            return dbConnec.FormLoad(sql);
        }
        public void Them(TienNuoc ns)
        {
            string sql = string.Format("USP_ThemHoaDonNuoc @MaPhong , @Thang , @SoNuocDauThang , @SoNuocCuoiThang ");
            dbConnec.Use_PROC(sql, new object[] { ns.MaPhong, ns.Thang, ns.SoNuocDauThang, ns.SoNuocCuoiThang });

        }
        public void Xoa(TienNuoc ns)
        {
            string sqlStr = string.Format("DELETE FROM TienNuoc WHERE MaPhong = '{0}' and Thang = '{1}';", ns.MaPhong, ns.Thang);
            dbConnec.ThucThi(sqlStr);

        }
        public DataTable DanhSach()
        {
            string sql = string.Format("SELECT * FROM TienNuoc ");

            return dbConnec.FormLoad(sql);
        }
    }
}
