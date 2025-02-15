// -------------------------------------------------------------------------------------------------
// Copyright (c) Currency Converter , Inc. All rights reserved.
// -------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CurrencyConverter.Abstracts.BaseTypes
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    [DataContract]
    public class ItemsContainer<TData> : IItemsContainer
    {
        [XmlArray]
        [DataMember(EmitDefaultValue = false)]
        public List<TData> Items { get; set; } = new List<TData>();

        [XmlElement]
        [DataMember(EmitDefaultValue = false)]
        public int Count { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        IEnumerable IItemsContainer.Items => Items;
    }

    /// <summary>
    ///
    /// </summary>
    public interface IItemsContainer
    {
        int Count { get; set; }

        IEnumerable Items { get; }
    }
}
