namespace CurrencyConverter.Service.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    internal static class ServiceUri
    {
        // API
        public const string BaseUrlRoot = @"v1";
        public const string BaseUrlLatest = @"v1/latest";

        // Base Urls
        public const string BaseCurrencyBaseUrl = $"{BaseUrlLatest}";
        public const string CurrencyConvertBaseUrl = $"{BaseUrlLatest}";
        public const string HistoryCurrencyBaseUrl = $"{BaseUrlRoot}";
    }
}
