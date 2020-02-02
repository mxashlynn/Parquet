using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ParquetClassLibrary.Serialization
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
        internal static readonly SeriesConverter<TElement, TCollection> ConverterFactory =
            new SeriesConverter<TElement, TCollection>();

        /// <summary>
        /// Converts the given record column to a 2D collection.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="ICollection{TElement}"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            var collection = new TCollection();
            if (string.IsNullOrEmpty(inText))
            {
                return collection;
            }

            var elementFactory = new TElement();
            var textCollection = inText.Split(Rules.Delimiters.SecondaryDelimiter);
            foreach (var currentText in textCollection)
            {
                collection.Add((TElement)elementFactory.ConvertFromString(currentText, inRow, inMemberMapData));
            }
            return collection;
        }
    }
}
