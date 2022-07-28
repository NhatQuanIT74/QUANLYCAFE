using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class TongLuongDAL
    {
        private static TongLuongDAL instance;

        public static TongLuongDAL Instance
        {
            get { if (instance == null) instance = new TongLuongDAL(); return TongLuongDAL.instance; }
            private set { TongLuongDAL.instance = value; }
        }

        private TongLuongDAL() { }

        public List<DTO.TongLuong> GetTongLuong(int thang, int Nam)
        {
            List<DTO.TongLuong> listsanpham = new List<DTO.TongLuong>();
            string sql = "select nv.TenNV, sum(TienLuong) as TienLuong from CALAMVIEC cl, CHITIETLUONG ct, NHANVIEN nv  where ct.MaCLV=cl.MaCLV and nv.MaNV=ct.MaNV and Month(NgayLuong) = '" + thang + "' and YEAR(NgayLuong)='" + Nam + "' group by TenNV";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                DTO.TongLuong info = new DTO.TongLuong(item);
                listsanpham.Add(info);
            }
            return listsanpham;
        }
    }
}
