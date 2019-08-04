using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;
#if UNITY_2018_4_OR_NEWER
using UnityEngine;
#else
using ParquetClassLibrary.Stubs;
#endif

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Models the a constructed <see cref="Room"/>.
    /// </summary>
    public class Room : IEquatable<Room>
    {
        /// <summary>
        /// The <see cref="Space"/>s on which a <see cref="Characters.Being"/>
        /// may walk within this <see cref="Room"/>.
        /// </summary>
        public readonly SpaceCollection WalkableArea;

        /// <summary>
        /// The <see cref="Space"/>s whose <see cref="Block"/>s and <see cref="Furnishing"/>s
        /// define the limits of this <see cref="Room"/>.
        /// </summary>
        public readonly SpaceCollection Perimeter;

        /// <summary>
        /// The <see cref="EntityID"/>s for every <see cref="Furnishing"/> found in this <see cref="Room"/>
        /// together with the number of times that furnishing occurs.
        /// </summary>
        public IEnumerable<EntityTag> FurnishingTags
            => WalkableArea
               .Concat(Perimeter)
               .Where(space => EntityID.None != space.Content.Furnishing
                            && EntityTag.None != All.Parquets.Get<Furnishing>(space.Content.Furnishing).AddsToRoom)
               .Select(space => All.Parquets.Get<Furnishing>(space.Content.Furnishing).AddsToRoom);

        /// <summary>
        /// A location with the least X and Y coordinates of every <see cref="Space"/> in this <see cref="Room"/>.
        /// </summary>
        /// <remarks>
        /// This location could server as a the upper, left point of a bounding rectangle entirely containing the room.
        /// </remarks>
        public Vector2Int Position
            => new Vector2Int(WalkableArea.Select(space => space.Position.X).Min(),
                              WalkableArea.Select(space => space.Position.Y).Min());

        /// <summary>The <see cref="RoomRecipe"/> that this <see cref="Room"/> matches.</summary>
        public EntityID RecipeID
            => FindBestMatch();

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="in_walkableArea">
        /// The <see cref="Space"/>s on which a <see cref="Characters.Being"/>
        /// may walk within this <see cref="Room"/>.
        /// </param>
        /// <param name="in_perimeter">
        /// The <see cref="Space"/>s whose <see cref="Block"/>s and <see cref="Furnishing"/>s
        /// define the limits of this <see cref="Room"/>.
        /// </param>
        public Room(SpaceCollection in_walkableArea, SpaceCollection in_perimeter)
        {
            Precondition.IsNotNull(in_walkableArea, nameof(in_walkableArea));
            Precondition.IsNotEmpty(in_walkableArea, nameof(in_walkableArea));
            Precondition.IsNotNull(in_perimeter, nameof(in_perimeter));
            Precondition.IsNotEmpty(in_perimeter, nameof(in_perimeter));

            if (in_walkableArea.Count < All.Recipes.Rooms.MinWalkableSpaces
                || in_walkableArea.Count > All.Recipes.Rooms.MaxWalkableSpaces)
            {
                throw new IndexOutOfRangeException(nameof(in_walkableArea));
            }

            if (!in_walkableArea.Concat(in_perimeter).Any(space
                => All.Parquets.Get<Furnishing>(space.Content.Furnishing)?.IsEntry ?? false))
            {
                throw new ArgumentException($"No entry/exit found in {nameof(in_walkableArea)} or {nameof(in_perimeter)}.");
            }

            WalkableArea = in_walkableArea;
            Perimeter = in_perimeter;
        }
        #endregion

        /// <summary>
        /// Determines whether or not the given position is included in this <see cref="Room"/>.
        /// </summary>
        /// <param name="in_position">The position to check for.</param>
        /// <returns><c>true</c>, if the position was containsed, <c>false</c> otherwise.</returns>
        public bool ContainsPosition(Vector2Int in_position)
            => WalkableArea.Concat(Perimeter).Any(space => space.Position == in_position);

        /// <summary>
        /// Finds the <see cref="EntityID"/> of the <see cref="RoomRecipe"/> that best matches this <see cref="Room"/>.
        /// </summary>
        private EntityID FindBestMatch()
            => All.RoomRecipes
                  .Where(entity => entity?.Matches(this) ?? false)
                  .Select(recipe => recipe.Priority)
                  .DefaultIfEmpty(EntityID.None).Max();

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for an <see cref="Room"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (WalkableArea, Perimeter).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Room"/> is equal to the current <see cref="Room"/>.
        /// </summary>
        /// <param name="in_room">The <see cref="Room"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Room in_room)
            => null != in_room
            && WalkableArea.SetEquals(in_room.WalkableArea)
            && Perimeter.SetEquals(in_room.Perimeter);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Room"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Room"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
            => obj is Room room && Equals(room);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Room"/> is equal to another specified instance of <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_room1">The first <see cref="Room"/> to compare.</param>
        /// <param name="in_room2">The second <see cref="Room"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Room in_room1, Room in_room2)
            => (in_room1 is null
                && in_room2 is null)
            || (!(in_room1 is null)
                && !(in_room2 is null)
                && in_room1.WalkableArea.SetEquals(in_room2.WalkableArea)
                && in_room1.Perimeter.SetEquals(in_room2.Perimeter));

        /// <summary>
        /// Determines whether a specified instance of <see cref="Room"/> is not equal to another specified instance of <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_room1">The first <see cref="Room"/> to compare.</param>
        /// <param name="in_room2">The second <see cref="Room"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Room in_room1, Room in_room2)
            => (!(in_room1 is null)
                && !(in_room2 is null)
                && !in_room1.WalkableArea.SetEquals(in_room2.WalkableArea)
                && !in_room1.Perimeter.SetEquals(in_room2.Perimeter))
            || (!(in_room1 is null)
                && in_room2 is null)
            || (in_room1 is null
                && !(in_room2 is null));
        #endregion
    }
}
