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
    public abstract class EwAsyncRequestHandlerBase<TRequest> : RequestHandlerWrapperImpl<TRequest>
        where TRequest : IRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>        
        /// <param name="serviceManagerContext"></param>
        protected EwAsyncRequestHandlerBase(IMapper mapper, IServiceManagerContext serviceManagerContext)
        {
            Mapper = mapper;
            ServiceManagerContext = serviceManagerContext;
        }

        protected IMapper Mapper { get; }
        protected IServiceManagerContext ServiceManagerContext { get; }
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class EwAsyncRequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>        
        /// <param name="serviceManagerContext"></param>
        protected EwAsyncRequestHandlerBase(IMapper mapper, IServiceManagerContext serviceManagerContext)
        {
            Mapper = mapper;
            ServiceManagerContext = serviceManagerContext;
        }

        protected IMapper Mapper { get; }
        protected IServiceManagerContext ServiceManagerContext { get; }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
