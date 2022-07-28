using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DTO
{
    class LuongNhanVien
    {        
        private string tenCaLam;
        private DateTime ngayLam;
        private double tienLuong;

        public string TenCaLam { get => tenCaLam; set => tenCaLam = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
        public double TienLuong { get => tienLuong; set => tienLuong = value; }
        

        public LuongNhanVien(string tenCaLam, DateTime ngayLam, double tienLuong)
        {            
            this.TenCaLam = tenCaLam;
            this.NgayLam = ngayLam;
            this.TienLuong = tienLuong;
        }

        public LuongNhanVien(DataRow row)
        {
            this.TenCaLam = row["TenCLV"].ToString();
            this.NgayLam =Convert.ToDateTime(row["NgayLuong"]);
            this.TienLuong = Convert.ToDouble(row["TienLuong"]);
        }

        
    }
}
