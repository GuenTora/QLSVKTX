using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.DTO
{
    internal class HopDong
    {
        int maSK;
        string maPhong;
        string maSV;
        string maToa;
        int soKy;
        DateTime ngayNhanPhong;
        DateTime ngayTraPhong;
        float tien;


        public HopDong(DataRow row)
        {
            this.MaSK = Convert.ToInt32(row["MaSK"].ToString());
            this.maPhong = row["MaPhong"].ToString();
            this.maSV = row["MaSV"].ToString();
            this.maToa = row["MaToa"].ToString();
            this.soKy = Convert.ToInt32( row["SoKy"].ToString());
            this.ngayNhanPhong = (DateTime)row["NgayNhanPhong"];
            this.ngayTraPhong =(DateTime) row["NgayTraPhong"];
            this.tien = Convert.ToInt32(row["SoTien"].ToString());
           
        }

     
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string MaSV { get => maSV; set => maSV = value; }
        public string MaToa { get => maToa; set => maToa = value; }
        public int SoKy { get => soKy; set => soKy = value; }
        public DateTime NgayNhanPhong { get => ngayNhanPhong; set => ngayNhanPhong = value; }
        public DateTime NgayTraPhong { get => ngayTraPhong; set => ngayTraPhong = value; }
        public float Tien { get => tien; set => tien = value; }
        public int MaSK { get => maSK; set => maSK = value; }
    }
}
