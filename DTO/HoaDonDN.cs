using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    internal class HoaDonDN
    {
        int maHD;
        string maPhong;
        int thang;
        float tien;
        bool trangThai;

        public HoaDonDN() { }

        public HoaDonDN(DataRow row)
        {
            maHD = (int)row["MaHD"];
            maPhong = row["MaPhong"].ToString();
            thang = (int)row["Thang"];
            tien =(float)Convert.ToInt32( row["TongTien"]);
            trangThai = (bool)row["TrangThai"];
        }

        public HoaDonDN(int maHD, string maPhong, int thang, float tien, bool trangThai)
        {
            maHD = maHD;
            maPhong = maPhong;
            thang = thang;
            tien = tien;
            trangThai = trangThai;
        }

        public int MaHD { get => maHD; set => maHD = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public int Thang { get => thang; set => thang = value; }
        public float Tien { get => tien; set => tien = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }

   
}
