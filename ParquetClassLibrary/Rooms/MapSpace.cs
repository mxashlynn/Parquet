using System;
using System.Collections.Generic;
using System.Linq;
using Parquet.Parquets;

namespace Parquet.Rooms
{
    /// <summary>
    /// Represents a <see cref="ParquetModelPack"/> together with its coordinates within a given <see cref="Regions.RegionModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    public sealed class MapSpace : IEquatable<MapSpace>
    {
        #region Class Defaults
        /// <summary>The null <see cref="MapSpace"/>, which exists nowhere and contains nothing.</summary>
        public static readonly MapSpace Empty = new MapSpace(Vector2D.Zero, ParquetModelPack.Empty, ParquetModelPackGrid.Empty);
        #endregion

        #region Characteristics
        /// <summary>The subregion containing this <see cref="MapSpace"/>.</summary>
        public ParquetModelPackGrid Subregion { get; }

        /// <summary>Location of this <see cref="MapSpace"/>.</summary>
        public Vector2D Position { get; }

        /// <summary>All parquets occupying this <see cref="MapSpace"/>.</summary>
        public ParquetModelPack Content { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="MapSpace"/> class.
        /// </summary>
        /// <param name="inPosition">Where this <see cref="MapSpace"/> is.</param>
        /// <param name="inContent">All parquets occupying this <see cref="MapSpace"/>.</param>
        /// <param name="inSubregion">The <see cref="ParquetModelPackGrid"/> within which this <see cref="MapSpace"/> occurs.</param>
        public MapSpace(Vector2D inPosition, ParquetModelPack inContent, ParquetModelPackGrid inSubregion)
        {
            Position = inPosition;
            Content = inContent;
            Subregion = inSubregion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapSpace"/> class.
        /// </summary>
        /// <param name="inX">X-coordinate of this <see cref="MapSpace"/>.</param>
        /// <param name="inY">Y-coordinate of this <see cref="MapSpace"/>.</param>
        /// <param name="inContent">All parquets occupying this <see cref="MapSpace"/>.</param>
        /// <param name="inSubregion">The subregion in which this <see cref="MapSpace"/> occurs. </param>
        public MapSpace(int inX, int inY, ParquetModelPack inContent, ParquetModelPackGrid inSubregion)
            : this(new Vector2D(inX, inY), inContent, inSubregion) { }
        #endregion

        #region Position Offsets
        /// <summary>Finds the <see cref="MapSpace"/> related to the given space by the given offset, if any.</summary>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace Neighbor(Vector2D inOffset)
        {
            Precondition.IsNotNull(Subregion, nameof(Subregion));

            var offsetPosition = Position + inOffset;
            return Subregion.IsValidPosition(offsetPosition)
                ? new MapSpace(offsetPosition, Subregion[offsetPosition.Y, offsetPosition.X], Subregion)
                : Empty;
        }

        /// <summary>Finds the <see cref="MapSpace"/> to the north of the given space, if any.</summary>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace NorthNeighbor()
            => Neighbor(Vector2D.North);

        /// <summary>Finds the <see cref="MapSpace"/> to the south of the given space, if any.</summary>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace SouthNeighbor()
            => Neighbor(Vector2D.South);

        /// <summary>Finds the <see cref="MapSpace"/> to the east of the given space, if any.</summary>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace EastNeighbor()
            => Neighbor(Vector2D.East);

        /// <summary>Finds the <see cref="MapSpace"/> to the west of the given space, if any.</summary>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace WestNeighbor()
            => Neighbor(Vector2D.West);

        /// <summary>Finds the <see cref="MapSpace"/> related to the given space by the given offset, if any.</summary>
        /// <returns>A list of four <see cref="MapSpace"/>s, some or all of which may be <see cref="Empty"/>.</returns>
        public IReadOnlyList<MapSpace> Neighbors()
            => new List<MapSpace>
            {
                NorthNeighbor(),
                SouthNeighbor(),
                EastNeighbor(),
                WestNeighbor(),
            };
        #endregion

        #region General Gameplay Support
        /// <summary>
        /// Indicates whether this <see cref="MapSpace"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the <see cref="ParquetModelPack"/> contains only null references; otherwise, <c>false</c>.</value>
        public bool IsEmpty
            => Content.IsEmpty;

        /// <summary>
        /// A <see cref="MapSpace"/> is Enclosing iff:
        /// 1, It has a <see cref="BlockModel"/> that is not <see cref="BlockModel.IsLiquid"/>; or,
        /// 2, It has a <see cref="FurnishingModel"/> that is <see cref="FurnishingModel.IsEnclosing"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> is Enclosing, <c>false</c> otherwise.</returns>
        public bool IsEnclosing
            => Content.IsEnclosing;

        /// <summary>
        /// A <see cref="MapSpace"/> is Entry iff:
        /// 1, Its <see cref="Content"/> is either Walkable or Enclosing; and,
        /// 2, It has a <see cref="FurnishingModel"/> that is <see cref="FurnishingModel.Entry"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> is Entry, <c>false</c> otherwise.</returns>
        internal bool IsEntry
            => Content.IsEntry;

        /// <summary>
        /// A <see cref="MapSpace"/> is Walkable iff:
        /// 1, It has a <see cref="FloorModel"/>;
        /// 2, It does not have a <see cref="BlockModel"/>;
        /// 3, It does not have a <see cref="FurnishingModel"/> that is not <see cref="FurnishingModel.IsEnclosing"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> is Walkable, <c>false</c> otherwise.</returns>
        internal bool IsWalkable
            => Content.IsWalkable;
        #endregion

        #region Neighbor-Relative Gameplay Algorithm Support
        /// <summary>
        /// Determines if this <see cref="MapSpace"/> is both <see cref="IsEntry"/>
        /// and <see cref="IsWalkable"/>.
        /// </summary>
        /// <seealso cref="IsEnclosingEntry"/>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> may be used as a walkable entry by a <see cref="Room"/>, <c>false</c> otherwise.</returns>
        internal bool IsWalkableEntry
            => IsEntry && IsWalkable;

        /// <summary>
        /// Determines if this <see cref="MapSpace"/> is:
        /// first, <see cref="IsEntry"/>;
        /// second, <see cref="IsEnclosing"/>;
        /// third, has one walkable neighbor that is within the given <see cref="IReadOnlySet{MapSpace}"/>; and
        /// fourth, has one walkable neighbor that is NOT within the given <see cref="IReadOnlySet{MapSpace}"/>.
        /// </summary>
        /// <param name="inWalkableArea">The <see cref="ISIReadOnlySetet{MapSpace}"/> used to define this <see cref="MapSpace"/>.</param>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> may be used as an enclosing entry by a <see cref="Room"/>, <c>false</c> otherwise.</returns>
        internal bool IsEnclosingEntry(IReadOnlySet<MapSpace> inWalkableArea)
            => ModelID.None != Content.FurnishingID
            && (All.Furnishings.GetOrNull<FurnishingModel>(Content.FurnishingID)?.Entry ?? EntryType.None) != EntryType.None
            && Content.IsEnclosing
            && Neighbors().Any(neighbor1 => inWalkableArea.Contains(neighbor1))
            && Neighbors().Any(neighbor2 => !inWalkableArea.Contains(neighbor2)
                                         && neighbor2.Content.IsWalkable);
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="MapSpace"/> class.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (Position, Content).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="MapSpace"/> is equal to the current <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="inSpace">The <see cref="MapSpace"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="MapSpace"/>s are equal.</returns>
        public bool Equals(MapSpace inSpace)
            => Position == inSpace?.Position
            && Content == inSpace.Content;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="MapSpace"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="MapSpace"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is MapSpace vector
            && Equals(vector);

        /// <summary>
        /// Determines whether a specified instance of <see cref="MapSpace"/> is equal to
        /// another specified instance of <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="inSpace1">The first <see cref="MapSpace"/> to compare.</param>
        /// <param name="inSpace2">The second <see cref="MapSpace"/> to compare.</param>
        /// <returns><c>true</c> if the two <see cref="MapSpace"/>s are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(MapSpace inSpace1, MapSpace inSpace2)
            => inSpace1?.Equals(inSpace2) ?? inSpace2?.Equals(inSpace1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="MapSpace"/> is unequal to
        /// another specified instance of <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="inSpace1">The first <see cref="MapSpace"/> to compare.</param>
        /// <param name="inSpace2">The second <see cref="MapSpace"/> to compare.</param>
        /// <returns><c>true</c> if the two <see cref="MapSpace"/>s are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(MapSpace inSpace1, MapSpace inSpace2)
            => !(inSpace1 == inSpace2);
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="MapSpace"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Position}{Content}";
        #endregion
    }
}
