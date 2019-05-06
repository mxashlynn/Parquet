using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Utilities;

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
        public IReadOnlyList<EntityID> RequiredFloors { get; }

        /// <summary>An optional list of <see cref="Sandbox.Parquets.Block"/> types this <see cref="RoomRecipe"/> requires as walls.</summary>
        public IReadOnlyList<EntityID> RequiredPerimeterBlocks { get; }

        /// <summary>A list of <see cref="Parquets.Furnishing"/> types this <see cref="RoomRecipe"/> requires.</summary>
        public IReadOnlyDictionary<EntityID, int> RequiredFurnishings { get; }
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
        /// <param name="in_requiredFurnishings">A list of furnishing types this recipe requires.</param>
        /// <param name="in_MinimumWalkableSpaces">In recipe minimum floors.</param>
        /// <param name="in_optionallyRequiredWalkableFloors">An optional list of floor types this recipe requires.</param>
        /// <param name="in_optionallyRequiredPerimeterBlocks">An optional list of block types this recipe requires as walls.</param>
        public RoomRecipe(EntityID in_id, string in_name, Dictionary<EntityID, int> in_requiredFurnishings,
                          int in_MinimumWalkableSpaces = All.Recipes.Rooms.MinWalkableSpaces,
                          List<EntityID> in_optionallyRequiredWalkableFloors = null,
                          List<EntityID> in_optionallyRequiredPerimeterBlocks = null)
            : base (All.RoomRecipeIDs, in_id, in_name)
        {
            Precondition.AreInRange(in_optionallyRequiredWalkableFloors, All.FloorIDs, nameof(in_optionallyRequiredWalkableFloors));
            Precondition.AreInRange(in_optionallyRequiredPerimeterBlocks, All.BlockIDs, nameof(in_optionallyRequiredPerimeterBlocks));
            Precondition.IsNotNull(in_requiredFurnishings, nameof(in_requiredFurnishings));
            Precondition.IsNotEmpty(in_requiredFurnishings, nameof(in_requiredFurnishings));
            Precondition.AreInRange(in_requiredFurnishings.Keys, All.FurnishingIDs, nameof(in_requiredFurnishings));
            if (in_MinimumWalkableSpaces < All.Recipes.Rooms.MinWalkableSpaces
                || in_MinimumWalkableSpaces > All.Recipes.Rooms.MaxWalkableSpaces)
            {
                throw new ArgumentOutOfRangeException(nameof(in_MinimumWalkableSpaces));
            }

            MinimumWalkableSpaces = in_MinimumWalkableSpaces;
            RequiredFloors = in_optionallyRequiredWalkableFloors ?? Enumerable.Empty<EntityID>().ToList();
            RequiredPerimeterBlocks = in_optionallyRequiredPerimeterBlocks ?? Enumerable.Empty<EntityID>().ToList();
            RequiredFurnishings = in_requiredFurnishings;
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
                && RequiredFloors.All(id => in_room.WalkableArea.Select(space => space.Content.Floor.ID).Contains(id))
                && RequiredPerimeterBlocks.All(id => in_room.Perimeter.Select(space => space.Content.Block.ID).Contains(id))
                && RequiredFurnishings.All(kvp => in_room.Furnishings.ContainsKey(kvp.Key) && in_room.Furnishings[kvp.Key] >= kvp.Value);
        }
    }
}
