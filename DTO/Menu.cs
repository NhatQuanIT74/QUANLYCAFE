using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DTO
{
    public class Menu
    {
        private string tenSP;
        private int soLuong;
        private float donGia;
        private float thanhTien;

        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }

        public Menu(string tenSP, int soLuong, float donGia, float thanhTien = 0 )
        {
            this.TenSP = tenSP;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }

        public Menu(DataRow row)
        {
            this.TenSP = row["TenSP"].ToString() ;
            this.SoLuong = (int)row["soLuong"];
            this.DonGia = (float)Convert.ToDouble(row["giaSP"].ToString());
            this.ThanhTien = (float)Convert.ToDouble(row["thanhTien"].ToString());
        }
    }
}
