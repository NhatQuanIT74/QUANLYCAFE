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
    public partial class frm_QLKhachHang : Form
    {

        public frm_QLKhachHang()
        {
            InitializeComponent();
        }


        public void LoadKH()
        {
            dataKhachHang.DataSource = KhachHangDAL.Instance.ShowKhachHang();
        }

        //public void LoadLSGD()
        //{
        //    dataLSGD.DataSource = HoaDonBanHangDAL.Instance.LoadLSGD(maKH);
        //}

        #region event
        private void frm_QLKhachHang_Load(object sender, EventArgs e)
        {
            LoadKH();
        }

        private void dataKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataLSGD.DataSource = HoaDonBanHangDAL.Instance.LoadLSGD(int.Parse(dataKhachHang.CurrentRow.Cells["MaKH"].Value.ToString()));
            txtID.Text = dataKhachHang.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dataKhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
            txtSoDT.Text = dataKhachHang.CurrentRow.Cells["SoDT"].Value.ToString();
            txtDiemTL.Text = dataKhachHang.CurrentRow.Cells["DiemTL"].Value.ToString();
        }

        // Thêm mới khách hàng
        private void button8_Click(object sender, EventArgs e)
        {
            KhachHangDAL.Instance.ThemKH(txtTenKH.Text, txtSoDT.Text, int.Parse(txtDiemTL.Text));
            LoadKH();
        }

        // Cập nhật khách hàng
        private void button9_Click(object sender, EventArgs e)
        {
            KhachHangDAL.Instance.SuaKH(int.Parse(txtID.Text), txtTenKH.Text, txtSoDT.Text);
            LoadKH();
        }

        // Xóa Khách hàng
        private void button7_Click(object sender, EventArgs e)
        {
            KhachHangDAL.Instance.XoaKH(int.Parse(txtID.Text));
            LoadKH();
        }

        // Xác nhận khách hàng
        private void button1_Click(object sender, EventArgs e)
        {
            frm_Home.maKH = int.Parse(txtID.Text);
            frm_Home.tenKH = txtTenKH.Text;
            this.Hide();
        }


        #endregion

    }
}
