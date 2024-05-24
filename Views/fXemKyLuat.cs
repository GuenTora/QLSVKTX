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

namespace QLSV
{
    public partial class fXemKyLuat : Form
    {
        public fXemKyLuat()
        {
            InitializeComponent();
            LoadKyLuat();
        }

        void LoadKyLuat()
        {
            DataTable list = KyLuatDAO.Instance.TimKiemKyLuatTheoSV(UserSession.LoggedInUser.Mssv);
            if (list != null)
            {
                dtgvKyLuat.DataSource = list;
            }
        }
    }
}
