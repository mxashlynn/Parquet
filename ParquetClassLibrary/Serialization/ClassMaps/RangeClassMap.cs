using System;
using CsvHelper.Configuration;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="Range{T}"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class RangeClassMap<T> : ClassMap<Range<T>> where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RangeClassMap{T}"/> class.
        /// </summary>
        public RangeClassMap()
        {
            Map(m => m.Maximum);
            Map(m => m.Minimum);
        }
    }
}
