using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class ChiTietNhapHangDAL
    {
        private static ChiTietNhapHangDAL instance;

        public static ChiTietNhapHangDAL Instance
        {
            get { if (instance == null) instance = new ChiTietNhapHangDAL(); return ChiTietNhapHangDAL.instance; }
            private set { ChiTietNhapHangDAL.instance = value; }
        }

        private ChiTietNhapHangDAL() { }

        public void InsertBillInfo(int maHDNH, string tenHang, int soLuong, float donGia)
        {
            string kiemtra = "select * from CHITIETNHAPHANG where MaHDNH = '" + maHDNH + "' and TENHANG = N'" + tenHang + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(kiemtra);
            if(dt.Rows.Count >= 1)
            {
                string laySoLuong = "select SoLuong from CHITIETNHAPHANG where TENHANG = N'" + tenHang + "' and MaHDNH ='" + maHDNH + "'";
                int count = (int)DataProvider.Instance.ExcuteScalar(laySoLuong);
                int newCount = count + soLuong;
                if (newCount > 0)
                {
                    string update = "update CHITIETNHAPHANG set SoLuong = SoLuong + '" + soLuong + "' where TENHANG = N'" + tenHang + "'";
                    DataProvider.Instance.ExecuteQuery(update);
                }
                else
                {
                    string delete = "delete CHITIETNHAPHANG where MaHDBH = '" + maHDNH + "' and TENHANG = N'" + tenHang + "'";
                    DataProvider.Instance.ExecuteQuery(delete);
                }
            }
            else
            {
                DataProvider.Instance.ExcuteNonQuery("insert into CHITIETNHAPHANG values('" + maHDNH + "', N'" + tenHang + "', '" + soLuong + "', '"+donGia+"' )");
            }
        }
        public DataTable ShowBillInfo(int maHDNH)
        {
            string sql = "select MaCTNH, TENHANG, SoLuong, DONGIA, SoLuong*DONGIA as ThanhTien from CHITIETNHAPHANG where MaHDNH = '" + maHDNH + "' ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public double TongTien(int maHDNH)
        {
            
            string sql = "select sum(soluong*DONGIA) as TongCong from CHITIETNHAPHANG where MaHDNH = '" + maHDNH + "' ";

            return (double)DataProvider.Instance.ExcuteScalar(sql);
        }

        public void Xoa(int maCTNH)
        {
            string sql = "delete CHITIETNHAPHANG where MaCTNH = '" + maCTNH + "' ";
            DataProvider.Instance.ExecuteQuery(sql);
        }
    }
}
