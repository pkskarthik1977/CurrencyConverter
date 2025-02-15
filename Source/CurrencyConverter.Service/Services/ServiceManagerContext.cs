using CurrencyConverter.Abstracts.Services;

namespace CurrencyConverter.Service.Services
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ServiceManagerContext : IServiceManagerContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frankfurterService"></param>
        public ServiceManagerContext(
            IFrankfurterService frankfurterService
        )
        {
            FrankfurterService = frankfurterService;
        }

        /// <summary>
        /// 
        /// </summary>
        public IFrankfurterService FrankfurterService { get; }
    }
}
