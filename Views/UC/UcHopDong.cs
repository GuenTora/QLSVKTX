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

namespace QLSV.Views.UC
{
    public partial class UcHopDong : UserControl
    {
        public UcHopDong()
        {
            InitializeComponent();
            LoadCB();
        }
        void LoadCB()
        {
            cbToa.Items.Add("Tất cả");
            List<Toa> list = ToaDAO.Instance.layMaToa();
            foreach (Toa toa in list)
            {
                cbToa.Items.Add(toa.MaToa);
            }
            cbToa.SelectedIndex = 0;
        }
        void clear()
        {
            dtgvTongTien.DataSource = null;
            dtgvTongTien.Rows.Clear();
        }
        void Load()
        {
            dtgvTongTien.ColumnCount = 4;
            dtgvTongTien.Columns[0].Name = "Mã Tòa";
            dtgvTongTien.Columns[1].Name = "Mã sinh viên";
            dtgvTongTien.Columns[2].Name = "Mã phòng";
            dtgvTongTien.Columns[3].Name = "Số Tiền";


            float tongtien = 0;
            if (cbToa.Text == "Tất cả")
            {

                DataTable data = DBConnection.Instance.ExecuteQuery("select * from USV_HOPDONGBoiAdmin");
                foreach (DataRow x in data.Rows)
                {
                    tongtien += (float)Convert.ToInt32(x[3]);
                    dtgvTongTien.Rows.Add(x[0], x[1], x[2], x[3]);
                }

            }
            else
            {

                DataTable data = DBConnection.Instance.ExecuteQuery("select * from USV_HOPDONGBoiAdmin where Matoa = @MaToa", new object[] { cbToa.Text });
                foreach (DataRow x in data.Rows)
                {
                    tongtien += (float)Convert.ToInt32(x[3]);
                    dtgvTongTien.Rows.Add(x[0], x[1], x[2], x[3]);
                }



            }
            txttongtien.Text = tongtien.ToString();
        }
        private void cbToa_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear();
            Load();
        }
    }
}
