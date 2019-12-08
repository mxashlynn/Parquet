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
    public class RoomRecipe : Entity
    {
        #region Recipe Requirements
        /// <summary>
        /// Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.
        /// </summary>
        public int MinimumWalkableSpaces { get; }

        /// <summary>An optional list of <see cref="Parquets.Floor"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public IReadOnlyList<RecipeElement> RequiredFloors { get; }

        /// <summary>An optional list of <see cref="Parquets.Block"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        public IReadOnlyList<RecipeElement> RequiredPerimeterBlocks { get; }

        /// <summary>A list of <see cref="Parquets.Furnishing"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public IReadOnlyList<RecipeElement> RequiredFurnishings { get; }
        #endregion

        /// <summary>
        /// A measure of the stringency of this <see cref="RoomRecipe"/>'s requirements.
        /// If a <see cref="Room"/> corresponds to multiple recipes' requirements,
        /// the room is asigned the type of the most demanding recipe.
        /// </summary>
        public int Priority
            => RequiredFloors.Count + RequiredPerimeterBlocks.Count + RequiredFurnishings.Count + MinimumWalkableSpaces;

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRecipe"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the <see cref="RoomRecipe"/>.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the <see cref="RoomRecipe"/>.</param>
        /// <param name="in_description">Player-friendly description of the <see cref="RoomRecipe"/>.</param>
        /// <param name="in_comment">Comment of, on, or by the <see cref="RoomRecipe"/>.</param>
        /// <param name="in_requiredFurnishings">A list of furnishing categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="in_MinimumWalkableSpaces">The minimum number of walkable <see cref="MapSpace"/>s required by this <see cref="RoomRecipe"/>.</param>
        /// <param name="in_optionallyRequiredWalkableFloors">An optional list of floor categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="in_optionallyRequiredPerimeterBlocks">An optional list of block categories this <see cref="RoomRecipe"/> requires as walls.</param>
        public RoomRecipe(EntityID in_id, string in_name, string in_description, string in_comment,
                          List<RecipeElement> in_requiredFurnishings,
                          int in_MinimumWalkableSpaces = Rules.Recipes.Rooms.MinWalkableSpaces,
                          List<RecipeElement> in_optionallyRequiredWalkableFloors = null,
                          List<RecipeElement> in_optionallyRequiredPerimeterBlocks = null)
            : base (All.RoomRecipeIDs, in_id, in_name, in_description, in_comment)
        {
            Precondition.IsNotNull(in_requiredFurnishings, nameof(in_requiredFurnishings));
            Precondition.IsNotEmpty(in_requiredFurnishings, nameof(in_requiredFurnishings));
            if (in_MinimumWalkableSpaces < Rules.Recipes.Rooms.MinWalkableSpaces
                || in_MinimumWalkableSpaces > Rules.Recipes.Rooms.MaxWalkableSpaces)
            {
                throw new ArgumentOutOfRangeException(nameof(in_MinimumWalkableSpaces));
            }

            MinimumWalkableSpaces = in_MinimumWalkableSpaces;
            RequiredFloors = in_optionallyRequiredWalkableFloors ?? Enumerable.Empty<RecipeElement>().ToList();
            RequiredPerimeterBlocks = in_optionallyRequiredPerimeterBlocks ?? Enumerable.Empty<RecipeElement>().ToList();
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
            => null != in_room
            && in_room.WalkableArea.Count >= MinimumWalkableSpaces
            && RequiredPerimeterBlocks.All(element =>
                in_room.Perimeter.Count(space =>
                    All.Parquets.Get<Block>(space.Content.Block).AddsToRoom == element.ElementTag) >= element.ElementAmount)
            && RequiredFloors.All(element =>
                in_room.WalkableArea.Count(space =>
                    All.Parquets.Get<Floor>(space.Content.Floor).AddsToRoom == element.ElementTag) >= element.ElementAmount)
            && RequiredFurnishings.All(element =>
                in_room.FurnishingTags.Count(tag =>
                    tag == element.ElementTag) >= element.ElementAmount);
    }
}
