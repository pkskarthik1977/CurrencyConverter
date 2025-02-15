namespace CurrencyConverter.Domain.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ExchangeRateHistoryDto
    {   
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ReferenceDate { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDate { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, Dictionary<string, double>> Rates { get; set; }
    }
}
