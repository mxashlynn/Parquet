using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization
{
    /// <summary>
    /// Type converter for <see cref="IEnumerable{EntityID}"/>.
    /// </summary>
    public class EntityIDEnumerableConverter : EntityIDConverter
    {
        /// <summary>
        /// Converts the given record column to <see cref="EntityIDEnumerableConverter"/>.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="IEnumerable{EntityID}"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            Precondition.IsNotNull(inMemberMapData, nameof(inMemberMapData));

            if (string.IsNullOrEmpty(inText))
            {
                return Enumerable.Empty<EntityID>();
            }
            else if (!inText.Contains(Serializer.SecondaryDelimiter, StringComparison.InvariantCultureIgnoreCase))
            {
                return new List<EntityID> { (EntityID)base.ConvertFromString(inText, inRow, inMemberMapData) };
            }
            else
            {
                var splitText = inText.Split(Serializer.SecondaryDelimiter);
                var ids = new List<EntityID>();
                foreach(var idText in splitText)
                {
                    ids.Add((EntityID)base.ConvertFromString(idText, inRow, inMemberMapData));
                }
                return ids;
            }
        }
    }
}
