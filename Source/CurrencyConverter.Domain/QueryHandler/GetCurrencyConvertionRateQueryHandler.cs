using AutoMapper;
using CurrencyConverter.Abstracts.Services;
using CurrencyConverter.Domain.CQRS;
using CurrencyConverter.Domain.Model;

namespace CurrencyConverter.Domain.QueryHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GetCurrencyConvertionRateQueryHandler
        : EwAsyncRequestHandlerBase<GetCurrencyConvertionRateQuery, HandlerResponse<ExchangeRateDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="serviceManagerContext"></param>
        /// <param name="memoryCache"></param>
        public GetCurrencyConvertionRateQueryHandler(IMapper mapper, IServiceManagerContext serviceManagerContext)
            : base(mapper, serviceManagerContext)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<HandlerResponse<ExchangeRateDto>> Handle(GetCurrencyConvertionRateQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = new ExchangeRateDto();
            var invalieCurrencyCodeList = new List<string>() { "TRY", "PLN", "THB", "MXN" };

            //checks if cache entries exists
            var serviceResponse = await ServiceManagerContext
                .FrankfurterService
                .GetCurrencyConvertionRateAsync(
                    request.Context,
                    request.Amount,
                    request.FromCurrencyCode,
                    request.ToCurrencyCode)
                .ConfigureAwait(false);

            if (serviceResponse.IsSuccessful == false)
            {
                return new HandlerResponse<ExchangeRateDto>
                {
                    Success = serviceResponse.IsSuccessful,
                    Message = serviceResponse.ErrorMessage
                };
            }

            var invlalidList = invalieCurrencyCodeList.Where(x => serviceResponse.Data.Rates.Keys.Any(d => d.Contains(x))).ToList();

            if (invlalidList.Any())
            {
                return new HandlerResponse<ExchangeRateDto>
                {
                    Success = false,
                    Message = "Invalid currency code listed"
                };
            }

            pagedResult = Mapper.Map<ExchangeRateDto>(serviceResponse.Data);
             
            return new HandlerResponse<ExchangeRateDto>
            {
                Success = true,
                Message = string.Empty,
                Result = pagedResult
            };
        }

       
    }
}
