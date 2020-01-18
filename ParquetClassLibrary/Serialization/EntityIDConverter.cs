using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization
{
    /// <summary>
    /// Type converter for <see cref="EntityID"/>.
    /// </summary>
    public class EntityIDConverter : DefaultTypeConverter
    {
        /// <summary>
        /// Converts the given record column to <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="EntityID"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            Precondition.IsNotNull(inMemberMapData, nameof(inMemberMapData));

            // IDEA Assign IDs to unassigned here?
            // Might be hard to figure out what kind of ID this is.
            if (string.IsNullOrEmpty(inText))
            {
                return EntityID.None;
            }

            var numberStyle = inMemberMapData.TypeConverterOptions.NumberStyle ?? NumberStyles.Integer;
            if (int.TryParse(inText, numberStyle, inMemberMapData.TypeConverterOptions.CultureInfo, out var id))
            {
                return (EntityID)id;
            }

            return (EntityID)base.ConvertFromString(inText, inRow, inMemberMapData);
        }
    }
}
