using CurrencyConverter.Abstracts.BaseTypes;
using CurrencyConverter.Domain.Model;
using CurrencyConverter.Domain.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Filters;

namespace CurrencyConverter.Controllers
{
    [ApiVersion("1.0")]
    public class CurrencyConverterController : ApiControllerBase<CurrencyConverterController>
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        public CurrencyConverterController(ILogger<CurrencyConverterController> logger, IMediator mediator)
           : base(logger, mediator)
        {   
        }

        /// <summary>
        /// Gets the Exchange Rate for the currency
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetExchangeRate))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ExchangeRateDto))]
        [ProducesResponseType(typeof(EwResponse<ItemsContainer<ExchangeRateDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(EwError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EwError), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetExchangeRate(string currencyCode)
        {
            var query = new GetLatestExchangeRateQuery(currencyCode)
            {
                Context = AppContext
            };

            var response = await Mediator
                .Send(query)
                .ConfigureAwait(false);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        /// <summary>
        /// Gets the Exchange Rate for the currency
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetConvertionRate))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ExchangeRateDto))]
        [ProducesResponseType(typeof(EwResponse<ItemsContainer<ExchangeRateDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(EwError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EwError), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetConvertionRate(
            [FromQuery] double amount, 
            [FromQuery] string fromCurrencyCode,
            [FromQuery] string toCurrencyCode)
        {
            var query = new GetCurrencyConvertionRateQuery(
                amount, fromCurrencyCode, toCurrencyCode )
            {
                Context = AppContext
            };

            var response = await Mediator
                .Send(query)
                .ConfigureAwait(false);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        /// <summary>
        /// Gets the Exchange Rate for the currency
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetConvertionHistory))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ExchangeRateHistoryDto))]
        [ProducesResponseType(typeof(EwResponse<ItemsContainer<ExchangeRateHistoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(EwError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EwError), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetConvertionHistory(
            [FromQuery] DateOnly fromDate,
            [FromQuery] DateOnly toDate,
            [FromQuery] string currencyCode,
            [FromQuery] int startIndex = 0,
            [FromQuery] int lastIndex = 999999)
        {
            //calling the server
            var query = new GetCurrencyRateHistoryQuery(
                fromDate, toDate, currencyCode, startIndex, lastIndex)
            {
                Context = AppContext
            };

            var response = await Mediator
                .Send(query)
                .ConfigureAwait(false);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }
    }
}
