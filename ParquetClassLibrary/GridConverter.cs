using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet
{
    /// <summary>
    /// Type converter for any collection that implements <see cref="IGrid{T}"/>.
    /// </summary>
    /// <typeparam name="TElement">The type collected.</typeparam>
    /// <typeparam name="TGrid">The type of the collection.</typeparam>
    public class GridConverter<TElement, TGrid> : CollectionGenericConverter
        where TGrid : IGrid<TElement>, new()
        where TElement : ITypeConverter, IEquatable<TElement>, new()
    {
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static GridConverter<TElement, TGrid> ConverterFactory { get; } =
            new GridConverter<TElement, TGrid>();

        /// <summary>Allows the converter to construct its contents.</summary>
        internal static readonly TElement ElementFactory = new();

        /// <summary>
        /// Converts the given 2D collection into a record column.
        /// </summary>
        /// <param name="value">The collection to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given collection serialized.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is not IGrid<TElement> grid)
            {
                return Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(IGrid<TElement>), "");
            }

            if (grid.Count < 1
                || (grid.Count == 1 && ((IEnumerable<TElement>)grid).Contains(ElementFactory)))
            {
                return "";
            }

            var gridDelimiter = grid.GridDelimiter;
            var result = new StringBuilder();
            result.Append(grid.Rows);
            result.Append(Delimiters.DimensionalDelimiter[0]);
            result.Append(grid.Columns);
            result.Append(Delimiters.DimensionalTerminator[0]);

            for (var y = 0; y < grid.Rows; y++)
            {
                for (var x = 0; x < grid.Columns; x++)
                {
                    if (EqualityComparer<TElement>.Default.Equals(grid[y, x], default))
                    {
                        // Use "None" as the serialization for all empty values.
                        result.Append(nameof(ModelID.None));
                    }
                    else
                    {
                        // Serialize non-default values.
                        result.Append(grid[y, x].ConvertToString(grid[y, x], row, memberMapData));
                    }
                    result.Append(gridDelimiter[0]);
                }
            }
            result.Remove(result.Length - gridDelimiter.Length, gridDelimiter.Length);

            return result.ToString();
        }

        /// <summary>
        /// Converts the given record column to a 2D collection.
        /// </summary>
        /// <param name="text">The record column to convert to an object.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="IGrid{TElement}"/> created from the record column.</returns>
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text)
                || string.Compare(nameof(ModelID.None), text, StringComparison.OrdinalIgnoreCase) == 0
                || string.Compare(nameof(Enumerable.Empty), text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return new TGrid();
            }

            var headerAndGridTexts = text.Split(Delimiters.DimensionalTerminator);
            var header = headerAndGridTexts[0].Split(Delimiters.DimensionalDelimiter);
            var rowCount = int.TryParse(header[0], All.SerializedNumberStyle, CultureInfo.InvariantCulture, out var temp1)
                ? temp1
                : Logger.DefaultWithParseLog(headerAndGridTexts[0], "rowCount", 1);
            var columnCount = int.TryParse(header[1], All.SerializedNumberStyle, CultureInfo.InvariantCulture, out var temp2)
                ? temp2
                : Logger.DefaultWithParseLog(headerAndGridTexts[0], "columnCount", 1);
            var grid = (TGrid)Activator.CreateInstance(typeof(TGrid), new object[] { rowCount, columnCount });
            var gridDelimiter = grid.GridDelimiter;
            var gridTexts = headerAndGridTexts[1].Split(gridDelimiter);
            var gridTextEnumerator = gridTexts.GetEnumerator();
            for (var y = 0; y < grid.Rows; y++)
            {
                for (var x = 0; x < grid.Columns; x++)
                {
                    if (!gridTextEnumerator.MoveNext())
                    {
                        return grid;
                    }

                    var currentText = (string)gridTextEnumerator.Current;
                    grid[y, x] = currentText.Equals(nameof(ModelID.None), StringComparison.OrdinalIgnoreCase)
                        ? default
                        : (TElement)ElementFactory.ConvertFromString(currentText, row, memberMapData);
                }
            }
            return grid;
        }
    }
}
