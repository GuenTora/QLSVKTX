using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    internal class KyLuat
    {
        string maKL;
        string maSV;
        string maToa;
        string loaiViPham;
        DateTime ngayViPham;

        public KyLuat (string maKL, string maSV, string maToa, string loiViPham, DateTime ngayViPham)
        {
            this.MaKL = maKL;
            this.MaSV = maSV;
            this.MaToa = maToa;
            this.LoaiViPham = loiViPham;
            this.NgayViPham = ngayViPham;
        }


        public KyLuat () { }    

        public string MaKL { get => maKL; set => maKL = value; }
        public string MaSV { get => maSV; set => maSV = value; }
        public string MaToa { get => maToa; set => maToa = value; }
        public string LoaiViPham { get => loaiViPham; set => loaiViPham = value; }
        public DateTime NgayViPham { get => ngayViPham; set => ngayViPham = value; }
    }
}
