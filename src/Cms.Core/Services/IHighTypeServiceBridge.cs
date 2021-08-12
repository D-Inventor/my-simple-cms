using System;

namespace Cms.Core.Services
{
    /// <summary>
    /// Classes that implement this interface can bridge between the low-type and high-type side of the framework by providing a means to obtain a high-type service as a low-type equivalent.
    /// </summary>
    public interface IHighTypeServiceBridge
    {
        /// <summary>
        /// When implemented by a class, this method returns the service of type <paramref name="openGeneric"/> with given <paramref name="typeArguments"/> casted to <typeparamref name="TLowTypeServiceEquivalent"/>
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when <paramref name="openGeneric"/> does not implement or inherit <typeparamref name="TLowTypeServiceEquivalent"/></exception>
        /// <typeparam name="TLowTypeServiceEquivalent">The low-type equivalent of a service of type <paramref name="openGeneric"/></typeparam>
        /// <param name="openGeneric">The service type that is requested as an open generic</param>
        /// <param name="typeArguments">The type parameters that apply to the given </param>
        /// <returns>The requested service</returns>
        TLowTypeServiceEquivalent GetHighlyTypedService<TLowTypeServiceEquivalent>(Type openGeneric, params Type[] typeArguments) where TLowTypeServiceEquivalent : class;
    }
}