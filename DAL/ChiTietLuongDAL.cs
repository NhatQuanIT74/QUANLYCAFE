using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class ChiTietLuongDAL
    {

        private static ChiTietLuongDAL instance;

        public static ChiTietLuongDAL Instance
        {
            get { if (instance == null) instance = new ChiTietLuongDAL(); return ChiTietLuongDAL.instance; }
            private set { ChiTietLuongDAL.instance = value; }
        }

        public DataTable LoadLuong()
        {
            string sql = "select MaCTL, TenNV, TenCLV, NgayLuong from CHITIETLUONG c, NHANVIEN nv, CALAMVIEC cl where nv.MaNV = c.MaNV and cl.MaCLV = c.MaCLV";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public void ThemLuong(string MaNV, int MaCLV, DateTime NgayLuong)
        {
            string sql = "Insert into CHITIETLUONG values(N'" + MaNV + "', '" + MaCLV + "','"+NgayLuong+"')";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
        public void CapNhatLuong(int MaCTL, string MaNV, int MaCLV, DateTime NgayLuong)
        {
            string sql = "Update CHITIETLUONG set MaNV = '" + MaNV + "', MaCLV = '" + MaCLV + "', NgayLuong ='"+NgayLuong+"' where MaCTL = '" + MaCTL + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
        public void XoaLuong(int MaCTL)
        {
            string sql = "delete CHITIETLUONG where MaCTL ='" + MaCTL + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public DataTable ThongKeLuongNV(string tenNV, int Thang, int Nam)
        {
            string sql = "select MaCTL, TenCLV, NgayLuong from CHITIETLUONG ct, CALAMVIEC cl, NHANVIEN nv where ct.MaCLV=cl.MaCLV and nv.MaNV=ct.MaNV and TenNV = N'" + tenNV + "' and Month(NgayLuong) = '"+Thang+"' and YEAR(NgayLuong)='"+Nam+"'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql);
            return dt;
        }

        public double TongLuongNV(string tenNV, int Thang, int Nam)
        {
            string sql = "select sum(TienLuong) from CHITIETLUONG ct, CALAMVIEC cl, NHANVIEN nv where ct.MaCLV=cl.MaCLV and nv.MaNV=ct.MaNV and TenNV = N'" + tenNV + "' and Month(NgayLuong) = '" + Thang + "' and YEAR(NgayLuong)='" + Nam + "'";
            return (double)DataProvider.Instance.ExcuteScalar(sql);
        }

        //public double TinhLuongNV(string tenNV, int Thang, int Nam)
        //{
        //    DataTable data = DataProvider.Instance.ExecuteQuery("select * from CHITIETLUONG ct, CALAMVIEC cl, NHANVIEN nv where ct.MaCLV=cl.MaCLV and nv.MaNV=ct.MaNV and TenNV = N'" + tenNV + "' and Month(NgayLuong) = '" + Thang + "' and YEAR(NgayLuong)='" + Nam + "' ");
        //    if (data.Rows.Count > 0)
        //    {
        //        double tongluongNV = 0;
        //        for(int i=0; i< data.Rows.Count; i++)
        //        {
        //            DTO.HOADONBANHANG bill = new DTO.HOADONBANHANG(data.Rows[0]);
        //            tongluongNV +=
        //        }
        //    }
        //    return -1;
        //}
    }
}
