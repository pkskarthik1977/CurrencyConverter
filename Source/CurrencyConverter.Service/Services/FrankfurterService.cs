// -------------------------------------------------------------------------------------------------
// Copyright (c) Currency Converter, Inc. All rights reserved.
// -------------------------------------------------------------------------------------------------

using CurrencyConverter.Abstracts.BaseTypes;
using CurrencyConverter.Abstracts.Configuration;
using CurrencyConverter.Abstracts.Model.Response;
using CurrencyConverter.Abstracts.Services;
using CurrencyConverter.Service.Utilities;
using Newtonsoft.Json;

namespace CurrencyConverter.Service.Services
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class FrankfurterService : IFrankfurterService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public FrankfurterService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Identifier => nameof(FrankfurterService);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<ExchangeRateResponse>> GetLatestExchangeRateAsync(
            ISessionContext context, string currencyCode)
        {
            //GET Method
            var errorMessage = string.Empty;
            var resultData = new ExchangeRateResponse();
            var url = $"{ServiceUri.BaseCurrencyBaseUrl}?base={currencyCode}";
            var httpClient = _httpClientFactory.CreateClient(@"CurrencyConverter");

            var response = await httpClient.GetAsync(url).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                resultData = JsonConvert.DeserializeObject<ExchangeRateResponse>(jsonString);
            }
            else
            {
                var result = await response.Content
                    .ReadAsAsync<ParseResponseMessage<ExchangeRateResponse>>().ConfigureAwait(false);
                
                if (result == null)
                    return new ServiceResponse<ExchangeRateResponse>(false, response.ReasonPhrase);

                errorMessage = result.Message;
            }

            return (response.IsSuccessStatusCode && string.IsNullOrEmpty(errorMessage))
                ? new ServiceResponse<ExchangeRateResponse>(resultData)
                : new ServiceResponse<ExchangeRateResponse>(false, errorMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="amount"></param>
        /// <param name="fomCurrencyCode"></param>
        /// <param name="toCurrencyCode"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<ExchangeRateResponse>> GetCurrencyConvertionRateAsync(
            ISessionContext context, double amount, string fomCurrencyCode, string toCurrencyCode)
        {
            //GET Method           
            var errorMessage = string.Empty;
            var resultData = new ExchangeRateResponse();

            var url = $"{ServiceUri.CurrencyConvertBaseUrl}?amount={amount}&from={fomCurrencyCode}&to={toCurrencyCode}" ;

            var httpClient = _httpClientFactory.CreateClient(@"CurrencyConverter");
            httpClient.SetupCustomerContext(context);
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                resultData = JsonConvert.DeserializeObject<ExchangeRateResponse>(jsonString);
            }
            else
            {
                var result = await response.Content
                    .ReadAsAsync<ParseResponseMessage<ExchangeRateResponse>>().ConfigureAwait(false);

                if (result == null)
                    return new ServiceResponse<ExchangeRateResponse>(false, response.ReasonPhrase);

                errorMessage = result.Message;
            }

            return (response.IsSuccessStatusCode && string.IsNullOrEmpty(errorMessage))
                ? new ServiceResponse<ExchangeRateResponse>(resultData)
                : new ServiceResponse<ExchangeRateResponse>(false, errorMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<ExchangeRateHistoryResponse>> GetCurrencyRateHistoryAsync(
            ISessionContext context, DateOnly fromDate, DateOnly toDate, string currencyCode)
        {
            var errorMessage = string.Empty;
            var resultData = new ExchangeRateHistoryResponse();
            //GET Method            
            var url = $"{ServiceUri.HistoryCurrencyBaseUrl}/{fromDate:yyyy-MM-dd}..{toDate:yyyy-MM-dd}?symbols={currencyCode}";

            var httpClient = _httpClientFactory.CreateClient(@"CurrencyConverter");
            httpClient.SetupCustomerContext(context);
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                resultData = JsonConvert.DeserializeObject<ExchangeRateHistoryResponse>(jsonString);
            }
            else
            {
                var result = await response.Content
                    .ReadAsAsync<ParseResponseMessage<ExchangeRateHistoryResponse>>().ConfigureAwait(false);

                if (result == null)
                    return new ServiceResponse<ExchangeRateHistoryResponse>(false, response.ReasonPhrase);

                errorMessage = result.Message;
            }

            return (response.IsSuccessStatusCode && string.IsNullOrEmpty(errorMessage))
                ? new ServiceResponse<ExchangeRateHistoryResponse>(resultData)
                : new ServiceResponse<ExchangeRateHistoryResponse>(false, errorMessage);
        }
    }
}
