using System;
using System.Collections.Generic;

namespace ASM.Models
{
    public partial class LoaiSp
    {
        public LoaiSp()
        {
            SanPham = new HashSet<SanPham>();
        }

        public int MaLoaiSp { get; set; }
        public string TenLoaiSp { get; set; }

        public ICollection<SanPham> SanPham { get; set; }
    }
}
