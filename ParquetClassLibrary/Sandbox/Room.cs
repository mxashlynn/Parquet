using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Models the minimum requirements for a <see cref="Room"/> to be recognizable and useful.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// The <see cref="Space"/>s on which a <see cref="Characters.Being"/>
        /// may walk within this <see cref="Room"/>.
        /// </summary>
        public readonly ImmutableHashSet<Space> WalkableArea;

        /// <summary>
        /// The <see cref="Space"/>s whose <see cref="Block"/>s and <see cref="Furnishing"/>s
        /// define the limits of this <see cref="Room"/>.
        /// </summary>
        public readonly ImmutableHashSet<Space> Perimeter;

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
                return _cachedFurnishings is null
                    ? _cachedFurnishings = WalkableArea
                        .Concat(Perimeter)
                        .Where(space => space.Content.Furnishing.ID != EntityID.None)
                        .GroupBy(space => space.Content.Furnishing.ID)
                        .ToDictionary(group => group.Key, group => group.Count())
                    : _cachedFurnishings;
            }
        }

        /// <summary>
        /// The location with the least X and Y coordinates of every <see cref="Space"/> in this <see cref="Room"/>.
        /// </summary>
        /// <remarks>
        /// A value of <c>null</c> indicates that this <see cref="Room"/> has yet to be located.
        /// </remarks>
        private Vector2Int? _cachedPosition = null;

        /// <summary>
        /// A location with the least X and Y coordinates of every <see cref="Space"/> in this <see cref="Room"/>.
        /// </summary>
        /// <remarks>
        /// This location could server as a the upper, left point of a bounding rectangle entirely containing the room.
        /// </remarks>
        public Vector2Int Position
            => (Vector2Int)(_cachedPosition is null
                ? _cachedPosition = new Vector2Int(Perimeter.Select(space => space.Position.X).Min(),
                                                   Perimeter.Select(space => space.Position.X).Min())
                : _cachedPosition);


        /// <summary>
        /// The cached <see cref="RoomRecipe"/> identifier.
        /// A value of <see cref="EntityID.None"/> indicates that this <see cref="Room"/>
        /// has yet to be matched with a <see cref="RoomRecipe"/>.
        /// </summary>
        private EntityID _cachedRecipeID = EntityID.None;

        /// <summary>The <see cref="RoomRecipe"/> that this <see cref="Room"/> matches.</summary>
        public EntityID RecipeID
            => _cachedRecipeID == EntityID.None
                ? _cachedRecipeID = All.Recipes.Rooms.FindBestMatch(this)
                : _cachedRecipeID;

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
            if (null == in_walkableArea)
            {
                throw new ArgumentNullException(nameof(in_walkableArea));
            }
            if (in_walkableArea.Count < All.Recipes.Rooms.MinWalkableSpaces
                || in_walkableArea.Count > All.Recipes.Rooms.MaxWalkableSpaces)
            {
                throw new IndexOutOfRangeException(nameof(in_walkableArea));
            }
            if (null == in_perimeter)
            {
                throw new ArgumentNullException(nameof(in_perimeter));
            }
            // TODO Is this check a good idea?
            if (!in_walkableArea.Concat(in_perimeter).Any(space => space.Content.Furnishing.IsWalkable))
            {
                throw new ArgumentException($"No entry/exit found in {nameof(in_walkableArea)} or {nameof(in_perimeter)}.");
            }

            WalkableArea = in_walkableArea.ToImmutableHashSet();
            Perimeter = in_perimeter.ToImmutableHashSet();
        }
        #endregion
    }
}
