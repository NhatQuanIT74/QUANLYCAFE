using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class TongChiDAL
    {
        private static TongChiDAL instance;

        public static TongChiDAL Instance
        {
            get { if (instance == null) instance = new TongChiDAL(); return TongChiDAL.instance; }
            private set { TongChiDAL.instance = value; }
        }

        private TongChiDAL() { }

        public List<DTO.TONGCHI> GetListTongCHi(DateTime ngayBD, DateTime ngayKT)
        {
            List<DTO.TONGCHI> listdoanhthu = new List<DTO.TONGCHI>();
            string sql = "select MaHDNH, TenNV, NgayNhap, TongTien from HOADONNHAPHANG hd, NHANVIEN nv where NgayNhap between '" + ngayBD + "' and '" + ngayKT + "' and nv.MaNV = hd.MaNV and status = 1";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                DTO.TONGCHI info = new DTO.TONGCHI(item);
                listdoanhthu.Add(info);
            }
            return listdoanhthu;
        }
    }
}
