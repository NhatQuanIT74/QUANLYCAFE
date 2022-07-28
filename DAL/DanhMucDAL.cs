using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class DanhMucDAL
    {
        private static DanhMucDAL instance;

        public static DanhMucDAL Instance
        {
            get { if (instance == null) instance = new DanhMucDAL(); return DanhMucDAL.instance; }
            private set { DanhMucDAL.instance = value; }
        }

        public DataTable LoadDanhMuc()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from DANHMUC");
            return data;
        }

        public void ThemDM(string tenDM, string mota)
        {
            string sql = "Insert into DANHMUC values(N'" + tenDM + "',N'" + mota + "')";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public void SuaDM(int maDm, string tenDM, string moTa)
        {
            string sql = "UPDATE DANHMUC set TenDM=N'"+tenDM+"', MoTa=N'"+moTa+"' where MaDM='"+maDm+"' ";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }

        public void XoaDM(int MaDM)
        {
            string sql = "DELETE DANHMUC where MaDM ='" + MaDM + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
    }
}
