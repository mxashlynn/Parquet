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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Grid is a custom suffix implying Collection.  See https://github.com/dotnet/roslyn-analyzers/issues/3072")]
    public class ParquetStackGrid : IReadOnlyCollection<ParquetStack>
    {
        /// <summary>The backing collection of <see cref="ParquetStack"/>s.</summary>
        private ParquetStack[,] ParquetStacks { get; }

        /// <summary>Dimensions in parquets.</summary>
        private Vector2D DimensionsInParquets { get; }

        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ParquetStackGrid"/>.</summary>
        public int Rows => ParquetStacks.GetLength(0);

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ParquetStackGrid"/>.</summary>
        public int Columns => ParquetStacks.GetLength(1);

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
        /// Initializes a new empty <see cref="ParquetStackGrid"/>.
        /// </summary>
        /// <param name="inRows">The length of the Y dimension of the collection.</param>
        /// <param name="inColumns">The length of the X dimension of the collection.</param>
        public ParquetStackGrid(int inRows, int inColumns)
            => ParquetStacks = new ParquetStack[inRows, inColumns];

        /// <summary>
        /// Initializes a new <see cref="ParquetStackGrid"/> from the given 2D <see cref="ParquetStack"/> array.
        /// </summary>
        /// <param name="inParquetStackArray">The array containing the subregion.</param>
        public ParquetStackGrid(ParquetStack[,] inParquetStackArray)
        {
            ParquetStacks = inParquetStackArray;
        }

        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ParquetStacks.IsValidPosition(inPosition);

        /// <summary>Access to any <see cref="ParquetStack"/> in the 2D collection.</summary>
        public ref ParquetStack this[int y, int x]
        {
            get => ref ParquetStacks[y, x];
        }

        /// <summary>
        /// Returns the set of <see cref="MapSpace"/>s corresponding to the subregion.
        /// </summary>
        /// <returns>The <see cref="MapSpace"/>s defined by this subregion.</returns>
        public MapSpaceCollection GetSpaces()
        {
            Precondition.IsNotNull(ParquetStacks, nameof(ParquetStacks));

            var uniqueResults = new HashSet<MapSpace>();
            for (var y = 0; y < Rows; y++)
            {
                for (var x = 0; x < Columns; x++)
                {
                    var currentSpace = new MapSpace(x, y, ParquetStacks[y, x], this);
                    uniqueResults.Add(currentSpace);
                }
            }

            return new MapSpaceCollection(uniqueResults);
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetStack}"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParquetStack> IEnumerable<ParquetStack>.GetEnumerator()
            => (IEnumerator<ParquetStack>)ParquetStacks.GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetStackGrid"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ParquetStacks.GetEnumerator();
    }
}
