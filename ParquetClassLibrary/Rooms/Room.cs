using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Models the a constructed <see cref="Room"/>.
    /// </summary>
    public class Room : IEquatable<Room>
    {
        /// <summary>
        /// The <see cref="MapSpace"/>s on which a <see cref="Beings.BeingModel"/>
        /// may walk within this <see cref="Room"/>.
        /// </summary>
        public MapSpaceCollection WalkableArea { get; }

        /// <summary>
        /// The <see cref="MapSpace"/>s whose <see cref="BlockModel"/>s and <see cref="FurnishingModel"/>s
        /// define the limits of this <see cref="Room"/>.
        /// </summary>
        public MapSpaceCollection Perimeter { get; }

        /// <summary>
        /// The <see cref="ModelID"/>s for every <see cref="FurnishingModel"/> found in this <see cref="Room"/>
        /// together with the number of times that furnishing occurs.
        /// </summary>
        public IEnumerable<ModelTag> FurnishingTags
            => WalkableArea
               .Concat(Perimeter)
               .Where(space => ModelID.None != space.Content.Furnishing
                            && ModelTag.None != All.Parquets.Get<FurnishingModel>(space.Content.Furnishing).AddsToRoom)
               .Select(space => All.Parquets.Get<FurnishingModel>(space.Content.Furnishing).AddsToRoom);

        /// <summary>
        /// A location with the least X and Y coordinates of every <see cref="MapSpace"/> in this <see cref="Room"/>.
        /// </summary>
        /// <remarks>
        /// This location could server as a the upper, left point of a bounding rectangle entirely containing the room.
        /// </remarks>
        public Vector2D Position
            => new Vector2D(WalkableArea.Select(space => space.Position.X).Min(),
                              WalkableArea.Select(space => space.Position.Y).Min());

        /// <summary>The <see cref="RoomRecipe"/> that this <see cref="Room"/> matches.</summary>
        public ModelID RecipeID
            => FindBestMatch();

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="inWalkableArea">
        /// The <see cref="MapSpace"/>s on which a <see cref="Beings.BeingModel"/>
        /// may walk within this <see cref="Room"/>.
        /// </param>
        /// <param name="inPerimeter">
        /// The <see cref="MapSpace"/>s whose <see cref="BlockModel"/>s and <see cref="FurnishingModel"/>s
        /// define the limits of this <see cref="Room"/>.
        /// </param>
        public Room(MapSpaceCollection inWalkableArea, MapSpaceCollection inPerimeter)
        {
            Precondition.IsNotNullOrEmpty(inWalkableArea, nameof(inWalkableArea));
            Precondition.IsNotNullOrEmpty(inPerimeter, nameof(inPerimeter));

            if (inWalkableArea.Count < Rules.Recipes.Room.MinWalkableSpaces
                || inWalkableArea.Count > Rules.Recipes.Room.MaxWalkableSpaces)
            {
                throw new IndexOutOfRangeException($"{nameof(inWalkableArea)} violates {nameof(Rules.Recipes.Room)}.");
            }

            if (!inWalkableArea.Concat(inPerimeter).Any(space
                => space.Content.Furnishing != ModelID.None
                && (All.Parquets.Get<FurnishingModel>(space.Content.Furnishing)?.IsEntry ?? false)))
            {
                throw new ArgumentException($"No entry/exit found in {nameof(inWalkableArea)} or {nameof(inPerimeter)}.");
            }

            WalkableArea = inWalkableArea;
            Perimeter = inPerimeter;
        }
        #endregion

        /// <summary>
        /// Determines whether or not the given position is included in this <see cref="Room"/>.
        /// </summary>
        /// <param name="inPosition">The position to check for.</param>
        /// <returns><c>true</c>, if the position was containsed, <c>false</c> otherwise.</returns>
        public bool ContainsPosition(Vector2D inPosition)
            => WalkableArea.Concat(Perimeter).Any(space => space.Position == inPosition);

        /// <summary>
        /// Finds the <see cref="ModelID"/> of the <see cref="RoomRecipe"/> that best matches this <see cref="Room"/>.
        /// </summary>
        private ModelID FindBestMatch()
            => All.RoomRecipes
                  .Where(model => model?.Matches(this) ?? false)
                  .Select(recipe => recipe.Priority)
                  .DefaultIfEmpty<int>(ModelID.None).Max();

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
        /// <param name="inRoom">The <see cref="Room"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Room inRoom)
            => null != inRoom
            && WalkableArea.SetEquals(inRoom.WalkableArea)
            && Perimeter.SetEquals(inRoom.Perimeter);

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
        /// <param name="inRoom1">The first <see cref="Room"/> to compare.</param>
        /// <param name="inRoom2">The second <see cref="Room"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Room inRoom1, Room inRoom2)
           => inRoom1?.Equals(inRoom2) ?? inRoom2?.Equals(inRoom1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="Room"/> is not equal to another specified instance of <see cref="Room"/>.
        /// </summary>
        /// <param name="inRoom1">The first <see cref="Room"/> to compare.</param>
        /// <param name="inRoom2">The second <see cref="Room"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Room inRoom1, Room inRoom2)
           => !(inRoom1 == inRoom2);
        #endregion
    }
}
