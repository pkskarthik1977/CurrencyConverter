using CurrencyConverter.Abstracts.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CurrencyConverter.Controllers
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TController"></typeparam>
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class ApiControllerBase<TController> : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        protected ApiControllerBase(ILogger<TController> logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        /// <summary>
        ///
        /// </summary>
        protected ILogger<TController> Logger { get; }

        /// <summary>
        ///
        /// </summary>
        protected IMediator Mediator { get; }

        /// <summary>
        /// 
        /// </summary>
        protected ISessionContext AppContext => null;
    }
}
