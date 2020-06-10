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