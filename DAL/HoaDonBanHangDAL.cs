using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    public class HoaDonBanHangDAL
    {
        private static HoaDonBanHangDAL instance;

        public static HoaDonBanHangDAL Instance
        {
            get { if (instance == null) instance = new HoaDonBanHangDAL(); return HoaDonBanHangDAL.instance; }
            private set { HoaDonBanHangDAL.instance = value; }
        }

        private HoaDonBanHangDAL() { }

        // Thành công: maHDBH
        // Thất bại: -1;

        public int GetUnCheckBillIDByTableID(int maBan)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from HOADONBANHANG where Ban ='"+maBan+"' and status = 0 ");
            if (data.Rows.Count > 0)
            {
                DTO.HOADONBANHANG bill = new DTO.HOADONBANHANG(data.Rows[0]);
                return bill.MaHDBH;
            }
            return -1;
        }

        public void InsertBill(int maBan)
        {
            DataProvider.Instance.ExcuteNonQuery("insert into HOADONBANHANG values(null, null, '"+maBan+"', null, null, null, 0)");
        }

        public int getMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("select MAX(MaHDBH) from HOADONBANHANG");
            }
            catch
            {
                return 1;
            }
        }

        public void CheckOutKH(int maHDBH, string maNV, int? maKH, DateTime ngayBan, int giamGia, float tongtien)
        {
            string sql = "Update HOADONBANHANG set MaNV ='"+maNV+"', maKH='"+maKH+"', NgayBan='"+ngayBan+"',GiamGia='"+giamGia+"', Tongtien='"+tongtien+"', status =1 where MaHDBH='" + maHDBH + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
        public void CheckOut(int maHDBH, string maNV, DateTime ngayBan, int giamGia, double tongtien)
        {
            string sql = "Update HOADONBANHANG set MaNV ='" + maNV + "', NgayBan='" + ngayBan + "',GiamGia='" + giamGia + "', Tongtien='" + tongtien + "', status =1 where MaHDBH='" + maHDBH + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public DataTable LoadLSGD(int MaKH)
        {
            string sql = "Select MaHDBH,TenNV, Ban,NgayBan, TongTien From NHANVIEN s, HOADONBANHANG hd where s.MaNV = hd.MaNV and MaKH = '"+MaKH+"' ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public DataTable LoadHDBH()
        {
            string sql = "select MaHDBH, NgayBan, TenBan, GiamGia, TongTien from HOADONBANHANG hd, BAN b where b.MaBan =hd.Ban and status =1";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }
        public DataTable LoadDoanhThuNgay(int ngay, int thang, int nam)
        {
            string sql = "select MaHDBH, TenNV, Ban, TongTien from HOADONBANHANG hd, NHANVIEN nv where hd.MaNV=nv.MaNV and day(NgayBan) = '"+ngay+"' and MONTH(NgayBan) = '"+thang+"' and YEAR(NgayBan) ='"+nam+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public DataTable ThongKeHoaDon(DateTime ngayBD, DateTime ngayKT)
        {
            string sql = "select MaHDBH, TenNV, TenBan, NgayBan, GiamGia, TongTien from HOADONBANHANG hd, NHANVIEN nv, Ban b where NgayBan between '"+ngayBD+"' and '"+ngayKT+"' and nv.MaNV = hd.MaNV and hd.Ban = b.MaBan and status = 1";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        //public double TongHoaDon(DateTime ngayBD, DateTime ngayKT)
        //{
        //    string sql = "select sum(TongTien) from HOADONBANHANG where NgayBan between '" + ngayBD + "' and '" + ngayKT + "' and status = 1";
        //    return (double)DataProvider.Instance.ExcuteScalar(sql);
        //}
        
    }
}
