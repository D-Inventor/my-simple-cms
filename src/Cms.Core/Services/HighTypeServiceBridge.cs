using System;

namespace Cms.Core.Services
{
    /// <summary>
    /// Default implementation of the <see cref="IHighTypeServiceBridge" />
    /// </summary>
    public class HighTypeServiceBridge
        : IHighTypeServiceBridge
    {
        private readonly IServiceProvider _serviceProvider;

        public HighTypeServiceBridge(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public TLowTypeServiceEquivalent GetHighlyTypedService<TLowTypeServiceEquivalent>(Type openGeneric, params Type[] typeArguments)
            where TLowTypeServiceEquivalent : class
        {
            if (!typeof(TLowTypeServiceEquivalent).IsAssignableFrom(openGeneric)) throw new ArgumentException($"Given type does not implement or inherit from {typeof(TLowTypeServiceEquivalent)}", nameof(openGeneric));

            var serviceType = openGeneric.MakeGenericType(typeArguments);
            return _serviceProvider.GetService(serviceType) as TLowTypeServiceEquivalent;
        }
    }
}
