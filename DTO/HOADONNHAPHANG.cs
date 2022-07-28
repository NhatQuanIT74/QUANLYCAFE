using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DTO
{
    class HOADONNHAPHANG
    {
        private int maHDNH;
        private string maNV;
        private DateTime? ngayNhap;
        private float tongTien;
        private int status;

        public int MaHDNH { get => maHDNH; set => maHDNH = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime? NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public int Status { get => status; set => status = value; }

        public HOADONNHAPHANG(int maHDNH, string maNV, DateTime? ngayNhap, float tongTien, int status)
        {
            this.MaHDNH = maHDNH;
            this.MaNV = maNV;
            this.NgayNhap = ngayNhap;
            this.TongTien = tongTien;
            this.Status = status;
        }

        public HOADONNHAPHANG(DataRow row)
        {
            this.MaHDNH = (int)row["MaHDNH"];

            this.MaNV = row["maNV"].ToString();

            var ngayNhapTemp = row["NgayNhap"];
            if (ngayNhapTemp.ToString() != "")
            {
                this.NgayNhap = (DateTime?)ngayNhapTemp;
            }

            var tongTienTemp = row["TongTien"];
            if (tongTienTemp.ToString() != "")
            {
                this.TongTien = (float)tongTienTemp;
            }

            this.Status = (int)row["status"];
        }

    }
}
