using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    internal class TienNuoc
    {
        private string maPhong;
        private int thang;
        private int soNuocDauThang;
        private int soNuocCuoiThang;
        private float tienNuoc;

        public TienNuoc()
        {
            
        }
        public TienNuoc(DataRow row)
        {
            this.MaPhong = row["MaPhong"].ToString();
            this.Thang = (int)row["Thang"];
            this.SoNuocDauThang = (int)row["SoNuocDauThang"];
            this.SoNuocCuoiThang = (int)row["SoNuocCuoiThang"];
            this.Tiennuoc = (float)Convert.ToDouble(row["TienNuoc"]);
        }
        public TienNuoc(string mp, int t, int sddt, int sdct)
        {
            maPhong = mp;
            thang = t;
            soNuocDauThang = sddt;
            soNuocCuoiThang = sdct;
        }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public int Thang { get => thang; set => thang = value; }
        public int SoNuocDauThang { get => soNuocDauThang; set => soNuocDauThang = value; }
        public int SoNuocCuoiThang { get => soNuocCuoiThang; set => soNuocCuoiThang = value; }
        public float Tiennuoc { get => tienNuoc; set => tienNuoc = value; }
    }
}
