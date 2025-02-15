using MediatR.Pipeline;

namespace CurrencyConverter.Domain.Utilities
{
    /// <summary>
    /// Class CommonRequestPreProcessor.
    /// Implements the <see cref="MediatR.Pipeline.IRequestPreProcessor{TRequest}" />
    /// </summary>
    /// <typeparam name="TRequest">The type of the t request.</typeparam>
    /// <seealso cref="MediatR.Pipeline.IRequestPreProcessor{TRequest}" />
    public abstract class RequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        /// <summary>
        /// Process method executes before calling the Handle method on your handler
        /// </summary>
        /// <param name="request">Incoming request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>An awaitable task</returns>
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            await OnUpdateRequestAsync(request);
        }

        /// <summary>
        /// Called when [format request].
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task.</returns>
        protected abstract Task OnUpdateRequestAsync(TRequest request);
    }
}
