using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE447I_QLCAFE
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn thực sự muốn thoát?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = DAL.NhanVienDAL.Instance.DangNhap(txtTenDN.Text, txtMK.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!");
                frm_Home nc = new frm_Home(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                this.Hide();
                nc.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                txtMK.ResetText();
                txtMK.Focus();
            }
        }

        private void ckbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienThi.Checked == true) txtMK.PasswordChar = (char)0;
            else txtMK.PasswordChar = '*';
        }
    }
}
