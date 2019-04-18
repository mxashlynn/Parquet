using System;
using System.Collections.Generic;

namespace ParquetClassLibrary.Crafting
{
    /// <summary>
    /// Models the minimum requirements for a room to be recognizable and useful.
    /// </summary>
    public struct RoomRecipe
    {
        #region Defaults
        /// <summary>What a new room is called if no name is given.</summary>
        public const string DefaultName = "New Room Recipe";
        #endregion

        #region Recipe Requirements
        /// <summary>The room's identifier.</summary>
        public EntityID ID { get; }

        /// <summary>What the room is called in-game.</summary>
        public string Name { get; }

        /// <summary>
        /// Minimum number of open <see cref="Sandbox.Parquets.Floor"/> needed for this room to register.
        /// </summary>
        public int RecipeMinimumFloors { get; }

        /// <summary>An optional list of floor types this recipre requires.</summary>
        public List<EntityID> AcceptableFloors { get; }

        /// <summary>An optional list of block types this recipre requires as walls.</summary>
        public List<EntityID> AcceptableWalls { get; }

        /// <summary>A list of furnishing types this recipre requires.</summary>
        public List<EntityID> RequiredFurnishings { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRecipe"/> struct.
        /// </summary>
        /// <param name="in_id">Unique identifier for the recipe.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.</param>
        /// <param name="in_recipeMinimumFloors">In recipe minimum floors.</param>
        /// <param name="in_acceptableFloors">An optional list of floor types this recipre requires.</param>
        /// <param name="in_acceptableWalls">An optional list of block types this recipre requires as walls.</param>
        /// <param name="in_requiredFurnishings">A list of furnishing types this recipre requires.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when in_id is not within the <see cref="AssemblyInfo.RoomRecipeIDs"/> range.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when any of the in_acceptableFloors are not within the <see cref="AssemblyInfo.FloorIDs"/> range.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when any of the in_acceptableWalls are not within the <see cref="AssemblyInfo.BlockIDs"/> range.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when any of the in_requiredFurnishings are not within the <see cref="AssemblyInfo.FurnishingIDs"/> range.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when in_recipeMinimumFloors is less than <see cref="AssemblyInfo.RoomMinimumFloors"/>.
        /// </exception>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when in_requiredFurnishings is empty.
        /// </exception>
        public RoomRecipe(EntityID in_id, string in_name, int in_recipeMinimumFloors,
                          List<EntityID> in_acceptableFloors, List<EntityID> in_acceptableWalls,
                          List<EntityID> in_requiredFurnishings)
        {
            if (!in_id.IsValidForRange(All.RoomRecipeIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }
            if (in_recipeMinimumFloors < All.Recipes.Rooms.MinWalkableParquets)
            {
                throw new ArgumentOutOfRangeException(nameof(in_recipeMinimumFloors));
            }
            foreach (var floorID in in_acceptableFloors)
            {
                if (!floorID.IsValidForRange(All.FloorIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_acceptableFloors));
                }
            }
            foreach (var wallID in in_acceptableWalls)
            {
                if (!wallID.IsValidForRange(All.BlockIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_acceptableWalls));
                }
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

            ID = in_id;
            Name = string.IsNullOrEmpty(in_name)
                ? DefaultName
                : in_name;
            RecipeMinimumFloors = in_recipeMinimumFloors;
            AcceptableFloors = in_acceptableFloors;
            AcceptableWalls = in_acceptableWalls;
            RequiredFurnishings = in_requiredFurnishings;
        }
        #endregion

        // TODO: Add a method to validate that the a given room indeed satisfies this recipe.
    }
}
