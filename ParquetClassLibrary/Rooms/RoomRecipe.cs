using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Models the minimum requirements for a <see cref="Room"/> to be recognizable and useful.
    /// </summary>
    public sealed class RoomRecipe : Model
    {
        #region Characteristics
        /// <summary>Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.</summary>
        [Index(4)]
        public int MinimumWalkableSpaces { get; }

        /// <summary>A list of <see cref="Parquets.FurnishingModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        [Index(5)]
        public IReadOnlyList<RecipeElement> OptionallyRequiredFurnishings { get; }

        /// <summary>An optional list of <see cref="Parquets.FloorModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        [Index(6)]
        public IReadOnlyList<RecipeElement> OptionallyRequiredWalkableFloors { get; }

        /// <summary>An optional list of <see cref="Parquets.BlockModel"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        [Index(7)]
        public IReadOnlyList<RecipeElement> OptionallyRequiredPerimeterBlocks { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRecipe"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="RoomRecipe"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="RoomRecipe"/>.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="RoomRecipe"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="RoomRecipe"/>.</param>
        /// <param name="inMinimumWalkableSpaces">The minimum number of walkable <see cref="MapSpace"/>s required by this <see cref="RoomRecipe"/>.</param>
        /// <param name="inOptionallyRequiredFurnishings">An optional list of furnishing categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="inOptionallyRequiredWalkableFloors">An optional list of floor categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="inOptionallyRequiredPerimeterBlocks">An optional list of block categories this <see cref="RoomRecipe"/> requires as walls.</param>
        public RoomRecipe(ModelID inID, string inName, string inDescription, string inComment,
                          int inMinimumWalkableSpaces = RoomConfiguration.MinWalkableSpaces,
                          IEnumerable<RecipeElement> inOptionallyRequiredFurnishings = null,
                          IEnumerable<RecipeElement> inOptionallyRequiredWalkableFloors = null,
                          IEnumerable<RecipeElement> inOptionallyRequiredPerimeterBlocks = null)
            : base(All.RoomRecipeIDs, inID, inName, inDescription, inComment)
        {
            if (inMinimumWalkableSpaces < RoomConfiguration.MinWalkableSpaces
                || inMinimumWalkableSpaces > RoomConfiguration.MaxWalkableSpaces)
            {
                throw new ArgumentOutOfRangeException(nameof(inMinimumWalkableSpaces));
            }

            MinimumWalkableSpaces = inMinimumWalkableSpaces;
            OptionallyRequiredFurnishings = inOptionallyRequiredFurnishings?.ToList() ?? Enumerable.Empty<RecipeElement>().ToList();
            OptionallyRequiredWalkableFloors = inOptionallyRequiredWalkableFloors?.ToList() ?? Enumerable.Empty<RecipeElement>().ToList();
            OptionallyRequiredPerimeterBlocks = inOptionallyRequiredPerimeterBlocks?.ToList() ?? Enumerable.Empty<RecipeElement>().ToList();
        }
        #endregion

        #region Derived Details
        /// <summary>
        /// A measure of the stringency of this <see cref="RoomRecipe"/>'s requirements.
        /// If a <see cref="Room"/> corresponds to multiple recipes' requirements,
        /// the room is asigned the type of the most demanding recipe.
        /// </summary>
        [Ignore]
        public int Priority
            => OptionallyRequiredWalkableFloors.Count + OptionallyRequiredPerimeterBlocks.Count + OptionallyRequiredFurnishings.Count + MinimumWalkableSpaces;

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
            && OptionallyRequiredPerimeterBlocks.All(element =>
                inRoom.Perimeter.Count(space =>
                    space.Content.Block != ModelID.None
                    && All.Parquets.Get<BlockModel>(space.Content.Block).AddsToRoom == element.ElementTag) >= element.ElementAmount)
            && OptionallyRequiredWalkableFloors.All(element =>
                inRoom.WalkableArea.Count(space =>
                    space.Content.Floor != ModelID.None
                    && All.Parquets.Get<FloorModel>(space.Content.Floor).AddsToRoom == element.ElementTag) >= element.ElementAmount)
            && OptionallyRequiredFurnishings.All(element =>
                inRoom.FurnishingTags.Count(tag =>
                    tag == element.ElementTag) >= element.ElementAmount);
        #endregion
    }
}
