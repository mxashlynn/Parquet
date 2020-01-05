using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary;

namespace ParquetCLITool
{
    /// <summary>
    /// Type converter for <see cref="EntityTag"/>.
    /// </summary>
    public class EntityTagConverter : DefaultTypeConverter
    {
        /// <summary>
        /// Converts the given record column to <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="EntityID"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
            => (EntityTag)inText;
    }
}
