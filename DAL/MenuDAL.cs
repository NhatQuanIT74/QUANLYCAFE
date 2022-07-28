using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    public class MenuDAL
    {
        private static MenuDAL instance;

        public static MenuDAL Instance
        {
            get { if (instance == null) instance = new MenuDAL(); return MenuDAL.instance; }
            private set { MenuDAL.instance = value; }
        }

        private MenuDAL() { }

        public List<DTO.Menu> GetListMenuByTable(int maBan)
        {
            List<DTO.Menu> listmenu = new List<DTO.Menu>();
            string sql = "select s.TenSP, ct.SoLuong, s.GiaSP, s.GiaSP*ct.SoLuong as N'ThanhTien' from CHITIETBANHANG ct, HOADONBANHANG hd, SANPHAM s where ct.MaHDBH = hd.MaHDBH and s.MaSP = ct.MaSP and Ban = '" + maBan + "' and status = 0 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach(DataRow item in data.Rows)
            {
                DTO.Menu menu = new DTO.Menu(item);
                listmenu.Add(menu); 
            }
            return listmenu;
        }

    }
}
