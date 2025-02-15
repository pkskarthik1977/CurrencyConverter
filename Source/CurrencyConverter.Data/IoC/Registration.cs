using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("CurrencyConverter.Tests")]

namespace CurrencyConverter.Data.IoC
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
        public static IServiceCollection RegisterDataTypes(this IServiceCollection services)
        {
            return services;
        }
    }
}