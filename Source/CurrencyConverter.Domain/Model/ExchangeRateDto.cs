namespace CurrencyConverter.Domain.Model
{
    public class ExchangeRateDto
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
        public Dictionary<string, double> Rates { get; set; }
    }
}
