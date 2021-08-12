using Cms.Razor.Controllers;
using Cms.Razor.Models.Documents;

using Microsoft.AspNetCore.Mvc;

namespace Cms.Razor.Areas.Cms.Controllers
{
    [Area("Cms")]
    public class BackofficeController
        : CmsControllerBase<Backoffice>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
