namespace CurrencyConverter.Abstracts.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISessionContextAware
    {
        /// <summary>
        /// 
        /// </summary>
        ISessionContext Context { get; set; }
    }
}
