using CurrencyConverter.Abstracts.Configuration;
using MediatR;
using Newtonsoft.Json;

namespace CurrencyConverter.Domain.CQRS
{
    /// <summary>
    /// Class EwRequest.
    /// </summary>
    public abstract class CommandQueryRequest : ICommandQueryRequest
    {
        /// <summary>
        /// This is set by MediatR Request Pre Processor
        /// </summary>
        [JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ISessionContext Context { get; set; }
    }

    /// <summary>
    /// Class CommandQueryRequest.
    /// </summary>
    public abstract class CommandQueryRequest<TResult> : ICommandQueryRequest<TResult>
    {
        /// <summary>
        /// This is set by MediatR Request Pre Processor
        /// </summary>
        [JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ISessionContext Context { get; set; }
    }

    /// <summary>
    /// Marker interface to represent a request with a void response
    /// Implements the <see cref="MediatR.IRequest" />
    /// </summary>
    public interface ICommandQueryRequest : IRequest, ISessionContextAware
    {
    }

    /// <summary>
    /// Marker interface to represent a request with a response
    /// Interface ICommandQueryRequest
    /// </summary>
    public interface ICommandQueryRequest<out TResponse> : IRequest<TResponse>, ISessionContextAware { }
}
