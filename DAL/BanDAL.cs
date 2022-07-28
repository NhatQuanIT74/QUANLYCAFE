using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class BanDAL
    {
        private static BanDAL instance;

        public static BanDAL Instance
        {
            get { if (instance == null) instance = new BanDAL(); return BanDAL.instance; }
            private set { BanDAL.instance = value; }
        }

        public DataTable LoadBan()
        {
            string sql = "Select * FROM BAN";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            return data;
        }

        public void ThemBan(string tenBan, string trangThai)
        {
            string sql = "insert into BAN values(N'" + tenBan + "',N'" + trangThai + "')";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
        public void SuaBan(int MaBan, string TenBan)
        {
            string sql = "UPDATE BAN set TenBan=N'" + TenBan + "' where MaBan='" + MaBan + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
        public void XoaBan(int MaBan)
        {
            string sql = "Delete BAN where MaBan ='" + MaBan + "'";
            DataProvider.Instance.ExcuteNonQuery(sql);
        }
    }
}
