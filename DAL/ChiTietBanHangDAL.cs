using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    public class ChiTietBanHangDAL
    {
        private static ChiTietBanHangDAL instance;

        public static ChiTietBanHangDAL Instance
        {
            get { if (instance == null) instance = new ChiTietBanHangDAL(); return ChiTietBanHangDAL.instance; }
            private set { ChiTietBanHangDAL.instance = value; }
        }

        private ChiTietBanHangDAL() { }

        public List<DTO.CHITIETBANHANG> GetListBillInfo(int maHDBH)
        {
            List<DTO.CHITIETBANHANG> listBillInfo = new List<DTO.CHITIETBANHANG>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from CHITIETBANHANG where MaHDBH = '" + maHDBH + "' ");
            foreach (DataRow item in data.Rows)
            {
                DTO.CHITIETBANHANG info = new DTO.CHITIETBANHANG(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        public void InsertBillInfo(int maHDBH, int maSP, int soLuong)
        {
            //DataProvider.Instance.ExcuteNonQuery("InsertBillInfo @maHDBH, @maSP, @soLuong",new object[] {maHDBH, maSP, soLuong });
            string kiemtra = "select * from CHITIETBANHANG where MaHDBH = '" + maHDBH + "' and MaSP = '"+maSP+"'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(kiemtra);
            if (dt.Rows.Count >= 1)
            {
                string laySoLuong = "select SoLuong from CHITIETBANHANG where MaSP = '" + maSP + "' and MaHDBH ='" + maHDBH + "'";
                int count = (int)DataProvider.Instance.ExcuteScalar(laySoLuong);
                int newCount = count + soLuong;
                if (newCount > 0)
                {
                    string update = "update CHITIETBANHANG set SoLuong = SoLuong + '" + soLuong + "' where MaSP = '" + maSP + "'";
                    DataProvider.Instance.ExecuteQuery(update);
                }
                else
                {
                    string delete = "delete CHITIETBANHANG where MaHDBH = '"+maHDBH+"' and MaSP = '"+maSP+"'";
                    DataProvider.Instance.ExecuteQuery(delete);
                }

            }
            else
            {
                DataProvider.Instance.ExcuteNonQuery("insert into CHITIETBANHANG values('" + maHDBH + "', '" + maSP + "', '" + soLuong + "')");
            }

        }

        public DataTable LoadCTBH(int maHDBH)
        {
            string sql = "Select MaCTBH, TenSP, SoLuong, GiaSP*SoLuong as ThanhTien from CHITIETBANHANG ct, SANPHAM s where ct.MaSP = s.MaSP and MaHDBH = '"+maHDBH+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }
        
    }
}
