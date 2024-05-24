using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DAO
{
    class ToaDAO
    {
        private static ToaDAO instance;
        public static ToaDAO Instance
        {
            get { if (instance == null) instance = new ToaDAO(); return ToaDAO.instance; }
            private set => ToaDAO.instance = value;
        }

        private ToaDAO() { }

        public List<Toa> layMaToa(string gioitinh)
        {
            List<Toa> list = new List<Toa>();
            string query = "UTP_ChonToaTheoGioiTinh @gioitinh";

            DataTable data = DBConnection.Instance.ExecuteQuery(query, new object[] { gioitinh });

            foreach (DataRow row in data.Rows)
            {
                Toa toa = new Toa(row);
                list.Add(toa);
            }

            return list;
        }

        internal List<Toa> layMaToa()
        {
            List<Toa> list = new List<Toa>();
            string query = "select * from USV_Toa";

            DataTable data = DBConnection.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Toa toa = new Toa(row);
                list.Add(toa);
            }

            return list;
        }
    }
}
