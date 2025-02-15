using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Api.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public static class Registration
    {
        public const string DocumentTitle = @"Currency Converter APIs";

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TStartupType"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServiceApis<TStartupType>(this IServiceCollection services)
        {           

            return services;
        }
    }
}