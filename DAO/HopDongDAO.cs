using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.DAO
{
    internal class HopDongDAO
    {

        DBConnection dbConnec = new DBConnection();


        private static HopDongDAO instance;
        public static HopDongDAO Instance
        {
            get { if (instance == null) instance = new HopDongDAO(); return HopDongDAO.instance; }
            private set => HopDongDAO.instance = value;
        }
        public DataTable DanhSach(string toa)
        {
            return dbConnec.FormLoad("SELECT * FROM SuKienDatPhong where MaPhong like N'%" + toa + "%'");
        }

        public DataTable TimKiem(string tk, string value, string ql)
        {

            string lenh = string.Format("SELECT * FROM SuKienDatPhong WHERE " + tk + " like N'%" + value + "%' and MaQL = '" + ql + "'");

            return dbConnec.FormLoad(lenh);
        }

        internal HopDong TimKiemHopDongTheoSV(string mssv)
        {
            DataTable data = DBConnection.Instance.ExecuteQuery("USP_TimKiemHopDongTheoSV @mssv ", new object[] { mssv });
            if (data != null)
            {
                HopDong hopDong = new HopDong(data.Rows[0]);
                return hopDong;
            }
            return null;
        }

        internal int GiaHanHopDongSV(string mssv,int soky)
        {
            try
            {
                
                int data = DBConnection.Instance.ExecuteNonQuery("USP_GiaHanHopDongSV @mssv , @soky ", new object[] { mssv,soky });
                if (data != 0)
                {
                    MessageBox.Show("Đăng ký gia hạn thành công" , "Message");
                }
                return data;
            }

            
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Message");
                return -1;
            }
        }
        public DataTable DanhSach()
        {
            return dbConnec.FormLoad("SELECT * FROM SuKienDatPhong ");
        }
    }
}
