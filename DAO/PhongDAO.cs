using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DAO
{
    class PhongDAO
    {
        DBConnection conn = new DBConnection();
        private static PhongDAO instance;
        public static PhongDAO Instance
        {
            get { if (instance == null) instance = new PhongDAO(); return PhongDAO.instance; }
            private set => PhongDAO.instance = value;
        }

        public PhongDAO() { }

        public List<Phong> layMaPhong(string matoa)
        {
            List<Phong> list = new List<Phong>();
            string query = string.Format("select * from phong where matoa = '{0}'", matoa);

            DataTable data = DBConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Phong phong = new Phong(row);
                list.Add(phong);
            }

            return list;
        }

        public List<Phong> layPhong()
        {
            List<Phong> list = new List<Phong>();
            string query = "select * from phong ";

            DataTable data = DBConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Phong phong = new Phong(row);
                list.Add(phong);
            }

            return list;
        }

        public DataTable tim(string maphong)
        {
            string query = "select * from Phong where MaPhong like N'%" + maphong+ "%'";
            return conn.FormLoad(query);
        }
        
        public void Xoa(string map,string so)
        {
            string sqlStr = string.Format("UTP_XoaPhong '{0}' , {1}",map,so);
            conn.ThucThi(sqlStr);
        }
        public void them(string map, string LoaiPhong, string MaToa)
        {
            string query = string.Format("Insert into Phong values('{0}','{1}','{2}','{3}')",map,LoaiPhong,MaToa,0);
            conn.ThucThi(query);
        }
    }
}
