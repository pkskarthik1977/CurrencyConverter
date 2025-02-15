using CurrencyConverter.Abstracts.BaseTypes;
using CurrencyConverter.Abstracts.Configuration;
using CurrencyConverter.Abstracts.Model.Response;

namespace CurrencyConverter.Abstracts.Services
{
    /// <summary>
    ///
    /// </summary>
    public interface IFrankfurterService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        Task<ServiceResponse<ExchangeRateResponse>> GetLatestExchangeRateAsync(
            ISessionContext context, string currencyCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="amount"></param>
        /// <param name="fomCurrencyCode"></param>
        /// <param name="toCurrencyCode"></param>
        /// <returns></returns>
        Task<ServiceResponse<ExchangeRateResponse>> GetCurrencyConvertionRateAsync(
            ISessionContext context, double amount, string fomCurrencyCode, string toCurrencyCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        Task<ServiceResponse<ExchangeRateHistoryResponse>> GetCurrencyRateHistoryAsync(
            ISessionContext context, DateOnly fromDate, DateOnly toDate, string currencyCode);
    }
}
