using System.Collections.Generic;
using CsvHelper.TypeConversion;

namespace Parquet
{
    /// <summary>
    /// A two-dimensional collection that functions much like an immutable array.
    /// </summary>
    /// <remarks>For serialization, implementing classes need to guarantee stable iteration order.</remarks>
    /// <typeparam name="TElement">The type collected.</typeparam>
    public interface IReadOnlyGrid<TElement> : IReadOnlyCollection<TElement>
        where TElement : ITypeConverter
    {
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="IReadOnlyGrid{TElement}"/>.</summary>
        public int Rows { get; }

        /// <summary>Gets the number of elements in the X dimension of the <see cref="IReadOnlyGrid{TElement}"/>.</summary>
        public int Columns { get; }

        /// <summary>Read-only access to any object in the grid.</summary>
        public TElement this[int y, int x] { get; }

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public IReadOnlyGrid<TElement> DeepClone();
    }
}
