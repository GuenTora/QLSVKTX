using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    internal class SinhVien
    {
        string mssv;
        string ten;
        DateTime NgaySinh;
        string gioitinh;
        string cccd;
        string diachi;
        string sdt;
        string maphong;
        string matoa;
        byte[] anh = null;
        public SinhVien() { }
        public SinhVien(DataRow row)
        {
            this.Mssv = row["MaSV"].ToString();
            this.Ten = row["HoTen"].ToString();
            this.ngaySinh =(DateTime)row["NgaySinh"];
            this.Gioitinh = row["GioiTinh"].ToString();
            this.Cccd = row["CCCD"].ToString();
            this.Diachi = row["DiaChi"].ToString();
            this.Sdt = row["SDT"].ToString();
            this.Maphong = row["MaPhong"].ToString();
            this.Matoa = row["MaToa"].ToString();
            this.Anh = (byte[])(row["Anh"]);
        }


        public SinhVien(string mssv, string ten, DateTime ngaySinh, string gioitinh, string cccd, string diachi, string sdt, string maphong, string matoa)
        {
            this.Mssv = mssv;
            this.Ten = ten;
            this.NgaySinh = ngaySinh;
            this.Gioitinh = gioitinh;
            this.Cccd = cccd;
            this.Diachi = diachi;
            this.Sdt = sdt;
            this.Maphong = maphong;
            this.Matoa = matoa;
        }

        public string Mssv { get => mssv; set => mssv = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime ngaySinh { get => NgaySinh; set => NgaySinh = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Maphong { get => maphong; set => maphong = value; }
        public string Matoa { get => matoa; set => matoa = value; }
        public byte[] Anh { get => anh; set => anh = value; }
    }
}
