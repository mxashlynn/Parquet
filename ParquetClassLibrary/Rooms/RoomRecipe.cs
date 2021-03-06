using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using Parquet.Parquets;
using Parquet.Properties;

namespace Parquet.Rooms
{
    /// <summary>
    /// Models the minimum requirements for a <see cref="Room"/> to be recognizable and useful.
    /// </summary>
    /// <remarks>
    /// Runtime room detection is an important feature in the design of Parquet.
    /// </remarks>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public class RoomRecipe : Model, IMutableRoomRecipe
    {
        #region Characteristics
        /// <summary>Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.</summary>
        [Index(5)]
        public int MinimumWalkableSpaces { get; private set; }

        /// <summary>A list of <see cref="FurnishingModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        [Index(6)]
        public IReadOnlyList<RecipeElement> OptionallyRequiredFurnishings { get; }

        /// <summary>An optional list of <see cref="FloorModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        [Index(7)]
        public IReadOnlyList<RecipeElement> OptionallyRequiredWalkableFloors { get; }

        /// <summary>An optional list of <see cref="BlockModel"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        [Index(8)]
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
        /// <param name="inTags">Any additional information about this <see cref="RoomRecipe"/>.</param>
        /// <param name="inMinimumWalkableSpaces">The minimum number of walkable <see cref="MapSpace"/>s required by this <see cref="RoomRecipe"/>.</param>
        /// <param name="inOptionallyRequiredFurnishings">An optional list of furnishing categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="inOptionallyRequiredWalkableFloors">An optional list of floor categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="inOptionallyRequiredPerimeterBlocks">An optional list of block categories this <see cref="RoomRecipe"/> requires as walls.</param>
        public RoomRecipe(ModelID inID, string inName, string inDescription, string inComment,
                          IEnumerable<ModelTag> inTags = null, int? inMinimumWalkableSpaces = null,
                          IEnumerable<RecipeElement> inOptionallyRequiredFurnishings = null,
                          IEnumerable<RecipeElement> inOptionallyRequiredWalkableFloors = null,
                          IEnumerable<RecipeElement> inOptionallyRequiredPerimeterBlocks = null)
            : base(All.RoomRecipeIDs, inID, inName, inDescription, inComment, inTags)
        {
            var nonNullMinimumWalkableSpaces = inMinimumWalkableSpaces ?? RoomConfiguration.MinWalkableSpaces;
            var nonNullOptionallyRequiredFurnishings = (inOptionallyRequiredFurnishings ?? Enumerable.Empty<RecipeElement>()).ToList();
            var nonNullOptionallyRequiredWalkableFloors = (inOptionallyRequiredWalkableFloors ?? Enumerable.Empty<RecipeElement>()).ToList();
            var nonNullOptionallyRequiredPerimeterBlocks = (inOptionallyRequiredPerimeterBlocks ?? Enumerable.Empty<RecipeElement>()).ToList();

            if (nonNullMinimumWalkableSpaces < RoomConfiguration.MinWalkableSpaces
                || nonNullMinimumWalkableSpaces > RoomConfiguration.MaxWalkableSpaces)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningRoomSize,
                                                           inMinimumWalkableSpaces, RoomConfiguration.MinWalkableSpaces,
                                                           RoomConfiguration.MaxWalkableSpaces));
            }

            MinimumWalkableSpaces = nonNullMinimumWalkableSpaces;
            OptionallyRequiredFurnishings = nonNullOptionallyRequiredFurnishings;
            OptionallyRequiredWalkableFloors = nonNullOptionallyRequiredWalkableFloors;
            OptionallyRequiredPerimeterBlocks = nonNullOptionallyRequiredPerimeterBlocks;
        }
        #endregion

        #region IMutableRoomRecipe Implementation
        /// <summary>Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IMutableRoomRecipe"/>.
        /// IMutableRoomRecipe is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        int IMutableRoomRecipe.MinimumWalkableSpaces
        {
            get => MinimumWalkableSpaces;
            set => MinimumWalkableSpaces = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(MinimumWalkableSpaces), MinimumWalkableSpaces)
                : value;
        }

        /// <summary>A list of <see cref="Parquets.FurnishingModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IMutableRoomRecipe"/>.
        /// IMutableRoomRecipe is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<RecipeElement> IMutableRoomRecipe.OptionallyRequiredFurnishings
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(OptionallyRequiredFurnishings), new Collection<RecipeElement>())
                : (ICollection<RecipeElement>)OptionallyRequiredFurnishings;

        /// <summary>An optional list of <see cref="Parquets.FloorModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IMutableRoomRecipe"/>.
        /// IMutableRoomRecipe is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<RecipeElement> IMutableRoomRecipe.OptionallyRequiredWalkableFloors
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(OptionallyRequiredWalkableFloors), new Collection<RecipeElement>())
                : (ICollection<RecipeElement>)OptionallyRequiredWalkableFloors;

        /// <summary>An optional list of <see cref="Parquets.BlockModel"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IMutableRoomRecipe"/>.
        /// IMutableRoomRecipe is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<RecipeElement> IMutableRoomRecipe.OptionallyRequiredPerimeterBlocks
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(OptionallyRequiredPerimeterBlocks), new Collection<RecipeElement>())
                : (ICollection<RecipeElement>)OptionallyRequiredPerimeterBlocks;
        #endregion

        #region Derived Details
        /// <summary>
        /// A measure of the stringency of this <see cref="RoomRecipe"/>'s requirements.
        /// If a <see cref="Room"/> corresponds to multiple recipes' requirements,
        /// the room is assigned the type of the most demanding recipe.
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
            => inRoom is not null
            && inRoom.WalkableArea.Count >= MinimumWalkableSpaces
            && OptionallyRequiredPerimeterBlocks.All(element
                => inRoom.Perimeter.Count(space
                    => space.Content.BlockID != ModelID.None
                    && (All.Blocks.GetOrNull<BlockModel>(space.Content.BlockID)?.AddsToRoom.Contains(element.ElementTag) ?? false))
                        >= element.ElementAmount)
            && OptionallyRequiredWalkableFloors.All(element
                => inRoom.WalkableArea.Count(space
                    => space.Content.FloorID != ModelID.None
                    && (All.Floors.GetOrNull<FloorModel>(space.Content.FloorID)?.AddsToRoom.Contains(element.ElementTag) ?? false))
                        >= element.ElementAmount)
            && OptionallyRequiredFurnishings.All(element
                => inRoom.FurnishingTags.Count(tag
                    => tag == element.ElementTag) >= element.ElementAmount);
        #endregion
    }
}
