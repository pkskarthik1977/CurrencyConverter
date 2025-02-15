// -------------------------------------------------------------------------------------------------
// Copyright (c) Currency Converter , Inc. All rights reserved.
// -------------------------------------------------------------------------------------------------

namespace CurrencyConverter.Abstracts.BaseTypes
{
    public sealed class EwMessage
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public EwMessageCategory Category { get; set; }
    }

    public enum EwMessageCategory
    {
        Error,
        Warning,
        Information
    }
}
