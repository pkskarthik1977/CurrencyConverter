using AutoMapper;
using CurrencyConverter.Abstracts.Services;
using CurrencyConverter.Domain.CQRS;
using CurrencyConverter.Domain.Model;
using Microsoft.Extensions.Caching.Memory;

namespace CurrencyConverter.Domain.QueryHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GetCurrencyRateHistoryQueryHandler
        : EwAsyncRequestHandlerBase<GetCurrencyRateHistoryQuery, HandlerResponse<ExchangeRateHistoryDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="serviceManagerContext"></param>
        /// <param name="memoryCache"></param>
        public GetCurrencyRateHistoryQueryHandler(IMapper mapper, IServiceManagerContext serviceManagerContext, IMemoryCache memoryCache)
            : base(mapper, serviceManagerContext)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<HandlerResponse<ExchangeRateHistoryDto>> Handle(GetCurrencyRateHistoryQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = new ExchangeRateHistoryDto();
            var cacheKey = "ExchangeRateHistory";

            //checks if cache entries exists
            if (!_memoryCache.TryGetValue(cacheKey, out ExchangeRateHistoryDto ExchangeRateHistory))
            {
                //calling the server
                var serviceResponse = await ServiceManagerContext
                    .FrankfurterService
                    .GetCurrencyRateHistoryAsync(
                        request.Context,
                        request.FromDate,
                        request.ToDate,
                        request.CurrencyCode)
                    .ConfigureAwait(false);

                if (serviceResponse.IsSuccessful == false)
                {
                    return new HandlerResponse<ExchangeRateHistoryDto>
                    {
                        Success = serviceResponse.IsSuccessful,
                        Message = serviceResponse.ErrorMessage
                    };
                }
                pagedResult = Mapper.Map<ExchangeRateHistoryDto>(serviceResponse.Data);

                //setting cache entries
                _memoryCache.Set(cacheKey, pagedResult);
            }

            var resultData = _memoryCache.Get<ExchangeRateHistoryDto>(cacheKey);
            return new HandlerResponse<ExchangeRateHistoryDto>
            {
                Success = true,
                Message = string.Empty,
                Result = resultData
            };
        }
    }
}
