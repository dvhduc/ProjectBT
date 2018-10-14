using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanVien
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "" || txtPass.Text == "")
            {
                lbBaoLoi.Text = "Vui lòng nhập Username hoặc password !! ";
            }
            else
            {
                if(txtName.Text=="admin" && txtPass.Text=="admin")
                 {
                     DialogResult = DialogResult.OK;
                 }
                else
                {
                    lbBaoLoi.Text = "Bạn nhập sai username hoặc mật khẩu !";
                }
            }
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
