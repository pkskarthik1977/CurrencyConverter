// -------------------------------------------------------------------------------------------------
// Copyright (c) Currency Converter , Inc. All rights reserved.
// -------------------------------------------------------------------------------------------------

namespace CurrencyConverter.Abstracts.BaseTypes
{
    public class ServiceResponse
    {
        public ServiceResponse() : this(true, null)
        {

        }
        public ServiceResponse(string errorMessage) : this(false, errorMessage)
        {

        }
        public ServiceResponse(bool isSuccessful, string errorMessage)
        {
            IsSuccessful = isSuccessful;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public ServiceResponse(bool isSuccessful, string errorMessage) : base(isSuccessful, errorMessage)
        {

        }

        public ServiceResponse(T data) : base(true, null)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
