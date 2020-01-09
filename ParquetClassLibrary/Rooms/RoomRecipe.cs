using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Models the minimum requirements for a <see cref="Room"/> to be recognizable and useful.
    /// </summary>
    public sealed class RoomRecipe : Entity
    {
        #region Recipe Requirements
        /// <summary>Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.</summary>
        public int MinimumWalkableSpaces { get; }

        /// <summary>An optional list of <see cref="Parquets.Floor"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public IReadOnlyList<RecipeElement> RequiredFloors { get; }

        /// <summary>An optional list of <see cref="Parquets.Block"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        public IReadOnlyList<RecipeElement> RequiredPerimeterBlocks { get; }

        /// <summary>A list of <see cref="Parquets.Furnishing"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public IReadOnlyList<RecipeElement> RequiredFurnishings { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRecipe"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="RoomRecipe"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="RoomRecipe"/>.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="RoomRecipe"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="RoomRecipe"/>.</param>
        /// <param name="inRequiredFurnishings">A list of furnishing categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="inMinimumWalkableSpaces">The minimum number of walkable <see cref="MapSpace"/>s required by this <see cref="RoomRecipe"/>.</param>
        /// <param name="inOptionallyRequiredWalkableFloors">An optional list of floor categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="inOptionallyRequiredPerimeterBlocks">An optional list of block categories this <see cref="RoomRecipe"/> requires as walls.</param>
        public RoomRecipe(EntityID inID, string inName, string inDescription, string inComment,
                          List<RecipeElement> inRequiredFurnishings,
                          int inMinimumWalkableSpaces = Rules.Recipes.Room.MinWalkableSpaces,
                          List<RecipeElement> inOptionallyRequiredWalkableFloors = null,
                          List<RecipeElement> inOptionallyRequiredPerimeterBlocks = null)
            : base (All.RoomRecipeIDs, inID, inName, inDescription, inComment)
        {
            Precondition.IsNotNullOrEmpty(inRequiredFurnishings, nameof(inRequiredFurnishings));
            if (inMinimumWalkableSpaces < Rules.Recipes.Room.MinWalkableSpaces
                || inMinimumWalkableSpaces > Rules.Recipes.Room.MaxWalkableSpaces)
            {
                throw new ArgumentOutOfRangeException(nameof(inMinimumWalkableSpaces));
            }

            MinimumWalkableSpaces = inMinimumWalkableSpaces;
            RequiredFloors = inOptionallyRequiredWalkableFloors ?? Enumerable.Empty<RecipeElement>().ToList();
            RequiredPerimeterBlocks = inOptionallyRequiredPerimeterBlocks ?? Enumerable.Empty<RecipeElement>().ToList();
            RequiredFurnishings = inRequiredFurnishings;
        }
        #endregion

        /// <summary>
        /// A measure of the stringency of this <see cref="RoomRecipe"/>'s requirements.
        /// If a <see cref="Room"/> corresponds to multiple recipes' requirements,
        /// the room is asigned the type of the most demanding recipe.
        /// </summary>
        public int Priority
            => RequiredFloors.Count + RequiredPerimeterBlocks.Count + RequiredFurnishings.Count + MinimumWalkableSpaces;

        /// <summary>
        /// Determines if the given <see cref="Room"/> conforms to this <see cref="RoomRecipe"/>.
        /// </summary>
        /// <param name="inRoom">The <see cref="Room"/> to check.</param>
        /// <returns>
        /// <c>ture</c> if <paramref name="inRoom"/> is an instance of this <see cref="RoomRecipe"/>;
        /// <c>false</c> otherwise.
        /// </returns>
        public bool Matches(Room inRoom)
            => null != inRoom
            && inRoom.WalkableArea.Count >= MinimumWalkableSpaces
            && RequiredPerimeterBlocks.All(element =>
                inRoom.Perimeter.Count(space =>
                    All.Parquets.Get<Block>(space.Content.Block).AddsToRoom == element.ElementTag) >= element.ElementAmount)
            && RequiredFloors.All(element =>
                inRoom.WalkableArea.Count(space =>
                    All.Parquets.Get<Floor>(space.Content.Floor).AddsToRoom == element.ElementTag) >= element.ElementAmount)
            && RequiredFurnishings.All(element =>
                inRoom.FurnishingTags.Count(tag =>
                    tag == element.ElementTag) >= element.ElementAmount);
    }
}
