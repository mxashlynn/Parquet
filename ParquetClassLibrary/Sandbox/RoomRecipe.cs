using System;
using System.Collections.Generic;
using System.Linq;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Models the minimum requirements for a <see cref="Room"/> to be recognizable and useful.
    /// </summary>
    public class RoomRecipe : Entity
    {
        #region Recipe Requirements
        /// <summary>
        /// Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.
        /// </summary>
        public int MinimumWalkableSpaces { get; }

        /// <summary>An optional list of <see cref="Sandbox.Parquets.Floor"/> types this <see cref="RoomRecipe"/> requires.</summary>
        public readonly List<EntityID> RequiredFloors = new List<EntityID>();

        /// <summary>An optional list of <see cref="Sandbox.Parquets.Block"/> types this <see cref="RoomRecipe"/> requires as walls.</summary>
        public readonly List<EntityID> RequiredPerimeterBlocks = new List<EntityID>();

        /// <summary>A list of <see cref="Sandbox.Parquets.Furnishing"/> types this <see cref="RoomRecipe"/> requires.</summary>
        public readonly List<EntityID> RequiredFurnishings = new List<EntityID>();
        #endregion

        /// <summary>
        /// A measure of the stringency of this <see cref="RoomRecipe"/>'s requirements.
        /// If a <see cref="Room"/> corresponds to multiple recipes' requirements,
        /// the room is asigned the type of the most demanding recipe.
        /// </summary>
        public int Priority
        {
            get
            {
                return RequiredFloors.Count + RequiredPerimeterBlocks.Count + RequiredFurnishings.Count + MinimumWalkableSpaces;
            }
        }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRecipe"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the recipe.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.</param>
        /// <param name="in_MinimumWalkableSpaces">In recipe minimum floors.</param>
        /// <param name="in_requiredFloors">An optional list of floor types this recipre requires.</param>
        /// <param name="in_requiredPerimeterBlocks">An optional list of block types this recipre requires as walls.</param>
        /// <param name="in_requiredFurnishings">A list of furnishing types this recipre requires.</param>
        public RoomRecipe(EntityID in_id, string in_name, int in_MinimumWalkableSpaces,
                          List<EntityID> in_requiredFloors, List<EntityID> in_requiredPerimeterBlocks,
                          List<EntityID> in_requiredFurnishings)
            : base (All.RoomRecipeIDs, in_id, in_name)
        {
            if (in_MinimumWalkableSpaces < All.Recipes.Rooms.MinWalkableSpaces
                || in_MinimumWalkableSpaces > All.Recipes.Rooms.MaxWalkableSpaces)
            {
                throw new ArgumentOutOfRangeException(nameof(in_MinimumWalkableSpaces));
            }
            foreach (var floorID in in_requiredFloors ?? Enumerable.Empty<EntityID>())
            {
                if (!floorID.IsValidForRange(All.FloorIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_requiredFloors));
                }
            }
            foreach (var wallID in in_requiredPerimeterBlocks ?? Enumerable.Empty<EntityID>())
            {
                if (!wallID.IsValidForRange(All.BlockIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_requiredPerimeterBlocks));
                }
            }
            if (null == in_requiredFurnishings)
            {
                throw new ArgumentNullException(nameof(in_requiredFurnishings));
            }
            if (in_requiredFurnishings.Count < 1)
            {
                throw new IndexOutOfRangeException(nameof(in_requiredFurnishings));
            }
            foreach (var furnishingID in in_requiredFurnishings)
            {
                if (!furnishingID.IsValidForRange(All.FurnishingIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_requiredFurnishings));
                }
            }

            MinimumWalkableSpaces = in_MinimumWalkableSpaces;
            RequiredFloors.AddRange(in_requiredFloors ?? Enumerable.Empty<EntityID>());
            RequiredPerimeterBlocks.AddRange(in_requiredPerimeterBlocks ?? Enumerable.Empty<EntityID>());
            RequiredFurnishings.AddRange(in_requiredFurnishings);
        }
        #endregion

        /// <summary>
        /// Determines if the given <see cref="Room"/> conforms to this <see cref="RoomRecipe"/>.
        /// </summary>
        /// <param name="in_room">The <see cref="Room"/> to check.</param>
        /// <returns>
        /// <c>ture</c> if <paramref name="in_room"/> is an instance of this <see cref="RoomRecipe"/>;
        /// <c>false</c> otherwise.
        /// </returns>
        public bool Matches(Room in_room)
        {
            return in_room.WalkableArea.Count >= MinimumWalkableSpaces
                && RequiredFloors.All(s => in_room.WalkableArea.Contains(s))
                && RequiredPerimeterBlocks.All(s => in_room.Perimeter.Contains(s))
                && RequiredFurnishings.All(s => in_room.Furnishings.Contains(s));
        }
    }
}
