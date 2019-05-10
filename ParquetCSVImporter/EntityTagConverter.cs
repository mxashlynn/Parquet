using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary;

namespace ParquetCSVImporter
{
    /// <summary>
    /// Type converter for <see cref="EntityTag"/>.
    /// </summary>
    public class EntityTagConverter : DefaultTypeConverter
    {
        /// <summary>
        /// Converts the given record column to <see cref="EntityID"/>.
        /// </summary>
        /// <param name="in_text">The record column to convert to an object.</param>
        /// <param name="in_row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="in_memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="EntityID"/> created from the record column.</returns>
        public override object ConvertFromString(string in_text, IReaderRow in_row, MemberMapData in_memberMapData)
        {
            return (EntityTag)in_text;
        }
    }
}
