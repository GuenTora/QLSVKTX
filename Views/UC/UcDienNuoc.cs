using QLSV.DAO;
using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace QLSV.Views.UC
{
    public partial class UcDienNuoc : UserControl
    {
        public UcDienNuoc()
        {
            InitializeComponent();
            DateTime today = DateTime.Now;
            cbThang.Items.Add("Tất cả");
            for (int i = 1; i <= 12; i++)
            {
                cbThang.Items.Add(i);
            }
            cbThang.Text = today.Month.ToString();

        }
        void clear()
        {
            dtgvTongTien.DataSource = null;
            dtgvTongTien.Rows.Clear();
        }
        void Load()
        {
            dtgvTongTien.ColumnCount = 2;
            dtgvTongTien.Columns[0].Name = "Mã Tòa";
            dtgvTongTien.Columns[1].Name = "Tiền";
            
            
            List<Toa> list = ToaDAO.Instance.layMaToa();
            float tongtien = 0;
            if (cbThang.Text == "Tất cả")
            {   
                foreach (Toa toa in list)
                {
                    DataTable data = DBConnection.Instance.ExecuteQuery("UTP_XemTongTienTheoToa @MaToa", new object[] { toa.MaToa });
                    float tien = 0;
                    foreach (DataRow x in data.Rows)
                    {
                        tien += (float)Convert.ToInt32(x[1]);
                    }
                    tongtien += tien;
                    dtgvTongTien.Rows.Add(toa.MaToa,tien);
                }
            }             
            else {
                foreach (Toa toa in list)
                {
                    DataTable data = DBConnection.Instance.ExecuteQuery("UTP_XemTongTienTheoToaVaThang @MaToa , @Thang", new object[] { toa.MaToa, Convert.ToInt32(cbThang.Text) });
                    float tien = 0;
                    foreach (DataRow x in data.Rows)
                    {
                        tien += (float)Convert.ToInt32(x[1]);
                    }
                    tongtien += tien;
                    dtgvTongTien.Rows.Add(toa.MaToa, tien);
                }
            }
            txttongtien.Text = tongtien.ToString();
        }

        private void cbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear();
            Load();
        }
    }
}
