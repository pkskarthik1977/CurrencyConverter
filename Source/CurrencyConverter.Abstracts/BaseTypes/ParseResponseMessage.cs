// -------------------------------------------------------------------------------------------------
// Copyright (c) Currency Converter , Inc. All rights reserved.
// -------------------------------------------------------------------------------------------------

using Newtonsoft.Json;
using System.Collections.Generic;

namespace CurrencyConverter.Abstracts.BaseTypes
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ParseResponseMessage<T>
    {
        [JsonProperty(PropertyName = "result")]
        public T Data { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListOfResult<T>
    {
        [JsonProperty(PropertyName = "items")]
        public IReadOnlyList<T> Items { get; set; }

        [JsonProperty(PropertyName = "itemCount")]
        public int ItemCount { get; set; }

    }
}
