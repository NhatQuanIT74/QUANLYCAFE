using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class KhachHangDAL
    {
        private static KhachHangDAL instance;

        public static KhachHangDAL Instance
        {
            get { if (instance == null) instance = new KhachHangDAL(); return KhachHangDAL.instance; }
            private set { KhachHangDAL.instance = value; }
        }

        private KhachHangDAL() { }

        public DataTable ShowKhachHang()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from KHACHHANG");
            return data;
        }

        public void ThemKH(string tenKH, string soDT, int DiemTL)
        {
            string sql = "Insert into KHACHHANG values(N'" + tenKH + "',N'" + soDT + "','" + DiemTL + "')";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public void SuaKH(int maKH, string tenKH, string soDT)
        {
            string sql = "Update KHACHHANG set TenKH =N'"+tenKH+"', SoDT = '"+soDT+"' where MaKH = '"+maKH+"' ";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public void XoaKH(int maKH)
        {
            string sql = "Delete from KHACHHANG where MaKH = '" + maKH + "' ";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public void UpdateDiemTL(int maKH, double diemcong)
        {
            string sql = "Update KHACHHANG set DiemTL = DiemTL + '" + diemcong + "' where maKH ='" + maKH + "' ";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
        public void TruDiem(int MaKH, int diemtru)
        {
            string sql = "Update KHACHHANG set DiemTL = DiemTL - '" + diemtru + "' where MaKH ='" + MaKH + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
    }

}
