using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    class Toa
    {
        private string maToa;
        private string tenToa;
        private string gioiTinh;

        public Toa(DataRow row)
        {
            this.MaToa = row["MaToa"].ToString();
            this.TenToa = row["TenToa"].ToString();
            this.GioiTinh = row["gioitinh"].ToString();

        }

        public string MaToa { get => maToa; set => maToa = value; }
        public string TenToa { get => tenToa; set => tenToa = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}
