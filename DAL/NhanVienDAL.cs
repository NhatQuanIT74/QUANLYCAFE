using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    public class NhanVienDAL
    {
        private static NhanVienDAL instance;

        public static NhanVienDAL Instance
        {
            get { if (instance == null) instance = new NhanVienDAL(); return NhanVienDAL.instance; }
            private set { NhanVienDAL.instance = value; }
        }

        public DataTable DangNhap(string TenDN, string MatKhau)
        {
            string sql = "select MaNV, MatKhau, Quyen, TenNV from NHANVIEN where MaNV='" + TenDN + "' and MatKhau='" + MatKhau + "'";
            return DataProvider.Instance.ExecuteQuery(sql);
        }

        public DataTable LoadNV()
        {
            string sql = "select * from NHANVIEN";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public DataTable TimKiemNV(string tenNV)
        {
            string sql = "select * from NHANVIEN where TenNV LIKE N'%" + tenNV + "%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public void ThemNV(string maNV, string tenNV, string gioiTinh, DateTime ngayVaoLam, string sodt, string quyen, string matKhau)
        {
            string sql = "Insert into NHANVIEN values ('" + maNV + "', N'" + tenNV + "',N'" + gioiTinh + "','" + ngayVaoLam + "','" + sodt + "',N'" + quyen + "','" + matKhau + "')";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public void CapNhatNV(string maNV, string tenNV, string gioiTinh, DateTime ngayVaoLam, string sodt, string quyen, string matKhau)
        {
            string sql = " Update NHANVIEN set TenNV = N'"+tenNV+ "', GioiTinh = N'" + gioiTinh + "', NgayVaoLam = '" + ngayVaoLam + "', SoDT = '"+sodt+"', Quyen = N'"+quyen+"', MatKhau = '"+matKhau+"' where MaNV = '"+maNV+"' ";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public void XoaNV(string maNV)
        {
            string sql = "delete NHANVIEN where maNV = '"+maNV+"'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public DataTable checkPass(string MaNV, string MatKhau)
        {
            string sql = "select * from NHANVIEN where MaNV='" + MaNV + "' and MatKhau='" + MatKhau + "'";
            return DataProvider.Instance.ExecuteQuery(sql);
        }
        public void DoiPass(string MaNV, string MatKhau)
        {
            string sql = "UPDATE NHANVIEN set MatKhau='" + MatKhau + "' where MaNV='" + MaNV + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
    }
}
