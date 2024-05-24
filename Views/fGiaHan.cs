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

namespace QLSV.Views
{
    public partial class fGiaHan : Form
    {
        public fGiaHan()
        {
            InitializeComponent();
        }

        private void txbPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && Convert.ToInt32(e.KeyChar) != 8)
                e.Handled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int soky = Convert.ToInt32(txtSoKy.Text);
            int data = HopDongDAO.Instance.GiaHanHopDongSV(UserSession.LoggedInUser.Mssv, soky);
            if(data>0)
            {
                MessageBox.Show("Bạn đã đăng ký thành công vui lòng thanh toán số tiền: " + txbtien.Text, "Thông báo");
            }    
                this.Close();
        }

        private void txtSoKy_TextChanged(object sender, EventArgs e)
        {
            int soky = Convert.ToInt32(txtSoKy.Text);
           
            txbtien.Text = (DBConnection.Instance.ExecuteScalar("Select dbo.TimSoTienTheoKy( @masv , @soky )",new object[] { UserSession.LoggedInUser.Mssv, soky })).ToString();
        }
    }
}
