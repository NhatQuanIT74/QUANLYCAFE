using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DTO
{
    class TONGCHI
    {
        private int maHDNH;
        private string tenNV;
        DateTime ngayBan;
        double tongTien;

        public int MaHDNH { get => maHDNH; set => maHDNH = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public DateTime NgayBan { get => ngayBan; set => ngayBan = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }

        public TONGCHI(int MaHDNH, string TenNV,  DateTime NgayBan, double TongTien)
        {
            this.MaHDNH = MaHDNH;
            this.TenNV = TenNV;
            this.NgayBan = NgayBan;
            this.TongTien = TongTien;
        }
        public TONGCHI(DataRow row)
        {
            this.MaHDNH = (int)row["MaHDNH"];
            this.TenNV = row["TenNV"].ToString();
            this.NgayBan = (DateTime)row["NgayNhap"];
            this.TongTien = Convert.ToDouble(row["TongTien"]);
        }
    }
}
