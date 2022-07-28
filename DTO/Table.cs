using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE447I_QLCAFE.DTO

{
    public class Table
    {
        int maBan;
        string tenBan;
        string trangThai;

        public int MaBan { get => maBan; set => maBan = value; }
        public string TenBan { get => tenBan; set => tenBan = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }

        public Table(int maBan, string tenBan, string trangThai)
        {
            this.MaBan = maBan;
            this.TenBan = tenBan;
            this.TrangThai = trangThai;
        }

        public Table(DataRow row)
        {
            this.MaBan = (int)row["MaBan"];
            this.TenBan = row["TenBan"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
        }

    }
}
