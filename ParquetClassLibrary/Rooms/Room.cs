using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Parquet.Parquets;
using Parquet.Properties;

namespace Parquet.Rooms
{
    /// <summary>
    /// Models a constructed <see cref="Room"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    public sealed class Room : IEquatable<Room>
    {
        // NTOE that I considered deriving this class from Status<RoomRecipe>, but at present it doesn't seem to make sense
        // to serialize Rooms.  If this changes, we should indeed make this a status class.
        #region Status
        /// <summary>
        /// The <see cref="MapSpace"/>s on which a <see cref="Beings.BeingModel"/>
        /// may walk within this <see cref="Room"/>.
        /// </summary>
        public IReadOnlySet<MapSpace> WalkableArea { get; }

        /// <summary>
        /// The <see cref="MapSpace"/>s whose <see cref="BlockModel"/>s and <see cref="FurnishingModel"/>s
        /// define the limits of this <see cref="Room"/>.
        /// </summary>
        public IReadOnlySet<MapSpace> Perimeter { get; }

        /// <summary>
        /// The <see cref="ModelTag"/>s for every <see cref="FurnishingModel"/> found in this <see cref="Room"/>
        /// duplicated the number of times each tag is found.
        /// </summary>
        public IEnumerable<ModelTag> FurnishingTags
            => WalkableArea
               .Concat(Perimeter)
               .Where(space => ModelID.None != space.Content.FurnishingID
                            && All.Furnishings.GetOrNull<FurnishingModel>(space.Content.FurnishingID)?.AddsToRoom.Count > 0)
               .SelectMany(space => All.Furnishings.GetOrNull<FurnishingModel>(space.Content.FurnishingID)?.AddsToRoom ?? Enumerable.Empty<ModelTag>());

        /// <summary>
        /// A location with the least X and Y coordinates of every <see cref="MapSpace"/> in this <see cref="Room"/>.
        /// </summary>
        /// <remarks>
        /// This location could server as a the upper, left point of a bounding rectangle entirely containing the room.
        /// </remarks>
        public Point2D Position
            => new(WalkableArea.Select(space => space.Position.X).Min(),
                   WalkableArea.Select(space => space.Position.Y).Min());

        /// <summary>The <see cref="RoomRecipe"/> that this <see cref="Room"/> matches.</summary>
        public ModelID RecipeID
            => FindBestMatch();
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="walkableArea">
        /// The <see cref="MapSpace"/>s on which a <see cref="Beings.BeingModel"/>
        /// may walk within this <see cref="Room"/>.
        /// </param>
        /// <param name="perimeter">
        /// The <see cref="MapSpace"/>s whose <see cref="BlockModel"/>s and <see cref="FurnishingModel"/>s
        /// define the limits of this <see cref="Room"/>.
        /// </param>
        public Room(IReadOnlySet<MapSpace> walkableArea, IReadOnlySet<MapSpace> perimeter)
        {
            Precondition.IsNotNullOrEmpty(walkableArea, nameof(walkableArea));
            Precondition.IsNotNullOrEmpty(perimeter, nameof(perimeter));
            if (walkableArea is null
                || perimeter is null)
            {
                return;
            }

            if (walkableArea.Count > RoomConfiguration.MaxWalkableSpaces)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfOrderLTE,
                                                           nameof(walkableArea), walkableArea,
                                                           RoomConfiguration.MaxWalkableSpaces));
            }
            else if (walkableArea.Count < RoomConfiguration.MinWalkableSpaces)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfOrderGTE,
                                                           nameof(walkableArea.Count),
                                                           walkableArea.Count, RoomConfiguration.MinWalkableSpaces));
            }
            if (!walkableArea.Concat(perimeter).Any(space
                => space.Content.FurnishingID != ModelID.None
                && (All.Furnishings.GetOrNull<FurnishingModel>(space.Content.FurnishingID)?.Entry ?? EntryType.None) != EntryType.None))
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorNoExitFound,
                                                           nameof(walkableArea), nameof(perimeter)));
            }

            WalkableArea = walkableArea;
            Perimeter = perimeter;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Room"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (WalkableArea, Perimeter).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Room"/> is equal to the current <see cref="Room"/>.
        /// </summary>
        /// <param name="other">The <see cref="Room"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Room other)
            => other is not null
            && WalkableArea.SetEquals(other.WalkableArea)
            && Perimeter.SetEquals(other.Perimeter);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Room"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Room"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Room room
            && Equals(room);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Room"/> is equal to another specified instance of <see cref="Room"/>.
        /// </summary>
        /// <param name="room1">The first <see cref="Room"/> to compare.</param>
        /// <param name="room2">The second <see cref="Room"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Room room1, Room room2)
           => room1?.Equals(room2) ?? room2?.Equals(room1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="Room"/> is not equal to another specified instance of <see cref="Room"/>.
        /// </summary>
        /// <param name="room1">The first <see cref="Room"/> to compare.</param>
        /// <param name="room2">The second <see cref="Room"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Room room1, Room room2)
           => !(room1 == room2);
        #endregion

        #region Utilities
        /// <summary>
        /// Determines whether or not the given position is included in this <see cref="Room"/>.
        /// </summary>
        /// <param name="position">The position to check for.</param>
        /// <returns><c>true</c>, if the <see cref="Room"/> contains the given position, <c>false</c> otherwise.</returns>
        public bool ContainsPosition(Point2D position)
            => WalkableArea.Concat(Perimeter).Any(space => space.Position == position);

        /// <summary>
        /// Finds the <see cref="ModelID"/> of the <see cref="RoomRecipe"/> that best matches this <see cref="Room"/>.
        /// </summary>
        private ModelID FindBestMatch()
            => All.RoomRecipes
                  .Where(model => model?.Matches(this) ?? false)
                  .Select(recipe => recipe.Priority)
                  .DefaultIfEmpty<int>(ModelID.None).Max();
        #endregion
    }
}
