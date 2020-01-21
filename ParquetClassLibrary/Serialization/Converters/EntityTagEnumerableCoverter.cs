using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace ParquetClassLibrary.Serialization.Converters
{
    /// <summary>
    /// Type converter for <see cref="IEnumerable{EntityTag}"/>.
    /// </summary>
    public class EntityTagEnumerableConverter : EntityTagConverter
    {
        /// <summary>
        /// Converts the given record column to <see cref="EntityTagEnumerableConverter"/>.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="IEnumerable{EntityTag}"/> created from the record column.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText))
            {
                return Enumerable.Empty<EntityTag>();
            }
            else if (!inText.Contains(Serializer.SecondaryDelimiter, StringComparison.InvariantCultureIgnoreCase))
            {
                return new List<EntityTag> { (EntityTag)base.ConvertFromString(inText, inRow, inMemberMapData) };
            }
            else
            {
                var splitText = inText.Split(Serializer.SecondaryDelimiter);
                var tags = new List<EntityTag>();
                foreach(var tagText in splitText)
                {
                    tags.Add((EntityTag)base.ConvertFromString(tagText, inRow, inMemberMapData));
                }
                return tags;
            }
        }
    }
}
