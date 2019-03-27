using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Sandbox.ID;

namespace ParquetCSVImporter
{
    /// <summary>
    /// ID Converter for parquet identifiers.
    /// </summary>
    public class EntityIDConverter : DefaultTypeConverter
    {
        /// <summary>
        /// Converts the given record column to <see cref="EnitityID"/>.
        /// </summary>
        /// <param name="text">The record column to convert to an object.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="EnitityID"/> created from the record column.</returns>
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var numberStyle = memberMapData.TypeConverterOptions.NumberStyle ?? NumberStyles.Integer;

            if (int.TryParse(text, numberStyle, memberMapData.TypeConverterOptions.CultureInfo, out var i))
            {
                return (EnitityID)i;
            }

            return (EnitityID)base.ConvertFromString(text, row, memberMapData);
        }
    }
}
