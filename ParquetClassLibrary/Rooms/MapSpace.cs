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
        public static readonly MapSpace Empty = new(Point2D.Origin, ParquetModelPack.Empty, ParquetModelPackGrid.Empty);
        #endregion

        #region Characteristics
        /// <summary>The grid containing this <see cref="MapSpace"/>.</summary>
        public ParquetModelPackGrid Grid { get; }

        /// <summary>Location of this <see cref="MapSpace"/>.</summary>
        public Point2D Position { get; }

        /// <summary>All parquets occupying this <see cref="MapSpace"/>.</summary>
        public ParquetModelPack Content { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="MapSpace"/> class.
        /// </summary>
        /// <param name="position">Where this <see cref="MapSpace"/> is.</param>
        /// <param name="content">All parquets occupying this <see cref="MapSpace"/>.</param>
        /// <param name="grid">The <see cref="ParquetModelPackGrid"/> within which this <see cref="MapSpace"/> occurs.</param>
        public MapSpace(Point2D position, ParquetModelPack content, ParquetModelPackGrid grid)
        {
            Position = position;
            Content = content;
            Grid = grid;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapSpace"/> class.
        /// </summary>
        /// <param name="x">X-coordinate of this <see cref="MapSpace"/>.</param>
        /// <param name="y">Y-coordinate of this <see cref="MapSpace"/>.</param>
        /// <param name="content">All parquets occupying this <see cref="MapSpace"/>.</param>
        /// <param name="grid">The grid in which this <see cref="MapSpace"/> occurs. </param>
        public MapSpace(int x, int y, ParquetModelPack content, ParquetModelPackGrid grid)
            : this(new Point2D(x, y), content, grid) { }
        #endregion

        #region Position Offsets
        /// <summary>Finds the <see cref="MapSpace"/> related to the given space by the given offset, if any.</summary>
        /// <param name="offset">
        /// A <see cref="Point2D"/> to add to the current <see cref="MapSpace"/>'s position
        /// to determine the position of the MapSpace sought.
        /// </param>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace Neighbor(Point2D offset)
        {
            Precondition.IsNotNull(Grid, nameof(Grid));

            var offsetPosition = Position + offset;
            return Grid.IsValidPosition(offsetPosition)
                ? new MapSpace(offsetPosition, Grid[offsetPosition.Y, offsetPosition.X], Grid)
                : Empty;
        }

        /// <summary>Finds the <see cref="MapSpace"/> to the north of the given space, if any.</summary>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace NorthNeighbor()
            => Neighbor(Point2D.North);

        /// <summary>Finds the <see cref="MapSpace"/> to the south of the given space, if any.</summary>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace SouthNeighbor()
            => Neighbor(Point2D.South);

        /// <summary>Finds the <see cref="MapSpace"/> to the east of the given space, if any.</summary>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace EastNeighbor()
            => Neighbor(Point2D.East);

        /// <summary>Finds the <see cref="MapSpace"/> to the west of the given space, if any.</summary>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace WestNeighbor()
            => Neighbor(Point2D.West);

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
        /// <param name="walkableArea">The <see cref="IReadOnlySet{MapSpace}"/> used to define this <see cref="MapSpace"/>.</param>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> may be used as an enclosing entry by a <see cref="Room"/>, <c>false</c> otherwise.</returns>
        internal bool IsEnclosingEntry(IReadOnlySet<MapSpace> walkableArea)
            => ModelID.None != Content.FurnishingID
            && (All.Furnishings.GetOrNull<FurnishingModel>(Content.FurnishingID)?.Entry ?? EntryType.None) != EntryType.None
            && Content.IsEnclosing
            && Neighbors().Any(neighbor1 => walkableArea.Contains(neighbor1))
            && Neighbors().Any(neighbor2 => !walkableArea.Contains(neighbor2)
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
        /// <param name="other">The <see cref="MapSpace"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="MapSpace"/>s are equal.</returns>
        public bool Equals(MapSpace other)
            => Position == other?.Position
            && Content == other.Content;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="MapSpace"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="MapSpace"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is MapSpace space
            && Equals(space);

        /// <summary>
        /// Determines whether a specified instance of <see cref="MapSpace"/> is equal to
        /// another specified instance of <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="space1">The first <see cref="MapSpace"/> to compare.</param>
        /// <param name="space2">The second <see cref="MapSpace"/> to compare.</param>
        /// <returns><c>true</c> if the two <see cref="MapSpace"/>s are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(MapSpace space1, MapSpace space2)
            => space1?.Equals(space2) ?? space2?.Equals(space1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="MapSpace"/> is unequal to
        /// another specified instance of <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="space1">The first <see cref="MapSpace"/> to compare.</param>
        /// <param name="space2">The second <see cref="MapSpace"/> to compare.</param>
        /// <returns><c>true</c> if the two <see cref="MapSpace"/>s are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(MapSpace space1, MapSpace space2)
            => !(space1 == space2);
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
