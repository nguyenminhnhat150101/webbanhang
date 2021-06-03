using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            Cthd = new HashSet<Cthd>();
        }

        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public double? Dongia { get; set; }
        public int? MaLoaiSp { get; set; }
        public string HinhSp { get; set; }
        [NotMapped]
        [DisplayName("Tải Hình Lên")]
        public IFormFile imageFile { get; set; }
        public LoaiSp MaLoaiSpNavigation { get; set; }
        public ICollection<Cthd> Cthd { get; set; }
    }
}
