using CurrencyConverter.Domain.CQRS;
using CurrencyConverter.Domain.Model;

namespace CurrencyConverter.Domain.QueryHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GetCurrencyConvertionRateQuery : EwRequest<HandlerResponse<ExchangeRateDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        public GetCurrencyConvertionRateQuery(double amount, string fromCurrencyCode, string toCurrencyCode)
        {
            Amount = amount;
            FromCurrencyCode = fromCurrencyCode;
            ToCurrencyCode = toCurrencyCode;
        }

        /// <summary>
        /// 
        /// </summary>
        public double Amount { get; }

        /// <summary>
        /// 
        /// </summary>
        public string FromCurrencyCode { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ToCurrencyCode { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class GetCurrencyRateHistoryQuery : EwRequest<HandlerResponse<ExchangeRateHistoryDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        public GetCurrencyRateHistoryQuery(DateOnly fromDate, DateOnly toDate, string currencyCode, int startIndex = 0, int lastIndex = 999999)
        {
            FromDate = fromDate;
            ToDate = toDate;
            CurrencyCode = currencyCode;
            StartIndex = startIndex;
            Lastindex = lastIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateOnly FromDate { get; }

        /// <summary>
        /// 
        /// </summary>
        public DateOnly ToDate { get; }

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; }

        /// <summary>
        /// 
        /// </summary>
        public int StartIndex { get; }

        /// <summary>
        /// 
        /// </summary>
        public int Lastindex { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class GetLatestExchangeRateQuery : EwRequest<HandlerResponse<ExchangeRateDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        public GetLatestExchangeRateQuery(string currencyCode)
        {
            CurrencyCode = currencyCode;
        }

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; }
    }
}
