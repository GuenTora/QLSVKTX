using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DAO
{
    internal class QuanLyDAO
    {
        DBConnection dbConnec = new DBConnection();

        public void Sua(string Ten, string ma)
        {
            string sqlStr = string.Format("update QuanLy set HoTen = '{0}' where MaQL = '{1}'",Ten,ma);
            dbConnec.ThucThi(sqlStr);
        }

    }
}
