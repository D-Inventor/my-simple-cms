using Cms.Razor.Controllers;

using Microsoft.AspNetCore.Mvc;

using System;

namespace Cms.Website.Controllers
{
    public class UriController
        : CmsControllerBase<Uri>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
