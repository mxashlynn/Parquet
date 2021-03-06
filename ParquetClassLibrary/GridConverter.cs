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
        where TElement : ITypeConverter, new()
    {
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static GridConverter<TElement, TGrid> ConverterFactory { get; } =
            new GridConverter<TElement, TGrid>();

        /// <summary>Allows the converter to construct its contents.</summary>
        internal static readonly TElement ElementFactory = new();

        /// <summary>
        /// Converts the given 2D collection into a record column.
        /// </summary>
        /// <param name="inValue">The collection to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given collection serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
        {
            if (inValue is not IGrid<TElement> grid)
            {
                return Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(IGrid<TElement>), "");
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
                    result.Append(grid[y, x].ConvertToString(grid[y, x], inRow, inMemberMapData));
                    result.Append(gridDelimiter[0]);
                }
            }
            result.Remove(result.Length - gridDelimiter.Length, gridDelimiter.Length);

            return result.ToString();
        }

        /// <summary>
        /// Converts the given record column to a 2D collection.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="IGrid{TElement}"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(ModelID.None), inText, StringComparison.OrdinalIgnoreCase) == 0
                || string.Compare(nameof(Enumerable.Empty), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return new TGrid();
            }

            var headerAndGridTexts = inText.Split(Delimiters.DimensionalTerminator);
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
                    grid[y, x] = (TElement)ElementFactory.ConvertFromString(currentText, inRow, inMemberMapData);
                }
            }
            return grid;
        }
    }
}
