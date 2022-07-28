using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DTO
{
    class DoanhThu
    {
        //MaHDBH, TenNV, TenBan, NgayBan, GiamGia;
        private int maHDBH;
        private string tenNV;
        private string tenBan;
        DateTime ngayBan;
        int giamGia;
        double tongTien;

        public int MaHDBH { get => maHDBH; set => maHDBH = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string TenBan { get => tenBan; set => tenBan = value; }
        public DateTime NgayBan { get => ngayBan; set => ngayBan = value; }
        public int GiamGia { get => giamGia; set => giamGia = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }

        public DoanhThu(int MaHDBH, string TenNV, string TenBan, DateTime NgayBan, int GiamGia, double TongTien)
        {
            this.MaHDBH = MaHDBH;
            this.TenNV = TenNV;
            this.TenBan = TenBan;
            this.NgayBan = NgayBan;
            this.GiamGia = GiamGia;
            this.TongTien = TongTien;
        }

        public DoanhThu(DataRow row)
        {
            this.MaHDBH = (int)row["MaHDBH"];
            this.TenNV = row["TenNV"].ToString();
            this.TenBan = row["TenBan"].ToString();
            this.NgayBan = (DateTime)row["NgayBan"];
            this.GiamGia = (int)row["GiamGia"];
            this.TongTien = Convert.ToDouble(row["TongTien"]);
        }
    }
}
