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
    public class Room
    {
        /// <summary>
        /// The <see cref="Space"/>s on which a <see cref="Characters.Being"/>
        /// may walk within this <see cref="Room"/>.
        /// </summary>
        public readonly HashSet<Space> WalkableArea;

        /// <summary>
        /// The <see cref="Space"/>s whose <see cref="Block"/>s and <see cref="Furnishing"/>s
        /// define the limits of this <see cref="Room"/>.
        /// </summary>
        public readonly HashSet<Space> Perimeter;

        /// <summary>
        /// The cached <see cref="EntityID"/>s for every <see cref="Furnishing"/> found in this <see cref="Room"/>
        /// together with the number of times that furnishing occurs.
        /// </summary>
        private IEnumerable<EntityTag> _cachedFurnishings;

        /// <summary>
        /// The <see cref="EntityID"/>s for every <see cref="Furnishing"/> found in this <see cref="Room"/>
        /// together with the number of times that furnishing occurs.
        /// </summary>
        public IEnumerable<EntityTag> FurnishingTags
            => _cachedFurnishings
            ?? (_cachedFurnishings = new List<EntityTag>(
                    WalkableArea
                    .Concat(Perimeter)
                    .Where(space => EntityID.None != space.Content.Furnishing
                                 && EntityTag.None != All.Parquets.Get<Furnishing>(space.Content.Furnishing).AddsToRoom)
                    .Select(space => All.Parquets.Get<Furnishing>(space.Content.Furnishing).AddsToRoom)
                )
            );

        /// <summary>
        /// The location with the least X and Y coordinates of every <see cref="Space"/> in this <see cref="Room"/>.
        /// </summary>
        /// <remarks>
        /// A value of <c>null</c> indicates that this <see cref="Room"/> has yet to be located.
        /// </remarks>
        private Vector2Int? _cachedPosition;

        /// <summary>
        /// A location with the least X and Y coordinates of every <see cref="Space"/> in this <see cref="Room"/>.
        /// </summary>
        /// <remarks>
        /// This location could server as a the upper, left point of a bounding rectangle entirely containing the room.
        /// </remarks>
        public Vector2Int Position
            => (Vector2Int)(
                null == _cachedPosition
                    ? _cachedPosition = new Vector2Int(Perimeter.Select(space => space.Position.X).Min(),
                                                       Perimeter.Select(space => space.Position.Y).Min())
                    : _cachedPosition);

        /// <summary>
        /// The cached <see cref="RoomRecipe"/> identifier.
        /// A value of <see cref="EntityID.None"/> indicates that this <see cref="Room"/>
        /// has yet to be matched with a <see cref="RoomRecipe"/>.
        /// </summary>
        private EntityID? _cachedRecipeID;

        /// <summary>The <see cref="RoomRecipe"/> that this <see cref="Room"/> matches.</summary>
        public EntityID RecipeID
            => (EntityID)(null == _cachedRecipeID
                ? _cachedRecipeID = FindBestMatch()
                : _cachedRecipeID);

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
        public Room(HashSet<Space> in_walkableArea, HashSet<Space> in_perimeter)
        {
            Precondition.IsNotNull(in_walkableArea, nameof(in_walkableArea));
            Precondition.IsNotNull(in_perimeter, nameof(in_perimeter));

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
            _cachedRecipeID = FindBestMatch();
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
        /// Clears internal caches ahead of <see cref="Room"/> update.
        /// </summary>
        // TODO Is this the best way to handle this?
        public void ClearCaches()
        {
            _cachedPosition = null;
            _cachedRecipeID = null;
            _cachedFurnishings = null;
        }

        /// <summary>
        /// Finds the <see cref="EntityID"/> of the <see cref="RoomRecipe"/> that best matches this <see cref="Room"/>.
        /// </summary>
        private EntityID FindBestMatch()
        {
            // TODO Can we skip the Any() comparison and condense this into a single line?
            var matches = All.RoomRecipes.Where(entity => entity?.Matches(this) ?? false);
            return matches.Any()
                ? (EntityID)matches.Select(recipe => recipe.Priority).DefaultIfEmpty(EntityID.None).Max()
                : EntityID.None;
        }
    }
}
