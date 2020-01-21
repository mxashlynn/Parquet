using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ParquetClassLibrary.Serialization.Converters
{
    /// <summary>
    /// Type converter for <see cref="IEnumerable{string}"/>.
    /// </summary>
    public class StringEnumerableConverter : DefaultTypeConverter
    {
        /// <summary>
        /// Converts the given record column to <see cref="EntityTagEnumerableConverter"/>.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="IEnumerable{EntityTag}"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText))
            {
                return Enumerable.Empty<string>();
            }
            else if (!inText.Contains(Serializer.SecondaryDelimiter, StringComparison.InvariantCultureIgnoreCase))
            {
                return new List<string> { (string)base.ConvertFromString(inText, inRow, inMemberMapData) };
            }
            else
            {
                var splitText = inText.Split(Serializer.SecondaryDelimiter);
                var strings = new List<string>();
                foreach(var tagText in splitText)
                {
                    strings.Add((string)base.ConvertFromString(tagText, inRow, inMemberMapData));
                }
                return strings;
            }
        }
    }
}
