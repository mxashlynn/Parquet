using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Type converter for any collection that implements <see cref="IGrid"/>.
    /// </summary>
    /// <typeparam name="TElement">The type collected.</typeparam>
    /// <typeparam name="TEnumerable">The type of the collection.</typeparam>
    public class GridConverter<TElement, TEnumerable> : CollectionGenericConverter
        where TEnumerable : IGrid<TElement>, new()
        where TElement : ITypeConverter, new()
    {
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static GridConverter<TElement, TEnumerable> ConverterFactory { get; } =
            new GridConverter<TElement, TEnumerable>();

        /// <summary>
        /// Converts the given 2D collection into a record column.
        /// </summary>
        /// <param name="inValue">The collection to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given collection serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is IGrid<TElement> grid
                ? $"{grid.Rows}{Rules.Delimiters.DimensionalDelimiter}" +
                  $"{grid.Columns}{Rules.Delimiters.DimensionalTerminator}" +
                  string.Join(Rules.Delimiters.SecondaryDelimiter, grid)
                : throw new ArgumentException($"Could not serialize '{inValue}' as {nameof(IGrid<TElement>)}.");

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
                return new TEnumerable();
            }

            var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyle ?? All.SerializedNumberStyle;
            var cultureInfo = inMemberMapData?.TypeConverterOptions?.CultureInfo ?? All.SerializedCultureInfo;

            var headerAndGridTexts = inText.Split(Rules.Delimiters.DimensionalTerminator);
            var header = headerAndGridTexts[0].Split(Rules.Delimiters.DimensionalDelimiter);
            if (!int.TryParse(header[0], numberStyle, cultureInfo, out var rowCount)
                || !int.TryParse(header[1], numberStyle, cultureInfo, out var columnCount))
            {
                throw new FormatException($"Could not parse {nameof(EntityID)} '{inText}'.");
            }

            var grid = (TEnumerable)Activator.CreateInstance(typeof(TEnumerable), new object[] { rowCount, columnCount });
            var elementFactory = new TElement();

            var gridTexts = headerAndGridTexts[1].Split(Rules.Delimiters.SecondaryDelimiter);
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
                    grid[x, y] = (TElement)elementFactory.ConvertFromString(currentText, inRow, inMemberMapData);
                }
            }
            return grid;
        }
    }
}
