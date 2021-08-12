using Autofac;

using Cms.Razor.Factories;
using Cms.Razor.Models.Documents;
using Cms.Razor.Providers;
using Cms.Razor.RouteValueTransformers;
using Cms.Razor.Services.DocumentMatching;
using Cms.Core.Factories;
using Cms.Core.Providers.Documents;
using Cms.Core.Services;
using Cms.Core.Services.DocumentMatching;

using Microsoft.Extensions.Caching.Memory;

namespace Cms.Razor.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddCms(this ContainerBuilder container)
        {
            container.RegisterType<DocumentLocator>().As<IDocumentLocator>().InstancePerDependency();
            container.RegisterType<BackofficeDocumentMatcher>().As<IDocumentMatcher>().InstancePerDependency();
            container.RegisterType<BackofficeDocumentFactory>().As<IDocumentFactory<Backoffice>>().InstancePerDependency();
            container.RegisterGeneric(typeof(GenericDocumentProvider<>)).As(typeof(IGenericDocumentProvider<>)).InstancePerDependency();
            container.RegisterType<CmsActionDescriptorProvider>().As<ICmsActionDescriptorProvider>().SingleInstance();
            container.RegisterDecorator<ICmsActionDescriptorProvider>((context, parameters, decoratee) => new DecoratorICmsActionDescriptorProviderCaching(decoratee, context.Resolve<IMemoryCache>()));
            container.RegisterType<CmsRouteValueTransformer>().SingleInstance();
            container.RegisterType<HighTypeServiceBridge>().As<IHighTypeServiceBridge>().InstancePerDependency();
            return container;
        }
    }
}
