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
    public partial class frm_QuanLy : Form
    {
        public frm_QuanLy()
        {
            InitializeComponent();
        }

        private void frm_QuanLy_Load(object sender, EventArgs e)
        {
            LoadNV();
            LoadCLV();
            LoadLuong();
            LoadComBoNhanVien();
            LoadComboCLV();
            LoadDM();
            LoadSP();
            LoadCBDM();
            LoadBan();
        }
        

        #region Nhân viên
        void LoadNV()
        {
            dataNhanVien.DataSource = NhanVienDAL.Instance.LoadNV();
        }

        void Reset()
        {
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            txtSoDT.ResetText();
            txtMatKhau.ResetText();
        }

        #region event Nhân viên



        private void btnThemNV_Click(object sender, EventArgs e)
        {
            NhanVienDAL.Instance.ThemNV(txtMaNV.Text, txtTenNV.Text, cbGioiTinh.Text, (DateTime)dtpNgayVaoLam.Value, txtSoDT.Text, cbQuyen.Text, txtMatKhau.Text);
            LoadNV();
            Reset();
        }

        private void txtTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            dataNhanVien.DataSource = NhanVienDAL.Instance.TimKiemNV(txtTimKiemNV.Text);
        }

        private void btnCapNhatNV_Click(object sender, EventArgs e)
        {
            NhanVienDAL.Instance.CapNhatNV(txtMaNV.Text, txtTenNV.Text, cbGioiTinh.Text, (DateTime)dtpNgayVaoLam.Value, txtSoDT.Text, cbQuyen.Text, txtMatKhau.Text);
            LoadNV();
            Reset();
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            NhanVienDAL.Instance.XoaNV(txtMaNV.Text);
            LoadNV();
            Reset();
        }

        private void dataNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dataNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dataNhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
            cbGioiTinh.Text = dataNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString();
            dtpNgayVaoLam.Text = dataNhanVien.CurrentRow.Cells["NgayVaoLam"].Value.ToString();
            txtSoDT.Text = dataNhanVien.CurrentRow.Cells["SoDT"].Value.ToString();
            cbQuyen.Text = dataNhanVien.CurrentRow.Cells["Quyen"].Value.ToString();
            txtMatKhau.Text = dataNhanVien.CurrentRow.Cells["MatKhau"].Value.ToString();
        }
        #endregion

        #endregion
        
        #region Ca làm việc

        void LoadCLV()
        {
            dataCLV.DataSource = CaLamViecDAL.Instance.LoadCaLam();
        }

        void ResetCLV()
        {
            txtMaCLV.ResetText();
            txtTenCLV.ResetText();
            txtLuongCLV.ResetText();
        }
        #region event Ca làm việc

        private void btnThemCLV_Click(object sender, EventArgs e)
        {
            CaLamViecDAL.Instance.ThemCaLam(txtTenCLV.Text, float.Parse(txtLuongCLV.Text));
            LoadCLV();
            ResetCLV();
        }

        private void btnCapNhatCLV_Click(object sender, EventArgs e)
        {
            CaLamViecDAL.Instance.CapNhatCaLam(int.Parse(txtMaCLV.Text), txtTenCLV.Text, float.Parse(txtLuongCLV.Text));
            LoadCLV();
            ResetCLV();
        }

        private void btnXoaCLV_Click(object sender, EventArgs e)
        {
            CaLamViecDAL.Instance.XoaCaLam(int.Parse(txtMaCLV.Text));
            LoadCLV();
            ResetCLV();
        }

        private void dataCLV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCLV.Text = dataCLV.CurrentRow.Cells["MaCLV"].Value.ToString();
            txtTenCLV.Text = dataCLV.CurrentRow.Cells["TenCLV"].Value.ToString();
            txtLuongCLV.Text = dataCLV.CurrentRow.Cells["TienLuong"].Value.ToString();
        }

        #endregion

        #endregion
               
        #region Chi tiết lương
        void LoadLuong()
        {
            dataChiTietLuong.DataSource = ChiTietLuongDAL.Instance.LoadLuong();
        }

        void LoadComBoNhanVien()
        {
            cbNhanVien.DataSource = NhanVienDAL.Instance.LoadNV();
            cbNhanVien.DisplayMember = "TenNV";
            cbNhanVien.ValueMember = "MaNV";
        }

        void LoadComboCLV()
        {
            cbCaLam.DataSource = CaLamViecDAL.Instance.LoadCaLam();
            cbCaLam.ValueMember = "MaCLV";
            cbCaLam.DisplayMember = "TenCLV";
        }

        

        #region event Chi tiết lương
        // Thêm lương
        private void button11_Click(object sender, EventArgs e)
        {
            ChiTietLuongDAL.Instance.ThemLuong(cbNhanVien.SelectedValue.ToString(), (int)cbCaLam.SelectedValue, (DateTime)dtpNgayLuong.Value);
            LoadLuong();
        }

        private void btnCapNhatLuong_Click(object sender, EventArgs e)
        {
            ChiTietLuongDAL.Instance.CapNhatLuong(int.Parse(txtMaCTL.Text), cbNhanVien.SelectedValue.ToString(), (int)cbCaLam.SelectedValue, (DateTime)dtpNgayLuong.Value);
            LoadLuong();
        }

        private void btnXoaLuong_Click(object sender, EventArgs e)
        {
            ChiTietLuongDAL.Instance.XoaLuong(int.Parse(txtMaCTL.Text));
            LoadLuong();
        }

        private void dataChiTietLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCTL.Text = dataChiTietLuong.CurrentRow.Cells["MaCTL"].Value.ToString();
            cbNhanVien.Text = dataChiTietLuong.CurrentRow.Cells["MaNVL"].Value.ToString();
            cbCaLam.Text = dataChiTietLuong.CurrentRow.Cells["MaCLVL"].Value.ToString();
            dtpNgayLuong.Text = dataChiTietLuong.CurrentRow.Cells["NgayLuong"].Value.ToString();
        }
        #endregion

        #endregion

        #region Danh mục sản phẩm
        public void LoadDM()
        {
            dataDanhMuc.DataSource = DanhMucDAL.Instance.LoadDanhMuc();
        }
        public void LoadSP()
        {
            dataSanPham.DataSource = SanPhamDAL.Instance.LoadSP();
        }
        public void LoadCBDM()
        {
            cbDM.DataSource = DanhMucDAL.Instance.LoadDanhMuc();
            cbDM.ValueMember = "MaDM";
            cbDM.DisplayMember = "TenDM";
        }
        #region event danh mục
        private void bthThemDM_Click(object sender, EventArgs e)
        {
            DanhMucDAL.Instance.ThemDM(txtTenDM.Text, txtMoTa.Text);
            LoadDM();
            LoadCBDM();
        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            DanhMucDAL.Instance.SuaDM(int.Parse(txtMaDM.Text), txtTenDM.Text, txtMoTa.Text);
            LoadDM();
            LoadCBDM();
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            DanhMucDAL.Instance.XoaDM(int.Parse(txtMaDM.Text));
            LoadDM();
            LoadCBDM();
        }

        private void dataDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDM.Text = dataDanhMuc.CurrentRow.Cells["MaDM"].Value.ToString();
            txtTenDM.Text = dataDanhMuc.CurrentRow.Cells["TenDM"].Value.ToString();
            txtMoTa.Text = dataDanhMuc.CurrentRow.Cells["MoTa"].Value.ToString();
        }

        #endregion

        #region event sản phẩm
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            SanPhamDAL.Instance.ThemSP(txtTenSP.Text, (int)cbDM.SelectedValue, double.Parse(txtDonGia.Text));
            pbHinhSP.Image.Save(@"D:\CDIO 4\SE447I_QLCAFE\SE447I_QLCAFE\HINH\" + txtTenSP.Text);
            LoadSP();
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            SanPhamDAL.Instance.SuaSP(int.Parse(txtMaSP.Text), txtTenSP.Text, (int)cbDM.SelectedValue, double.Parse(txtDonGia.Text));
            pbHinhSP.Image.Save(@"D:\CDIO 4\SE447I_QLCAFE\SE447I_QLCAFE\HINH\" + txtTenSP.Text);
            LoadSP();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            SanPhamDAL.Instance.XoaSP(int.Parse(txtMaSP.Text));
            LoadSP();
        }

        private void dataSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dataSanPham.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dataSanPham.CurrentRow.Cells["TenSP"].Value.ToString();
            cbDM.Text = dataSanPham.CurrentRow.Cells["TenDMSP"].Value.ToString();
            txtDonGia.Text = dataSanPham.CurrentRow.Cells["DonGia"].Value.ToString();
            pbHinhSP.ImageLocation = @"D:\CDIO 4\SE447I_QLCAFE\SE447I_QLCAFE\HINH\" + txtTenSP.Text;
        }

        private void txtTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            dataSanPham.DataSource = SanPhamDAL.Instance.TimKiemSP(txtTimKiemSP.Text);
        }
        #endregion
        #endregion

        #region Bàn
        public void LoadBan()
        {
            dataBan.DataSource = BanDAL.Instance.LoadBan();
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            BanDAL.Instance.ThemBan(txtTenBan.Text, txtTrangThai.Text);
            LoadBan();
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            BanDAL.Instance.SuaBan(int.Parse(txtMaBan.Text), txtTenBan.Text);
            LoadBan();
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            BanDAL.Instance.XoaBan(int.Parse(txtMaBan.Text));
            LoadBan();
        }

        private void dataBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBan.Text = dataBan.CurrentRow.Cells["MaBan"].Value.ToString();
            txtTenBan.Text = dataBan.CurrentRow.Cells["TenBan"].Value.ToString();
        }
        #endregion

        private void frm_QuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }


        // Tải hình
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Hãy chọn hình ảnh sản phẩm";
            open.Filter = "JEPG|*.jepg|BMP|*.bmp|Tất cả các file|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbHinhSP.Image = Image.FromFile(open.FileName);
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }
    }
}