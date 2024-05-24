using QLSV.DTO;
using QLSV.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.DAO
{
    internal class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;
        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return TaiKhoanDAO.instance; }
            private set => TaiKhoanDAO.instance = value;
        }

        private TaiKhoanDAO() { }

        public bool sua(string taikhoan,string matkhau)
        {
            string sqlStr = string.Format("UPDATE taikhoan SET MatKhau = N'{0}' where TaiKhoan = N'{1}'",matkhau,taikhoan);
            int count = DBConnection.Instance.ExecuteNonQuery(sqlStr);
            return count > 0;
        }

        public TaiKhoan layTK(string taikhoan)
        {
            string sqlStr = string.Format("select * from taikhoan where TaiKhoan = N'{0}'", taikhoan);
            DataTable dt = DBConnection.Instance.ExecuteQuery(sqlStr);
            try
            {
                TaiKhoan tk = new TaiKhoan(dt.Rows[0]);
                return tk;
            }
            catch (Exception ex) { 
                return null;
            }
            
        }
        public QuanLy layTT(string taikhoan)
        {
            string sqlStr = string.Format("select * from QuanLy where MaQL = N'{0}'", taikhoan);
            DataTable dt = DBConnection.Instance.ExecuteQuery(sqlStr);
            try
            {
                QuanLy tk = new QuanLy(dt.Rows[0]);
                return tk;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
