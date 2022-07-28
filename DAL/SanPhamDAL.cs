using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class SanPhamDAL
    {
        private static SanPhamDAL instance;

        public static SanPhamDAL Instance
        {
            get { if (instance == null) instance = new SanPhamDAL(); return SanPhamDAL.instance; }
            private set { SanPhamDAL.instance = value; }
        }

        public DataTable LoadSP()
        {
            string sql = "select MaSP, TenSP, TenDM, GiaSP FROM SANPHAM s, DANHMUC d where s.MaDM = d.MaDM";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public void ThemSP(string tenSP, int MaDM, double GiaSP)
        {
            string sql = "INSERT INTO SANPHAM values(N'" + tenSP + "','" + MaDM + "',N'" + GiaSP + "')";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public void SuaSP(int MaSP, string tenSP, int MaDM, double GiaSP)
        {
            string sql = "UPDATE SANPHAM set TenSP =N'" + tenSP + "', MaDM=N'" + MaDM + "', GiaSP=N'" + GiaSP + "' where MaSP='"+MaSP+"'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public void XoaSP(int maSP)
        {
            string sql = "Delete SANPHAM where MaSP='" + maSP + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
        
        public DataTable TimKiemSP(string TenSP)
        {
            string sql = "select MaSP, TenSP, TenDM, GiaSP from SANPHAM s, DANHMUC d where TenSP LIKE N'%" + TenSP + "%' and s.MaDM = d.MaDM ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }
    }
}
