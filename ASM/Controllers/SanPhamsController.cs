using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASM.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ASM.Controllers
{
    public class SanPhamsController : Controller
    {
        private readonly qlbanhangContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public SanPhamsController(qlbanhangContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            this._appEnvironment = appEnvironment;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var qlbanhangContext = _context.SanPham.Include(s => s.MaLoaiSpNavigation);
            return View(await qlbanhangContext.ToListAsync());
        }

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.MaLoaiSpNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            ViewData["MaLoaiSp"] = new SelectList(_context.LoaiSp, "MaLoaiSp", "MaLoaiSp");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaSp,TenSp,Dongia,MaLoaiSp,HinhSp")] SanPham sanPham, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                var fileName = imageFile.FileName;
                string rootpath = _appEnvironment.WebRootPath;
                string ext = Path.GetExtension(imageFile.FileName);
                sanPham.HinhSp = fileName = sanPham.TenSp + ext;

                string path = Path.Combine(rootpath + "/images/", fileName);

                using (var fs = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(fs);
                }
                _context.Add(sanPham);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiSp"] = new SelectList(_context.LoaiSp, "MaLoaiSp", "MaLoaiSp", sanPham.MaLoaiSp);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["MaLoaiSp"] = new SelectList(_context.LoaiSp, "MaLoaiSp", "MaLoaiSp", sanPham.MaLoaiSp);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSp,TenSp,Dongia,MaLoaiSp,HinhSp")] SanPham sanPham, IFormFile imageFile)
        {
            if (id != sanPham.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fileName = imageFile.FileName;
                    string rootpath = _appEnvironment.WebRootPath;
                    string ext = Path.GetExtension(imageFile.FileName);
                    sanPham.HinhSp = fileName = sanPham.TenSp + ext;

                    string path = Path.Combine(rootpath + "/images/", fileName);

                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(fs);
                    }
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.MaSp))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiSp"] = new SelectList(_context.LoaiSp, "MaLoaiSp", "MaLoaiSp", sanPham.MaLoaiSp);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.MaLoaiSpNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            _context.SanPham.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(string id)
        {
            return _context.SanPham.Any(e => e.MaSp == id);
        }
    }
}
