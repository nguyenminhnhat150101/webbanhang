using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class SanPhamModel
    {
        private DataContext db = new DataContext();
        public List<SanPham> FindAll()
        {

            var a = db.SanPham.ToList();
            return a;

        }

        public SanPham Find(string MaSP)
        {
            var a = db.SanPham.Find(MaSP);
            return a;
        }
    }
}
