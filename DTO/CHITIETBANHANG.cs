using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DTO
{
    public class CHITIETBANHANG
    {

        public CHITIETBANHANG(int maCTBH, int maHDBH, int maSP, int soLuong)
        {
            this.MaCTBH = maCTBH;
            this.MaHDBH = maHDBH;
            this.MaSP = maSP;
            this.SoLuong = soLuong;
        }

        public CHITIETBANHANG(DataRow row)
        {
            this.MaCTBH = (int)row["maCTBH"];
            this.MaHDBH = (int)row["maHDBH"];
            this.MaSP = (int)row["maSP"];
            this.SoLuong = (int)row["soLuong"];
        }

        private int maCTBH;
        private int maHDBH;
        private int maSP;
        private int soLuong;

        public int MaCTBH { get => maCTBH; set => maCTBH = value; }
        public int MaHDBH { get => maHDBH; set => maHDBH = value; }
        public int MaSP { get => maSP; set => maSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
