using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DAL
{
    class DataProvider
    {
        private static DataProvider instance;

        private string chuoikn = @"Server=DESKTOP-4IC9IJV;Database=QLCAFE;Trusted_Connection=True;";
        
        public DataProvider()
        {
        }

        internal static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        public DataTable ExecuteQuery(string sql, object[] parameter = null)
        {
            //SqlConnection conn = new SqlConnection(chuoikn);
            //DataTable data = new DataTable();
            //SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            //adapter.Fill(data);
            //return data;

            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                if (parameter != null)
                {
                    string[] listpara = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            comm.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }

        public int ExcuteNonQuery(string sql, object[] parameter = null)
        {
            int kq;
            using(SqlConnection conn = new SqlConnection(chuoikn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                if (parameter != null)
                {
                    string[] listpara = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            comm.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                kq = comm.ExecuteNonQuery();
                conn.Close();

            }
            return kq;
        }

        public object ExcuteScalar(string sql, object[] parameter = null)
        {

            object kq;
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                if (parameter != null)
                {
                    string[] listpara = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            comm.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                kq = comm.ExecuteScalar();
                conn.Close();

            }
            return kq;
        }

    }
}
