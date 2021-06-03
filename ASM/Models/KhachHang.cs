using System;
using System.Collections.Generic;

namespace ASM.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public string MaKh { get; set; }
        public string TenKh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public ICollection<HoaDon> HoaDon { get; set; }
    }
}
