using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DTO
{
    public class HOADONBANHANG
    {
                
        private int maHDBH;
        private string maNV;
        private int maKH;
        private int maBan;
        private DateTime? ngayBan;
        private int giamGia;
        private float tongTien;
        private int status;

        public int MaHDBH { get => maHDBH; set => maHDBH = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public int MaBan { get => maBan; set => maBan = value; }
        public DateTime? NgayBan { get => ngayBan; set => ngayBan = value; }
        public int GiamGia { get => giamGia; set => giamGia = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public int Status { get => status; set => status = value; }

        public HOADONBANHANG(int maHDBH, string maNV, int maKH, int maBan, DateTime? ngayBan, int giamGia, float tongTien, int status)
        {
            this.MaHDBH = maHDBH;
            this.MaNV = maNV;
            this.MaKH = maKH;
            this.MaBan = maBan;
            this.NgayBan = ngayBan;
            this.GiamGia = giamGia;
            this.TongTien = tongTien;
            this.Status = status;
        }

        public HOADONBANHANG(DataRow row)
        {
            this.MaHDBH = (int)row["maHDBH"];
            this.MaNV = row["maNV"].ToString();

            var maKHTemp = row["maKH"];
            if(maKHTemp.ToString() != "")
            {
                this.MaKH = (int)maKHTemp;
            }

            this.MaBan = (int)row["Ban"];

            var ngayBanTemp = row["ngayBan"];
            if (ngayBanTemp.ToString() != "")
            {
                this.NgayBan = (DateTime?)ngayBanTemp;
            }

            var giamGiaTemp = row["giamGia"];
            if (giamGiaTemp.ToString() != "")
            {
                this.GiamGia = (int)giamGiaTemp;
            }

            var tongTienTemp = row["tongTien"];
            if (tongTienTemp.ToString() != "")
            {
                this.TongTien = (float)tongTienTemp;
            }

            this.Status = (int)row["status"];
        }



    }
}
