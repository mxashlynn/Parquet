using System.Collections;
using System.Collections.Generic;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ParquetStack"/>s for use in <see cref="MapParent"/> and derived classes.
    /// The intent is that this class function much like a read-only array.
    /// </summary>
    public class ParquetStack2DCollection : IReadOnlyCollection<ParquetStack>
    {
        /// <summary>The backing collection of <see cref="ParquetStack"/>s.</summary>
        private ParquetStack[,] ParquetStacks { get; }

        /// <summary>Dimensions in parquets.</summary>
        private Vector2D DimensionsInParquets { get; }

        /// <summary>The total number of parquets collected.</summary>
        public int Count
        {
            get
            {
                var count = 0;

                for (var y = 0; y < DimensionsInParquets.Y; y++)
                {
                    for (var x = 0; x < DimensionsInParquets.X; x++)
                    {
                        count += ParquetStacks[y, x].Count;
                    }
                }

                return count;
            }
        }

        /// <summary>
        /// Initializes a new <see cref="ParquetStack2DCollection"/>.
        /// </summary>
        /// <param name="in_dimensions">The length of each dimension of the collection.</param>
        public ParquetStack2DCollection(int in_dimensions)
        {
            ParquetStacks = new ParquetStack[in_dimensions, in_dimensions];
        }

        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="in_position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D in_position)
            => ParquetStacks.IsValidPosition(in_position);

        /// <summary>Access to any <see cref="ParquetStack"/> in the 2D collection.</summary>
        public ref ParquetStack this[int y, int x]
        {
            get => ref ParquetStacks[y, x];
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetStack}"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParquetStack> IEnumerable<ParquetStack>.GetEnumerator()
            => (IEnumerator<ParquetStack>)ParquetStacks.GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetStack2DCollection"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ParquetStacks.GetEnumerator();
    }
}
