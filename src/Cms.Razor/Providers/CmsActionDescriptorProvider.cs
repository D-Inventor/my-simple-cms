using Cms.Razor.Controllers;
using Cms.Core.Models;

using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using System.Linq;

namespace Cms.Razor.Providers
{
    internal class CmsActionDescriptorProvider
        : ICmsActionDescriptorProvider
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public CmsActionDescriptorProvider(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public ActionDescriptor GetActionDescriptor(IDocumentInfo document)
        {
            var type = document.DocumentType;
            foreach (var action in _actionDescriptorCollectionProvider.ActionDescriptors.Items)
            {
                if (action is not ControllerActionDescriptor controllerAction) continue;

                var controllerDocument = (from @interface in controllerAction.ControllerTypeInfo.ImplementedInterfaces
                                          where @interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(ICmsControllerBase<>)
                                          select @interface.GetGenericArguments().First()).FirstOrDefault();

                if (controllerDocument is null || controllerDocument != type) continue;

                return action;
            }

            return null;
        }
    }
}
