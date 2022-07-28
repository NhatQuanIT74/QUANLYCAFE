using SE447I_QLCAFE.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE447I_QLCAFE
{
    public partial class frm_ThongKe : Form
    {
        public frm_ThongKe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //dataHoaDon.DataSource = HoaDonBanHangDAL.Instance.LoadDoanhThuNgay((int)dtNgayBD.Value.Day, (int)dtNgayBD.Value.Month, (int)dtNgayBD.Value.Year);
        }

        public void LoadComboNV()
        {
            cboNhanVien.DataSource = NhanVienDAL.Instance.LoadNV();
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DisplayMember = "TenNV";
        }

        private void frm_ThongKe_Load(object sender, EventArgs e)
        {
            LoadComboNV();
        }

        //Thống kê lương NV
        private void button3_Click(object sender, EventArgs e)
        {
            //dataLuongThang.DataSource = ChiTietLuongDAL.Instance.ThongKeLuongNV(cboNhanVien.Text,(int)dtThangLuongNV.Value.Month,(int)dtThangLuongNV.Value.Year);
            TinhLuong(cboNhanVien.Text, (int)dtThangLuongNV.Value.Month, (int)dtThangLuongNV.Value.Year);
            
        }

        //Thống kê doanh thu
        private void button1_Click_1(object sender, EventArgs e)
        {
            //dataHoaDon.DataSource = HoaDonBanHangDAL.Instance.ThongKeHoaDon(dtNgayBD.Value, dtNgayKT.Value);
            showDoanhThu(dtNgayBD.Value, dtNgayKT.Value);
            //CultureInfo culture = new CultureInfo("vi-VN");
            //lbTongDoanhThu.Text = HoaDonBanHangDAL.Instance.TongHoaDon(dtNgayBD.Value, dtNgayKT.Value).ToString("#,##0.###") +"  VNĐ";
            lbTongDoanhThu.Text = TinhDoanhThu(dtNgayBD.Value, dtNgayKT.Value).ToString("#,##0.###") + "  VNĐ";
        }

        void showDoanhThu(DateTime ngayBD, DateTime ngayKT)
        {
            lsvDoanhThu.Items.Clear();
            List<DTO.DoanhThu> listDoanhThuInfo = DAL.DoanhThuDAL.Instance.GetListDoanhThu(ngayBD,ngayKT);

            foreach (DTO.DoanhThu item in listDoanhThuInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.MaHDBH.ToString());
                lsvItem.SubItems.Add(item.TenNV.ToString());
                lsvItem.SubItems.Add(item.TenBan.ToString());
                lsvItem.SubItems.Add(item.NgayBan.ToString());
                lsvItem.SubItems.Add(item.GiamGia.ToString());
                lsvItem.SubItems.Add(item.TongTien.ToString());
                lsvDoanhThu.Items.Add(lsvItem);
            }
        }

        double TinhDoanhThu(DateTime ngayBD, DateTime ngayKT)
        {
            List<DTO.DoanhThu> listDoanhThuInfo = DAL.DoanhThuDAL.Instance.GetListDoanhThu(ngayBD,ngayKT);
            double tongtien = 0;
            foreach (DTO.DoanhThu item in listDoanhThuInfo)
            {
                tongtien += item.TongTien;
            }
            return tongtien;
        }

        void showSanPham(DateTime ngayBD, DateTime ngayKT)
        {
            lsvSanPham.Items.Clear();
            List<DTO.SanPhamBanRa> listSanPhamInfo = DAL.SanPhamBanRaDAL.Instance.GetListSanPham(ngayBD, ngayKT);

            foreach (DTO.SanPhamBanRa item in listSanPhamInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenSP.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvSanPham.Items.Add(lsvItem);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Thống kê sản phẩm bán ra
        private void button5_Click(object sender, EventArgs e)
        {
            showSanPham(dtNgayBD1.Value, dtNgayKT1.Value);
        }

        void TinhLuong(string tenNV, int thang, int Nam)
        {
            lsvTinhLuong.Items.Clear();
            List<DTO.LuongNhanVien> listSanPhamInfo = DAL.TinhLuongDAL.Instance.GetListSanPham(tenNV, thang,Nam);
            double tinhluong = 0;
            foreach (DTO.LuongNhanVien item in listSanPhamInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenCaLam.ToString());
                lsvItem.SubItems.Add(item.NgayLam.ToString());
                lsvItem.SubItems.Add(item.TienLuong.ToString());
                lsvTinhLuong.Items.Add(lsvItem);
                tinhluong += item.TienLuong;
            }
            lbTongLuongNV.Text = tinhluong.ToString("#,##0.###") + "  VNĐ";
        }

        void TongLuong(int thang, int nam)
        {
            lsvTongLuong.Items.Clear();
            List<DTO.TongLuong> listSanPhamInfo = DAL.TongLuongDAL.Instance.GetTongLuong(thang, nam);
            double tinhluong = 0;
            foreach (DTO.TongLuong item in listSanPhamInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenNV.ToString());
                lsvItem.SubItems.Add(item.TienLuong.ToString());
                lsvTongLuong.Items.Add(lsvItem);
                tinhluong += item.TienLuong;
            }
            lbTongLuong.Text = tinhluong.ToString("#,##0.###") + "  VNĐ";
        }

        //Tổng lương
        private void button4_Click(object sender, EventArgs e)
        {
            TongLuong((int)dtTongLuong.Value.Month, (int)dtTongLuong.Value.Year);
        }


        void showTongChi(DateTime ngayBD, DateTime ngayKT)
        {
            listTongChi.Items.Clear();
            List<DTO.TONGCHI> listDoanhThuInfo = DAL.TongChiDAL.Instance.GetListTongCHi(ngayBD, ngayKT);

            foreach (DTO.TONGCHI item in listDoanhThuInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.MaHDNH.ToString());
                lsvItem.SubItems.Add(item.TenNV.ToString());
                lsvItem.SubItems.Add(item.NgayBan.ToString());
                lsvItem.SubItems.Add(item.TongTien.ToString());
                listTongChi.Items.Add(lsvItem);
            }
        }

        double TinhTongChi(DateTime ngayBD, DateTime ngayKT)
        {
            List<DTO.TONGCHI> listDoanhThuInfo = DAL.TongChiDAL.Instance.GetListTongCHi(ngayBD, ngayKT);
            double tongtien = 0;
            foreach (DTO.TONGCHI item in listDoanhThuInfo)
            {
                tongtien += item.TongTien;
            }
            return tongtien;
        }
        //Tổng chi
        private void button2_Click(object sender, EventArgs e)
        {
            //dataHoaDon.DataSource = HoaDonBanHangDAL.Instance.ThongKeHoaDon(dtNgayBD.Value, dtNgayKT.Value);
            showTongChi(tuNgay.Value, denNgay.Value);
            //CultureInfo culture = new CultureInfo("vi-VN");
            //lbTongDoanhThu.Text = HoaDonBanHangDAL.Instance.TongHoaDon(dtNgayBD.Value, dtNgayKT.Value).ToString("#,##0.###") +"  VNĐ";
            lbTongCHi.Text = TinhTongChi(tuNgay.Value, denNgay.Value).ToString("#,##0.###") + "  VNĐ";
        }
    }
}
