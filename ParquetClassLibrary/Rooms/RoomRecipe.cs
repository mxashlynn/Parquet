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
        /// <param name="id">Unique identifier for the <see cref="RoomRecipe"/>.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the <see cref="RoomRecipe"/>.</param>
        /// <param name="description">Player-friendly description of the <see cref="RoomRecipe"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="RoomRecipe"/>.</param>
        /// <param name="tags">Any additional information about this <see cref="RoomRecipe"/>.</param>
        /// <param name="minimumWalkableSpaces">The minimum number of walkable <see cref="MapSpace"/>s required by this <see cref="RoomRecipe"/>.</param>
        /// <param name="optionallyRequiredFurnishings">An optional list of furnishing categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="optionallyRequiredWalkableFloors">An optional list of floor categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="optionallyRequiredPerimeterBlocks">An optional list of block categories this <see cref="RoomRecipe"/> requires as walls.</param>
        public RoomRecipe(ModelID id, string name, string description, string comment,
                          IEnumerable<ModelTag> tags = null, int? minimumWalkableSpaces = null,
                          IEnumerable<RecipeElement> optionallyRequiredFurnishings = null,
                          IEnumerable<RecipeElement> optionallyRequiredWalkableFloors = null,
                          IEnumerable<RecipeElement> optionallyRequiredPerimeterBlocks = null)
            : base(All.RoomRecipeIDs, id, name, description, comment, tags)
        {
            var nonNullMinimumWalkableSpaces = minimumWalkableSpaces ?? RoomConfiguration.MinWalkableSpaces;
            var nonNullOptionallyRequiredFurnishings = (optionallyRequiredFurnishings ?? Enumerable.Empty<RecipeElement>()).ToList();
            var nonNullOptionallyRequiredWalkableFloors = (optionallyRequiredWalkableFloors ?? Enumerable.Empty<RecipeElement>()).ToList();
            var nonNullOptionallyRequiredPerimeterBlocks = (optionallyRequiredPerimeterBlocks ?? Enumerable.Empty<RecipeElement>()).ToList();

            if (nonNullMinimumWalkableSpaces < RoomConfiguration.MinWalkableSpaces
                || nonNullMinimumWalkableSpaces > RoomConfiguration.MaxWalkableSpaces)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningRoomSize,
                                                           minimumWalkableSpaces, RoomConfiguration.MinWalkableSpaces,
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
        /// <param name="room">The <see cref="Room"/> to check.</param>
        /// <returns>
        /// <c>ture</c> if <paramref name="room"/> is an instance of this <see cref="RoomRecipe"/>;
        /// <c>false</c> otherwise.
        /// </returns>
        public bool Matches(Room room)
            => room is not null
            && room.WalkableArea.Count >= MinimumWalkableSpaces
            && OptionallyRequiredPerimeterBlocks.All(element
                => room.Perimeter.Count(space
                    => space.Content.BlockID != ModelID.None
                    && (All.Blocks.GetOrNull<BlockModel>(space.Content.BlockID)?.AddsToRoom.Contains(element.ElementTag) ?? false))
                        >= element.ElementAmount)
            && OptionallyRequiredWalkableFloors.All(element
                => room.WalkableArea.Count(space
                    => space.Content.FloorID != ModelID.None
                    && (All.Floors.GetOrNull<FloorModel>(space.Content.FloorID)?.AddsToRoom.Contains(element.ElementTag) ?? false))
                        >= element.ElementAmount)
            && OptionallyRequiredFurnishings.All(element
                => room.FurnishingTags.Count(tag
                    => tag == element.ElementTag) >= element.ElementAmount);
        #endregion
    }
}
