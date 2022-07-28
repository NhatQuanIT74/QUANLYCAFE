using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class DoanhThuDAL
    {
        private static DoanhThuDAL instance;

        public static DoanhThuDAL Instance
        {
            get { if (instance == null) instance = new DoanhThuDAL(); return DoanhThuDAL.instance; }
            private set { DoanhThuDAL.instance = value; }
        }

        private DoanhThuDAL() { }

        public List<DTO.DoanhThu> GetListDoanhThu(DateTime ngayBD, DateTime ngayKT)
        {
            List<DTO.DoanhThu> listdoanhthu = new List<DTO.DoanhThu>();
            string sql = "select MaHDBH, TenNV, TenBan, NgayBan, GiamGia, TongTien from HOADONBANHANG hd, NHANVIEN nv, Ban b where NgayBan between '" + ngayBD + "' and '" + ngayKT + "' and nv.MaNV = hd.MaNV and hd.Ban = b.MaBan and status = 1";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                DTO.DoanhThu info = new DTO.DoanhThu(item);
                listdoanhthu.Add(info);
            }
            return listdoanhthu;
        }
    }
}
