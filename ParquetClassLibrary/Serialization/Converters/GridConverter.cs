using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Converters
{
    /// <summary>
    /// Type converter for any collection that implements <see cref="IGrid"/>.
    /// </summary>
    public class GridConverter<TInner, TOuter> : DefaultTypeConverter
        where TOuter : IGrid<TInner>, new()
    {
        /// <summary>
        /// Converts the given record column to a 2D collection.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="IEnumerable{EntityTag}"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            Precondition.IsNotNullOrEmpty(inText);

            var grid = new TOuter();
            if (!string.IsNullOrEmpty(inText))
            {
                var textCollection = inText.Split(Serializer.SecondaryDelimiter);
                var textCollectionEnumerator = textCollection.GetEnumerator();
                var nextFound = true;  // QUESTION: Do I need to call textCollectionEnumerator.MoveNext() before using .Current the first time?
                for (var y = 0; y < grid.Rows; y++)
                {
                    if (!nextFound)
                    {
                        break;
                    }
                    for (var x = 0; x < grid.Columns; x++)
                    {
                        nextFound = textCollectionEnumerator.MoveNext();
                        if (!nextFound)
                        {
                            break;
                        }
                        else
                        {
                            var currentText = (string)textCollectionEnumerator.Current;
                            // TODO It might be better if each serializable class provided their own ConvertFromBase implementation.
                            grid[x, y] = (TInner)base.ConvertFromString(currentText, inRow, inMemberMapData);
                        }
                    }
                }
            }
            return grid;
        }
    }
}
