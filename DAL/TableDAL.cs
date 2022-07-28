using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    public class TableDAL
    {
        private static TableDAL instance;
        
        public static TableDAL Instance
        {
            get { if (instance == null) instance = new TableDAL(); return TableDAL.instance; }
            private set { TableDAL.instance = value; }
        }

        public static int TableWidth = 85;
        public static int TableHeight = 80;

        private TableDAL() { }

        public List<DTO.Table> LoadTableList()
        {
            List<DTO.Table> tablelist = new List<DTO.Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from BAN");
            foreach(DataRow item in data.Rows)
            {
                DTO.Table table = new DTO.Table(item);
                tablelist.Add(table);
            }
            return tablelist;
        }

        public DataTable LoadTable()
        {
            string sql = "select * from BAN";
            return DataProvider.Instance.ExecuteQuery(sql);
        }

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("SwitchTable @idTable1 , @idTable2", new object[] {id1,id2});
        }
    }
}
