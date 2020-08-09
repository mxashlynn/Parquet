using System;
using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary
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

        /// <summary>
        /// Converts the given 2D collection into a record column.
        /// </summary>
        /// <param name="inValue">The collection to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given collection serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
        {
            if (!(inValue is IGrid<TElement> grid))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotConvert,
                                                          inValue, nameof(IGrid<TElement>)));
            }

            if (grid.Count < 1)
            {
                return "";
            }

            var result = new StringBuilder();
            result.Append(grid.Rows);
            result.Append(Delimiters.DimensionalDelimiter);
            result.Append(grid.Columns);
            result.Append(Delimiters.DimensionalTerminator);

            for (var y = 0; y < grid.Rows; y++)
            {
                for (var x = 0; x < grid.Columns; x++)
                {
                    if (null != grid[y, x])
                    {
                        result.Append(grid[y, x].ConvertToString(grid[y, x], inRow, inMemberMapData));
                    }
                    result.Append(Delimiters.SecondaryDelimiter);
                }
            }
            result.Remove(result.Length - Delimiters.SecondaryDelimiter.Length, Delimiters.SecondaryDelimiter.Length);

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
            if (string.IsNullOrEmpty(inText))
            {
                return new TGrid();
            }

            var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyle ?? All.SerializedNumberStyle;

            var headerAndGridTexts = inText.Split(Delimiters.DimensionalTerminator);
            var header = headerAndGridTexts[0].Split(Delimiters.DimensionalDelimiter);
            if (!int.TryParse(header[0], numberStyle, CultureInfo.InvariantCulture, out var rowCount)
                || !int.TryParse(header[1], numberStyle, CultureInfo.InvariantCulture, out var columnCount))
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                        inText, nameof(ModelID)));
            }

            var grid = (TGrid)Activator.CreateInstance(typeof(TGrid), new object[] { rowCount, columnCount });
            var elementFactory = new TElement();

            var gridTexts = headerAndGridTexts[1].Split(Delimiters.SecondaryDelimiter);
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
                    grid[y, x] = (TElement)elementFactory.ConvertFromString(currentText, inRow, inMemberMapData);
                }
            }
            return grid;
        }
    }
}
