using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    internal class TienDien
    {
        private string maPhong;
        private int thang;
        private int soDienDauThang;
        private int soDienCuoiThang;
        private float tiendien;

        public TienDien()
        {
            
        }
        public TienDien(string mp,int t, int sddt, int sdct)
        {
            maPhong = mp;
            thang = t;
            soDienDauThang = sddt;
            soDienCuoiThang = sdct;
        }
        public TienDien(DataRow row)
        {
            this.MaPhong = row["MaPhong"].ToString();
            this.Thang = (int)row["Thang"];
            this.SoDienDauThang = (int)row["SoDienDauThang"];
            this.SoDienCuoiThang = (int)row["SoDienCuoiThang"];
            this.Tiendien = (float)Convert.ToDouble(row["TienDien"]);
        }

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public int Thang { get => thang; set => thang = value; }
        public int SoDienDauThang { get => soDienDauThang; set => soDienDauThang = value; }
        public int SoDienCuoiThang { get => soDienCuoiThang; set => soDienCuoiThang = value; }
        public float Tiendien { get => tiendien; set => tiendien = value; }


    }
}
