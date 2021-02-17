using System.Collections.Generic;
using CsvHelper.TypeConversion;

namespace Parquet
{
    /// <summary>
    /// A two-dimensional collection that functions much like an array.
    /// </summary>
    /// <remarks>For serialization, implementing classes need to guarantee stable iteration order.</remarks>
    /// <typeparam name="TElement">The type collected.</typeparam>
    public interface IGrid<TElement> : IEnumerable<TElement>
        where TElement : ITypeConverter
    {
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="IGrid{TElement}"/>.</summary>
        public int Rows { get; }

        /// <summary>Gets the number of elements in the X dimension of the <see cref="IGrid{TElement}"/>.</summary>
        public int Columns { get; }

        /// <summary>Gets the total number of elements contained in the <see cref="IGrid{TElement}"/>.</summary>
        public int Count { get; }

        /// <summary>Access to any object in the grid.</summary>
        public ref TElement this[int y, int x] { get; }

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public IGrid<TElement> DeepClone();
    }
}
