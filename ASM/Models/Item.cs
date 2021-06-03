using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    [Serializable]
    public class Item
    {
        public string MaSP { get; set; }
        public int TenSP { get; set; }
        public double Dongia  { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { get { return SoLuong * Dongia; } }

    }
}
