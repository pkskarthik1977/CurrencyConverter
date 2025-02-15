using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("CurrencyConverter.Tests")]

namespace CurrencyConverter.Domain.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public static class Registration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterDomainTypes(this IServiceCollection services)
        {
            return services;
        }
    }
}