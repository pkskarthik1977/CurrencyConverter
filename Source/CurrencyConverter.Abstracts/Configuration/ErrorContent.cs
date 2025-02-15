using System;
using System.Xml.Serialization;

namespace CurrencyConverter.Abstracts.Configuration
{
    /// <summary>
    /// Error Content
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "Error")]
    public class ErrorContent
    {
        /// <summary>
        /// Code
        /// </summary>
        [XmlElement]
        public string Code { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [XmlElement]
        public string Message { get; set; }

        /// <summary>
        /// Activity Id (Correlation Id)
        /// </summary>
        [XmlElement]
        public string ActivityId { get; set; }

        /// <summary>
        /// UTC Timestamp
        /// </summary>
        [XmlElement]
        public string Timestamp { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TContent"></typeparam>
    [Serializable]
    [XmlRoot(ElementName = "Error")]
    public sealed class ErrorContent<TContent> : ErrorContent
    {
        /// <summary>
        ///
        /// </summary>
        [XmlElement]
        public TContent Data { get; set; }
    }
}
