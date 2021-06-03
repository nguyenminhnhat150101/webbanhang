using System;
using System.Collections.Generic;

namespace ASM.Models
{
    public partial class Cthd
    {
        public string MaHd { get; set; }
        public string MaSp { get; set; }
        public short? Soluong { get; set; }
        public float? DongiaBan { get; set; }

        public HoaDon MaHdNavigation { get; set; }
        public SanPham MaSpNavigation { get; set; }
    }
}
