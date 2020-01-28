using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ParquetClassLibrary.Serialization
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
        internal static readonly GridConverter<TElement, TEnumerable> ConverterFactory =
            new GridConverter<TElement, TEnumerable>();

        /// <summary>
        /// Converts the given record column to a 2D collection.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="IGrid{TElement}"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            var grid = new TEnumerable();
            if (string.IsNullOrEmpty(inText))
            {
                return grid;
            }

            var elementFactory = new TElement();
            var textCollection = inText.Split(Serializer.SecondaryDelimiter);
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
