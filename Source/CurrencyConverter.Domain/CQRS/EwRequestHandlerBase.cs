using AutoMapper;
using CurrencyConverter.Abstracts.Services;
using MediatR;
using MediatR.Wrappers;

namespace CurrencyConverter.Domain.CQRS
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public abstract class EwRequestHandlerBase<TRequest> : RequestHandlerWrapperImpl<TRequest>
        where TRequest : IRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="ewDataManagerContext"></param>
        protected EwRequestHandlerBase(IMapper mapper, IServiceManagerContext ewDataManagerContext)
        {
            Mapper = mapper;
            EwDataManager = ewDataManagerContext;
        }

        protected IMapper Mapper { get; }

        protected IServiceManagerContext EwDataManager { get; }
    }
}
