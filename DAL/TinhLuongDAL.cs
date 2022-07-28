using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class TinhLuongDAL
    {
        private static TinhLuongDAL instance;

        public static TinhLuongDAL Instance
        {
            get { if (instance == null) instance = new TinhLuongDAL(); return TinhLuongDAL.instance; }
            private set { TinhLuongDAL.instance = value; }
        }

        private TinhLuongDAL() { }

        public List<DTO.LuongNhanVien> GetListSanPham(string tenNV, int thang, int Nam)
        {
            List<DTO.LuongNhanVien> listsanpham = new List<DTO.LuongNhanVien>();
            string sql = "select TenCLV, NgayLuong, TienLuong from CHITIETLUONG ct, CALAMVIEC cl, NHANVIEN nv where ct.MaCLV=cl.MaCLV and nv.MaNV=ct.MaNV and TenNV = N'"+tenNV+"' and Month(NgayLuong) = '"+thang+"' and YEAR(NgayLuong)='"+Nam+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                DTO.LuongNhanVien info = new DTO.LuongNhanVien(item);
                listsanpham.Add(info);
            }
            return listsanpham;
        }

        
    }
}
