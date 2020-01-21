using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Converters
{
    /// <summary>
    /// Type converter for <see cref="RecipeElement"/>.
    /// </summary>
    public class RecipeElementConverter : DefaultTypeConverter
    {
        /// <summary>
        /// Converts the given record column to <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="EntityTag"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            Precondition.IsNotNull(inText, nameof(inText));
            Precondition.IsNotNull(inMemberMapData, nameof(inMemberMapData));
            if (!inText.Contains(Serializer.SecondaryDelimiter, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new FormatException($"Could not parse recipe element '{inText}' as it does not contain '{Serializer.SecondaryDelimiter}'.");
            }

            if (string.IsNullOrEmpty(inText))
            {
                return RecipeElement.None;
            }

            var splitText = inText.Split(Serializer.SecondaryDelimiter);
            var amountText = splitText[0];
            var tag = splitText[1];

            var numberStyle = inMemberMapData.TypeConverterOptions.NumberStyle ?? NumberStyles.Integer;
            if (int.TryParse(amountText, numberStyle, inMemberMapData.TypeConverterOptions.CultureInfo, out var amount))
            {
                return new RecipeElement(amount, tag);
            }
            else
            {
                throw new FormatException($"Could not parse recipe amount '{amountText}' as an integer.");
            }
        }
    }
}
