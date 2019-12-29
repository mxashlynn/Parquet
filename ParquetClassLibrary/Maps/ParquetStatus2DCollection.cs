using System.Collections;
using System.Collections.Generic;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ParquetStatus"/>es for use in <see cref="MapParent"/> and derived classes.
    /// The intent is that this class function much like a read-only array.
    /// </summary>
    public class ParquetStatus2DCollection : IReadOnlyCollection<ParquetStatus>
    {
        /// <summary>The backing collection of <see cref="ParquetStatus"/>es.</summary>
        private ParquetStatus[,] ParquetStatuses { get; }

        /// <summary>Dimensions in parquets.</summary>
        private Vector2D DimensionsInParquets { get; }

        /// <summary>The total number of parquets collected.</summary>
        public int Count
            => DimensionsInParquets.Y * DimensionsInParquets.X;

        /// <summary>
        /// Initializes a new <see cref="ParquetStatus2DCollection"/>.
        /// </summary>
        /// <param name="inDimensions">The length of each dimension of the collection.</param>
        public ParquetStatus2DCollection(int inDimensions)
        {
            ParquetStatuses = new ParquetStatus[inDimensions, inDimensions];
        }

        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ParquetStatuses.IsValidPosition(inPosition);

        /// <summary>Access to any <see cref="ParquetStatus"/> in the 2D collection.</summary>
        public ref ParquetStatus this[int y, int x]
        {
            get => ref ParquetStatuses[y, x];
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetStatus}"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParquetStatus> IEnumerable<ParquetStatus>.GetEnumerator()
            => (IEnumerator<ParquetStatus>)ParquetStatuses.GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetStatus2DCollection"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ParquetStatuses.GetEnumerator();
    }
}
