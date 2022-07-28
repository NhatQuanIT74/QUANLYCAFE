using SE447I_QLCAFE.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE447I_QLCAFE
{
    public partial class frm_Home : Form
    {
        string maNV, matKhau, quyen, tenHienThi;
        public static int maKH;
        public static string tenKH;
        public frm_Home()
        {
            InitializeComponent();
        }
       
        public frm_Home(string MaNV, string MatKhau, string Quyen, string TenHienThi)
        {

            InitializeComponent();
            this.maNV = MaNV;
            this.matKhau = MatKhau;
            this.quyen = Quyen;
            this.tenHienThi = TenHienThi;
        }

        public void LoadFoodByDanhMuc()
        {
            string sql = "Select MaSP, TenSP, GiaSP from SANPHAM s, DANHMUC d where s.MaDM=d.MaDM and TenDM=N'"+cbDanhMuc.Text+"' ";
            dataGridView1.DataSource = DAL.DataProvider.Instance.ExecuteQuery(sql);
        }

        public void DanhMucComboBox()
        {
            cbDanhMuc.DataSource = DAL.DanhMucDAL.Instance.LoadDanhMuc();
            cbDanhMuc.DisplayMember = "TenDM";
            cbDanhMuc.ValueMember = "MaDM";
        }

        public void TableComboBox()
        {
            cbBan.DataSource = DAL.TableDAL.Instance.LoadTableList();
            cbBan.DisplayMember = "TenBan";
            //cbBan.ValueMember = "MaBan";
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<DTO.Table> tableList = DAL.TableDAL.Instance.LoadTableList();
            foreach (DTO.Table item in tableList)
            {
                Button btn = new Button() { Width = DAL.TableDAL.TableWidth, Height = DAL.TableDAL.TableHeight };
                btn.Text = item.TenBan /* +  Environment.NewLine + item.TrangThai */;
                btn.Image = global::SE447I_QLCAFE.Properties.Resources.Coffee_icon__1_;
                btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;

                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.TrangThai)
                {
                    case "Trống":
                        btn.BackColor = Color.White;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }

        
        void showBill(int maBan)
        {
            lsvBill.Items.Clear();
            List<DTO.Menu> listBillInfo = DAL.MenuDAL.Instance.GetListMenuByTable(maBan);
            float tongtien = 0;
            float tongdichvu = 0;
            foreach (DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenSP.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                lsvBill.Items.Add(lsvItem);
                tongdichvu += item.ThanhTien;
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            lbTongDV.Text = tongdichvu.ToString("#,##0.###");
            tongtien = tongdichvu - (tongdichvu * (int)nmGiamGia.Value) / 100;
            lbTongTien.Text = tongtien.ToString("#,##0.###");
        }

        void showBillNhap()
        {
            dtNhapHang.DataSource = DAL.ChiTietNhapHangDAL.Instance.ShowBillInfo(DAL.HoaDonNhapHangDAL.Instance.GetIDBillUnpaid());
            txtMaHDNH.Text = DAL.HoaDonNhapHangDAL.Instance.GetIDBillUnpaid().ToString();
        }

        #region event

        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as DTO.Table).MaBan;
            showBill(tableID);
            lsvBill.Tag = (sender as Button).Tag;
            lbBan.Text = ((sender as Button).Tag as DTO.Table).TenBan.ToString();
        }

        private void frm_Home_Load(object sender, EventArgs e)
        {
            DanhMucComboBox();
            LoadFoodByDanhMuc();
            TableComboBox();
            LoadTable();
            lbTenNV.Text = tenHienThi;
            txtNhanVien.Text = tenHienThi;
            showBillNhap();
            txtTenKH.Text = tenKH;

            if(quyen == "Nhân viên")
            {
                adminToolStripMenuItem.Visible = false;
                báoCáoThốngKêToolStripMenuItem.Visible = false;
            }
        }
            
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbTenSP.Text = dataGridView1.CurrentRow.Cells["TenSP"].Value.ToString();
            lbMaSP.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            pictureSanPham.ImageLocation = @"D:\CDIO 4\SE447I_QLCAFE\SE447I_QLCAFE\HINH\" + lbTenSP.Text;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DangNhap dn = new frm_DangNhap();
            this.Hide();
            dn.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            
            frm_QLKhachHang ns = new frm_QLKhachHang();
            ns.ShowDialog();
            this.txtTenKH.Text = tenKH;
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = DAL.HoaDonBanHangDAL.Instance.GetUnCheckBillIDByTableID(table.MaBan);
            int maSP = int.Parse(lbMaSP.Text);
            int soLuong = (int)numSoLuong.Value;
            if (idBill == -1)
            {
                DAL.HoaDonBanHangDAL.Instance.InsertBill(table.MaBan);
                DAL.ChiTietBanHangDAL.Instance.InsertBillInfo(DAL.HoaDonBanHangDAL.Instance.getMaxIDBill(),maSP,soLuong);
            }
            else
            {
                DAL.ChiTietBanHangDAL.Instance.InsertBillInfo(idBill, maSP, soLuong);
            }
            showBill(table.MaBan);
            LoadTable();
        }

        // Thanh toán bán hàng
        private void button3_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = DAL.HoaDonBanHangDAL.Instance.GetUnCheckBillIDByTableID(table.MaBan);
            if (idBill != -1)
            {
                DialogResult r = MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho " + table.TenBan, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    //DialogResult kh = MessageBox.Show("Khách hàng có thẻ thành viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(/*kh == DialogResult.Yes*/txtTenKH.Text != "")
                    {
                        DAL.HoaDonBanHangDAL.Instance.CheckOutKH(idBill, maNV, maKH, dtNgayBan.Value, (int)nmGiamGia.Value, float.Parse(lbTongTien.Text));
                        
                        DAL.KhachHangDAL.Instance.UpdateDiemTL(maKH, double.Parse(lbTongTien.Text) / 10000);
                        DAL.KhachHangDAL.Instance.TruDiem(maKH, int.Parse(txtTruDiem.Text));
                        showBill(table.MaBan);
                    }
                    else
                    {
                        DAL.HoaDonBanHangDAL.Instance.CheckOut(idBill, maNV, dtNgayBan.Value, (int)nmGiamGia.Value, float.Parse(lbTongTien.Text));
                        showBill(table.MaBan);
                    }
                }
            }
            LoadTable();
            txtTenKH.ResetText();
            maKH = (char)0;
            tenKH = null;
        }

        private void nmGiamGia_ValueChanged(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            showBill(table.MaBan);
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            int idBill = DAL.HoaDonNhapHangDAL.Instance.GetIDBillUnpaid();
            if (idBill == -1)
            {
                DAL.HoaDonNhapHangDAL.Instance.InsertBill();
                DAL.ChiTietNhapHangDAL.Instance.InsertBillInfo(DAL.HoaDonNhapHangDAL.Instance.GetIDBillUnpaid(),txtTenHang.Text,(int)nmSLNhapHang.Value,float.Parse(txtDonGia.Text));
            }
            else
            {
                DAL.ChiTietNhapHangDAL.Instance.InsertBillInfo(idBill, txtTenHang.Text, (int)nmSLNhapHang.Value, float.Parse(txtDonGia.Text));
            }
            showBillNhap();
            lbTongCong.Text = DAL.ChiTietNhapHangDAL.Instance.TongTien(DAL.HoaDonNhapHangDAL.Instance.GetIDBillUnpaid()).ToString();
        }

        private void dtNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbID.Text = dtNhapHang.CurrentRow.Cells["MaCTNH"].Value.ToString();
            txtTenHang.Text = dtNhapHang.CurrentRow.Cells["TenHang"].Value.ToString();
            //nmSLNhapHang.Value = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGia.Text = dtNhapHang.CurrentRow.Cells["DONGIA"].Value.ToString();
        }

        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            DAL.ChiTietNhapHangDAL.Instance.Xoa(int.Parse(lbID.Text));
            showBillNhap();
            lbTongCong.Text = DAL.ChiTietNhapHangDAL.Instance.TongTien(DAL.HoaDonNhapHangDAL.Instance.GetIDBillUnpaid()).ToString();
        }

        // THanh toán nhập hàng
        private void button3_Click_1(object sender, EventArgs e)
        {
            DAL.HoaDonNhapHangDAL.Instance.ThanhToan(int.Parse(txtMaHDNH.Text), maNV, dtNgayNhap.Value, float.Parse(lbTongCong.Text));
            showBillNhap();
            lbTongCong.Text = "0";
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as Table).MaBan;
            int id2 = (int)(cbBan.SelectedItem as Table).MaBan;
            DialogResult r = MessageBox.Show(string.Format("Bạn có muốn chuyển bàn {0} sang bàn {1}", (lsvBill.Tag as Table).TenBan, (cbBan.SelectedItem as Table).TenBan),"Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                //DAL.TableDAL.Instance.SwitchTable(id1,id2);

                string sql = "UPDATE HOADONBANHANG set Ban = '" + id2 + "' where Ban ='" + id1 + "' and status = 0";
                DAL.DataProvider.Instance.ExecuteQuery(sql);

                LoadTable();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes)
                Application.Exit();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_DoiMatKhau"] == null)
            {
                frm_DoiMatKhau ns = new frm_DoiMatKhau(maNV, matKhau, quyen, tenHienThi);
                //ns.MdiParent = this;
                ns.Show();
            }
            else
            {
                Application.OpenForms["frm_DoiMatKhau"].Activate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFoodByDanhMuc();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_QuanLy"] == null)
            {
                frm_QuanLy ns = new frm_QuanLy();
                //ns.MdiParent = this;
                ns.Show();
            }
            else
            {
                Application.OpenForms["frm_QuanLy"].Activate();
            }
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_ThongKe"] == null)
            {
                frm_ThongKe ns = new frm_ThongKe();
                //ns.MdiParent = this;
                ns.Show();
            }
            else
            {
                Application.OpenForms["frm_ThongKe"].Activate();
            }
        }

        #endregion
    }
}
