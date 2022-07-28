using SE447I_QLCAFE.DAL;
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
    public partial class frm_DoiMatKhau : Form
    {
        string maNV, matKhau, quyen, tenHienThi;

        //Quân test thử

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = DAL.NhanVienDAL.Instance.checkPass(txtMaNV.Text, txtMKCu.Text);
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Mật khẩu hiện tại không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtMKMoi.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NhanVienDAL.Instance.DoiPass(txtMaNV.Text, txtMKMoi.Text);
                MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtMKCu.PasswordChar = (char)0;
                txtMKMoi.PasswordChar = (char)0;
                txtXacNhanMK.PasswordChar = (char)0;
            }
            else
            {
                txtMKCu.PasswordChar = '*';
                txtMKMoi.PasswordChar = '*';
                txtXacNhanMK.PasswordChar = '*';
            }

        }

        public frm_DoiMatKhau()
        {
            InitializeComponent();
        }
        

        private void frm_DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = maNV;
        }

        public frm_DoiMatKhau(string MaNV, string MatKhau, string Quyen, string TenHienThi)
        {

            InitializeComponent();
            this.maNV = MaNV;
            this.matKhau = MatKhau;
            this.quyen = Quyen;
            this.tenHienThi = TenHienThi;
        }

    }
}
