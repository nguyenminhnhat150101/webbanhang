using System;
using System.Collections.Generic;

namespace ASM.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public int MaNv { get; set; }
        public string HoTenNv { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }

        public ICollection<HoaDon> HoaDon { get; set; }
    }
}
