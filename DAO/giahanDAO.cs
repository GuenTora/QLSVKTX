using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DAO
{
    internal class giahanDAO
    {
        DBConnection conn = new DBConnection();

        public DataTable DanhSach()
        {
            string lenh = string.Format("select * from GiaHan where duyet = 0");
            return conn.FormLoad(lenh);
        }

        public void duyet(string ma)
        {
            string lenh = string.Format("update GiaHan set duyet = 1 where MaSV = '{0}'",ma);
           conn.FormLoad(lenh);
        }
    }
}
