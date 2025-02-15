using System.Runtime.CompilerServices;
using CurrencyConverter.Abstracts.Services;
using CurrencyConverter.Service.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("CurrencyConverter.Service.Tests")]

namespace CurrencyConverter.Service.Utilities;

public static class DependencyInjection
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddEveryWareDomain(this IServiceCollection services)
    {
        services.AddSingleton<IServiceManagerContext, ServiceManagerContext>();
        services.AddSingleton<IFrankfurterService, FrankfurterService>();

        return services;
    }
}
