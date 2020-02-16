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
            => ConvertToString(inValue, Rules.Delimiters.SecondaryDelimiter);

        /// <summary>
        /// Converts the given 2D collection into a record column.
        /// </summary>
        /// <param name="inValue">The collection to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <param name="inDelimiter">The string to use to separate elements in the series.</param>
        /// <returns>The given collection serialized.</returns>
        public string ConvertToString(object inValue, string inDelimiter)
            => null != inValue
            && inValue is IGrid<TElement> grid
                ? string.Join(inDelimiter, grid)
                : throw new ArgumentException($"Could not serialize {inValue} as {nameof(IGrid<TElement>)}.");

        /// <summary>
        /// Converts the given record column to a 2D collection.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="IGrid{TElement}"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            // TODO This isn't going to work as written because we need a constructor that knows the dimensions the IGrid should have.
            // var grid = new SomeGrid(rowCount, columnCount)
            var grid = new TEnumerable();
            if (string.IsNullOrEmpty(inText))
            {
                return grid;
            }

            var elementFactory = new TElement();
            var textCollection = inText.Split(Rules.Delimiters.SecondaryDelimiter);
            var textCollectionEnumerator = textCollection.GetEnumerator();
            for (var y = 0; y < grid.Rows; y++)
            {
                for (var x = 0; x < grid.Columns; x++)
                {
                    if (!textCollectionEnumerator.MoveNext())
                    {
                        return grid;
                    }

                    var currentText = (string)textCollectionEnumerator.Current;
                    grid[x, y] = (TElement)elementFactory.ConvertFromString(currentText, inRow, inMemberMapData);
                }
            }
            return grid;
        }
    }
}
