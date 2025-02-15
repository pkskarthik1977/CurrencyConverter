// -------------------------------------------------------------------------------------------------
// Copyright (c) Currency Converter , Inc. All rights reserved.
// -------------------------------------------------------------------------------------------------

namespace CurrencyConverter.Abstracts.BaseTypes
{
    public sealed class EwError
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Client { get; set; }
        public string CorrelationId { get; set; }
    }
}
