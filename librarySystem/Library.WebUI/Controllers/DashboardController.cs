using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
