using System.Collections.Generic;

namespace ParquetClassLibrary
{
    /// <summary>
    /// A two-dimensional collection that functions much like an array.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Grid is a custom suffix implying Collection.  See https://github.com/dotnet/roslyn-analyzers/issues/3072")]
    public interface IGrid<T> : IReadOnlyCollection<T>
    {
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="IGrid{T}"/>.</summary>
        public int Rows { get; }

        /// <summary>Gets the number of elements in the X dimension of the <see cref="IGrid{T}"/>.</summary>
        public int Columns { get; }

        /// <summary>Access to any object in the grid.</summary>
        public ref T this[int y, int x] { get; }
    }
}
