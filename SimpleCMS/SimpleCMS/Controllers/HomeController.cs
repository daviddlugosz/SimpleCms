using Microsoft.AspNetCore.Mvc;

namespace SimpleCms.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}