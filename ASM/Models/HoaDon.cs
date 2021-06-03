using System;
using System.Collections.Generic;

namespace ASM.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            Cthd = new HashSet<Cthd>();
        }

        public string MaHd { get; set; }
        public string MaKh { get; set; }
        public int? MaNv { get; set; }
        public DateTime NgayLapHd { get; set; }

        public KhachHang MaKhNavigation { get; set; }
        public Nhanvien MaNvNavigation { get; set; }
        public ICollection<Cthd> Cthd { get; set; }
    }
}
