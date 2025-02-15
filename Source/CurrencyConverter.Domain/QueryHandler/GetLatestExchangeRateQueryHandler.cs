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
    public sealed class GetLatestExchangeRateQueryHandler
        : EwAsyncRequestHandlerBase<GetLatestExchangeRateQuery, HandlerResponse<ExchangeRateDto>>
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
        public GetLatestExchangeRateQueryHandler(IMapper mapper, IServiceManagerContext serviceManagerContext, IMemoryCache memoryCache)
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
        public override async Task<HandlerResponse<ExchangeRateDto>> Handle(GetLatestExchangeRateQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = new ExchangeRateDto();
            var cacheKey = "ExchangeRate";

            //checks if cache entries exists
            if (!_memoryCache.TryGetValue(cacheKey, out ExchangeRateDto ExchangeRate))
            {
                var serviceResponse = await ServiceManagerContext
                    .FrankfurterService
                    .GetLatestExchangeRateAsync(
                        request.Context, 
                        request.CurrencyCode)
                    .ConfigureAwait(false);

                if (serviceResponse.IsSuccessful == false)
                {
                    return new HandlerResponse<ExchangeRateDto>
                    {
                        Success = serviceResponse.IsSuccessful,
                        Message = serviceResponse.ErrorMessage
                    };
                }

                pagedResult = Mapper.Map<ExchangeRateDto>(serviceResponse.Data);
         
                    //setting cache entries
                _memoryCache.Set(cacheKey, pagedResult);
            }

            var resultData = _memoryCache.Get<ExchangeRateDto>(cacheKey);

            return new HandlerResponse<ExchangeRateDto>
            {
                Success = true,
                Message = string.Empty,
                Result = resultData
            };
        }
    }
}
