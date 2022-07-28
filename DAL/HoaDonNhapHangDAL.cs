using SE447I_QLCAFE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class HoaDonNhapHangDAL
    {
        private static HoaDonNhapHangDAL instance;

        public static HoaDonNhapHangDAL Instance
        {
            get { if (instance == null) instance = new HoaDonNhapHangDAL(); return HoaDonNhapHangDAL.instance; }
            private set { HoaDonNhapHangDAL.instance = value; }
        }

        private HoaDonNhapHangDAL() { }

        public int GetIDBillUnpaid()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from HOADONNHAPHANG where status = 0");
            if (data.Rows.Count > 0)
            {
                HOADONNHAPHANG bill = new HOADONNHAPHANG(data.Rows[0]);
                return bill.MaHDNH;
            }
            return -1;
        }

        public void InsertBill()
        {
            DataProvider.Instance.ExcuteNonQuery("insert into HOADONNHAPHANG values(null, null, null, 0)");
        }

        public int getMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("select MAX(MaHDNH) from HOADONNHAPHANG");
            }
            catch
            {
                return 1;
            }
        }

        public void ThanhToan(int maHDNH, string maNV, DateTime ngayBan, double tongtien)
        {
            string sql = "Update HOADONNHAPHANG set MaNV ='" + maNV + "', NgayNhap='" + ngayBan + "', TongTien='" + tongtien + "', status =1 where MaHDNH='" + maHDNH + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
        //public DataTable ThongKeHoaDon(DateTime ngayBD, DateTime ngayKT)
        //{
        //    string sql = "select MaHDNH, TenNV, NgayNhap, TongTien from HOADONNHAPHANG hd, NHANVIEN nv where NgayNhap between '" + ngayBD + "' and '" + ngayKT + "' and nv.MaNV = hd.MaNV and status = 1";
        //    DataTable data = DataProvider.Instance.ExecuteQuery(sql);
        //    return data;
        //}
    }
}
