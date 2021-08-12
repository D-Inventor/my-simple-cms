
using Microsoft.AspNetCore.Mvc;

namespace Cms.Website.Controllers
{
    [Route("home")]
    public class HomeController
        : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
