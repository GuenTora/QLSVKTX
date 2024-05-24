using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    class Phong
    {
        private string maPhong;
        private string loaiPhong;
        private string maToa;
        private int soNguoiDaO;

        public Phong(DataRow row)
        {
            this.MaPhong = row["MaPhong"].ToString();
            this.LoaiPhong = row["LoaiPhong"].ToString();
            this.MaToa = row["MaToa"].ToString();
            this.SoNguoiDaO = (int)row["SoNguoiDaO"];
        }


        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }
        public string MaToa { get => maToa; set => maToa = value; }
        public int SoNguoiDaO { get => soNguoiDaO; set => soNguoiDaO = value; }
    }
}
