using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    internal class TaiKhoan
    {

        private string taiKhoan;
        private string matKhau;
        private int capBac;


        public TaiKhoan(DataRow row)
        {
            this.Taikhoan = row["Taikhoan"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            this.CapBac = (int)row["CapBac"];
        }
        public TaiKhoan() { }

        public string Taikhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int CapBac { get => capBac; set => capBac = value; }
    }
}
