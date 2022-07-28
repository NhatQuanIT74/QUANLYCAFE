using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DTO
{
    class SanPhamBanRa
    {
        private string tenSP;
        private int soLuong;

        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public SanPhamBanRa(string tenSP, int soLuong)
        {
            this.TenSP = tenSP;
            this.SoLuong = soLuong;
        }

        public SanPhamBanRa(DataRow row)
        {
            this.TenSP = row["TenSP"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            
        }
    }
}
