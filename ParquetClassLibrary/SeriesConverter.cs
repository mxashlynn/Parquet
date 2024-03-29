using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet
{
    /// <summary>
    /// Type converter for any collection that implements <see cref="ICollection{T}"/>.
    /// </summary>
    /// <typeparam name="TElement">The type collected.</typeparam>
    /// <typeparam name="TCollection">The type of the collection.</typeparam>
    public class SeriesConverter<TElement, TCollection> : CollectionGenericConverter
        where TCollection : ICollection<TElement>, new()
        where TElement : ITypeConverter, new()
    {
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static SeriesConverter<TElement, TCollection> ConverterFactory { get; } =
            new SeriesConverter<TElement, TCollection>();

        /// <summary>Allows the converter to construct its contents.</summary>
        internal static readonly TElement ElementFactory = new();

        /// <summary>
        /// Converts the given 1D collection into a record column.
        /// </summary>
        /// <param name="collection">The collection to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given collection serialized.</returns>
        public override string ConvertToString(object collection, IWriterRow row, MemberMapData memberMapData)
        {
            Precondition.IsNotNull(collection, nameof(collection));
            if (collection is not TCollection series)
            {
                return Logger.DefaultWithConvertLog(collection?.ToString() ?? "null", nameof(TCollection), "");
            }

            if (series.Count < 1
                || (series.Count == 1
                    && series.Contains(ElementFactory)))
            {
                return "";
            }

            var result = new StringBuilder();
            foreach (var element in series)
            {
                result.Append(element.ConvertToString(element, row, memberMapData));
                result.Append(Delimiters.SecondaryDelimiter[0]);
            }
            result.Remove(result.Length - Delimiters.SecondaryDelimiter.Length, Delimiters.SecondaryDelimiter.Length);

            return result.ToString();
        }

        /// <summary>
        /// Converts the given record column to a 1D collection.
        /// </summary>
        /// <param name="text">The record column to convert to an object.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="ICollection{TElement}"/> created from the record column.</returns>
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            => ConvertFromString(text, row, memberMapData, Delimiters.SecondaryDelimiter);

        /// <summary>
        /// Converts the given record column to a 1D collection.
        /// </summary>
        /// <param name="text">The record column to convert to an object.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <param name="delimiter">The string used to separate elements in the series.</param>
        /// <returns>The <see cref="ICollection{TElement}"/> created from the record column.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData, string delimiter)
        {
            var collection = new TCollection();
            if (string.IsNullOrEmpty(text)
                || string.Equals(nameof(ModelID.None), text, StringComparison.OrdinalIgnoreCase)
                || string.Equals(nameof(Enumerable.Empty), text, StringComparison.OrdinalIgnoreCase))
            {
                return collection;
            }

            var textCollection = text.Split(delimiter);
            foreach (var currentText in textCollection)
            {
                collection.Add((TElement)ElementFactory.ConvertFromString(currentText, row, memberMapData));
            }
            return collection;
        }
    }
}
