using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    internal class QuanLy
    {
        string maql;
        string ten;
        string maToa;
        string chucVu;

        public QuanLy(DataRow row)
        {
            this.Maql = row["MaQL"].ToString();
            this.Ten = row["HoTen"].ToString();
            this.MaToa = row["MaToaQL"].ToString();
            this.ChucVu  = row["ChucVu"].ToString();
        }
        public QuanLy(string maql, string ten, string maToa, string chucVu)
        {
            Maql = maql;
            Ten = ten;
            MaToa = maToa;
            ChucVu = chucVu;

        }

        public QuanLy() { }

        public string Maql { get => maql; set => maql = value; }
        public string Ten { get => ten; set => ten = value; }
        public string MaToa { get => maToa; set => maToa = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
    }
}
