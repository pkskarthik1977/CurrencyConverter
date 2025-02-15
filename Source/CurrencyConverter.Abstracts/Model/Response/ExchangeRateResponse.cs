using Newtonsoft.Json;

namespace CurrencyConverter.Abstracts.Model.Response
{
    public class ExchangeRateResponse
    {   
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "base")]
        public string Currency { get; set; }
        
        [JsonProperty(PropertyName = "date")]
        public DateTime ReferenceDate { get; set; }
        
        [JsonProperty(PropertyName = "start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "rates")]
        public Dictionary<string, double> Rates { get; set; }
    }
}
