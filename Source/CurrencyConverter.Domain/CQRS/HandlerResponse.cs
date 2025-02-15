namespace CurrencyConverter.Domain.CQRS
{
    /// <summary>
    ///
    /// </summary>
    public class HandlerResponse : IHandlerResponse
    {
        /// <summary>
        ///
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Message { get; set; }

    }
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HandlerResponse<T> : HandlerResponse, IHandlerResponse<T>
    {
        /// <summary>
        ///
        /// </summary>
        public T Result { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public interface IHandlerResponse<T> : IHandlerResponse
    {
        /// <summary>
        ///
        /// </summary>
        T Result { get; }
    }

    /// <summary>
    ///
    /// </summary>
    public interface IHandlerResponse
    {
        /// <summary>
        ///
        /// </summary>
        bool Success { get; }

        /// <summary>
        ///
        /// </summary>
        string Message { get; }
    }
}
