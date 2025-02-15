using CurrencyConverter.Abstracts.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace CurrencyConverter.Domain.CQRS
{
    /// <summary>
    ///
    /// </summary>
    public abstract class EwRequest : IEwRequest
    {
        /// <summary>
        /// This is set by MediatR Request Pre Processor
        /// </summary>
        [JsonIgnore]
        [BindNever]
        [System.Text.Json.Serialization.JsonIgnore]
        public ISessionContext Context { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class EwRequest<TResult> : IEwRequest<TResult>
    {
        /// <summary>
        /// This is set by MediatR Request Pre Processor
        /// </summary>
        [JsonIgnore]
        [BindNever]
        [System.Text.Json.Serialization.JsonIgnore]
        public ISessionContext Context { get; set; }
    }

    /// <summary>
    /// Marker interface to represent a request with a void response
    /// </summary>
    public interface IEwRequest : IRequest, ISessionContextAware
    {
    }

    /// <summary>
    /// Marker interface to represent a request with a response
    /// </summary>
    /// <typeparam name="TResponse">Response type</typeparam>
    public interface IEwRequest<out TResponse> : IRequest<TResponse>, ISessionContextAware { }
}
