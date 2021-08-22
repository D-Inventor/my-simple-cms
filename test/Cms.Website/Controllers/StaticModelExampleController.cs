using Cms.Pipeline.Mvc;
using Cms.Website.Models;

using Microsoft.AspNetCore.Mvc;

namespace Cms.Website.Controllers
{
    public class StaticModelExampleController : CmsDocumentController<StaticModelExample>
    {
        public IActionResult Index()
        {
            // document models should only be read here, because document models are shared between requests!
            //   if you want to add request specific data, create your own model and return that as model in the view.
            var model = new StaticModelExampleRequestData
            {
                RequestMessage = $"Controller received this message from the document: {Document.Model.Message}"
            };
            return DocumentView(model);
        }
    }
}
