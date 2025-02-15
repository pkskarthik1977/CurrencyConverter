using System.Collections.Immutable;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;

namespace CurrencyConverter.Service.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class QueryStringConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramInstance"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1054:URI-like parameters should not be strings", Justification = "Intended Use - AS IS")]
        public static string FormatUrl<T>(T paramInstance = null, string url = null) where T : class
        {
            if (null == paramInstance && string.IsNullOrWhiteSpace(url))
                return @"/";

            var dictionary = (null == paramInstance)
                ? (new Dictionary<string, string>(0)).ToImmutableDictionary()
                : JObject
                    .FromObject(paramInstance)
                    .ToObject<Dictionary<string, object>>()
                    ?.Where(o => !string.IsNullOrWhiteSpace(o.Value?.ToString()))
                    .ToImmutableDictionary(de => de.Key,
                        de => (null == de.Value) ? string.Empty : de.Value?.ToString());

            var result = QueryHelpers.AddQueryString(string.IsNullOrWhiteSpace(url) ? @"/" : url, dictionary);

            return result;
        }

       
    }
}
