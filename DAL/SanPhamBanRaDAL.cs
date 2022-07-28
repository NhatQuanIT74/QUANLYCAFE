using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class SanPhamBanRaDAL
    {
        private static SanPhamBanRaDAL instance;

        public static SanPhamBanRaDAL Instance
        {
            get { if (instance == null) instance = new SanPhamBanRaDAL(); return SanPhamBanRaDAL.instance; }
            private set { SanPhamBanRaDAL.instance = value; }
        }

        private SanPhamBanRaDAL() { }

        public List<DTO.SanPhamBanRa> GetListSanPham(DateTime ngayBD, DateTime ngayKT)
        {
            List<DTO.SanPhamBanRa> listsanpham = new List<DTO.SanPhamBanRa>();
            string sql = "select sp.TenSP, sum(SoLuong) as SoLuong from CHITIETBANHANG ct, SANPHAM sp, HOADONBANHANG hd where ct.MaSP = sp.MaSP and hd.MaHDBH = ct.MaHDBH and hd.NgayBan between '"+ngayBD+"' and '"+ngayKT+"' and status =1 group by sp.TenSP";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                DTO.SanPhamBanRa info = new DTO.SanPhamBanRa(item);
                listsanpham.Add(info);
            }
            return listsanpham;
        }
    }
}
