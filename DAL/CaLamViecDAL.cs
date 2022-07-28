using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class CaLamViecDAL
    {
        private static CaLamViecDAL instance;

        public static CaLamViecDAL Instance
        {
            get { if (instance == null) instance = new CaLamViecDAL(); return CaLamViecDAL.instance; }
            private set { CaLamViecDAL.instance = value; }
        }

        public DataTable LoadCaLam()
        {
            string sql = "select * from CALAMVIEC";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public void ThemCaLam(string TenCLV, float TienLuong)
        {
            string sql = "Insert into CALAMVIEC values(N'"+TenCLV+"', '"+TienLuong+"')";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
        public void CapNhatCaLam(int MaCLV, string TenCLV, float TienLuong)
        {
            string sql = "Update CALAMVIEC set TenCLV = N'" + TenCLV + "', TienLuong = '" + TienLuong + "' where MaCLV = '"+MaCLV+"'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
        public void XoaCaLam(int MaCLV)
        {
            string sql = "delete CALAMVIEC where MaCLV ='"+MaCLV+"'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
    }
}
