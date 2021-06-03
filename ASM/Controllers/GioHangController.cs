using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Models;
using Microsoft.AspNetCore.Mvc;
using ASM.Models;

namespace ASM.Controllers
{
    public class GioHangController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
