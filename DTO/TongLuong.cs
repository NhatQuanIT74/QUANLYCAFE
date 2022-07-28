using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DTO
{
    class TongLuong
    {
        private string tenNV;
        private double tienLuong;

        public string TenNV { get => tenNV; set => tenNV = value; }
        public double TienLuong { get => tienLuong; set => tienLuong = value; }

        public TongLuong(string TenNV, double TienLuong)
        {
            this.TenNV = TenNV;
            this.TienLuong = TienLuong;
        }

        public TongLuong(DataRow row)
        {
            this.TenNV = row["TenNV"].ToString();
            this.TienLuong = Convert.ToDouble(row["TienLuong"]);
        }        
    }
}
