using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhanVien.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
