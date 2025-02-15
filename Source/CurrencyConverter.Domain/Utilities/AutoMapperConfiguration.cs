using AutoMapper;
using CurrencyConverter.Abstracts.Model.Response;
using CurrencyConverter.Domain.Model;

namespace CurrencyConverter.Domain.Utilities
{
    /// <summary>
    ///
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        ///
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<ExchangeRateDto, ExchangeRateResponse>().ReverseMap();
            CreateMap<ExchangeRateHistoryDto, ExchangeRateHistoryResponse>().ReverseMap();
        }
    }
}
