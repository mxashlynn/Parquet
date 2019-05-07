using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Map
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
        private Dictionary<EntityID, int> _cachedFurnishings;

        /// <summary>
        /// The <see cref="EntityID"/>s for every <see cref="Furnishing"/> found in this <see cref="Room"/>
        /// together with the number of times that furnishing occurs.
        /// </summary>
        public Dictionary<EntityID, int> Furnishings
        {
            get
            {
                return _cachedFurnishings
                       ?? (_cachedFurnishings = WalkableArea
                                                .Concat(Perimeter)
                                                .Where(space => null != space.Content.Furnishing
                                                             && space.Content.Furnishing.ID != EntityID.None)
                                                .GroupBy(space => space.Content.Furnishing.ID)
                                                .ToDictionary(group => group.Key, group => group.Count()));
            }
        }

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
                ? _cachedRecipeID = All.Recipes.Rooms.FindBestMatch(this)
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

            var minimumPossiblePerimeterLength = 2 * in_walkableArea.Count + 2;
            if (in_perimeter.Count < minimumPossiblePerimeterLength)
            {
                throw new IndexOutOfRangeException($"{nameof(in_perimeter)} is too small to surround {nameof(in_walkableArea)}.");
            }

            if (!in_walkableArea.Concat(in_perimeter).Any(space
                => null != space.Content.Furnishing
                && space.Content.Furnishing.IsEntry))
            {
                throw new ArgumentException($"No entry/exit found in {nameof(in_walkableArea)} or {nameof(in_perimeter)}.");
            }

            WalkableArea = in_walkableArea;
            Perimeter = in_perimeter;
        }
        #endregion

        // TODO Either make this explicitly immutable or implement a way to clear the caches when updating.
    }
}
