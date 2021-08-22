using Microsoft.AspNetCore.Mvc;

namespace Cms.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
