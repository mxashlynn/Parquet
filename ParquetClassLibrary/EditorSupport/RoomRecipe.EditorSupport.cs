using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;

namespace Parquet.Rooms
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class RoomRecipe : IMutableRoomRecipe
    {
        #region IRoomRecipeEdit Implementation
        /// <summary>Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IMutableRoomRecipe"/>.
        /// IRoomRecipeEdit is for external types that require read/write access.
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
        /// IRoomRecipeEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<RecipeElement> IMutableRoomRecipe.OptionallyRequiredFurnishings
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(OptionallyRequiredFurnishings), new Collection<RecipeElement>())
                : (ICollection<RecipeElement>)OptionallyRequiredFurnishings;

        /// <summary>An optional list of <see cref="Parquets.FloorModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IMutableRoomRecipe"/>.
        /// IRoomRecipeEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<RecipeElement> IMutableRoomRecipe.OptionallyRequiredWalkableFloors
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(OptionallyRequiredWalkableFloors), new Collection<RecipeElement>())
                : (ICollection<RecipeElement>)OptionallyRequiredWalkableFloors;

        /// <summary>An optional list of <see cref="Parquets.BlockModel"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IMutableRoomRecipe"/>.
        /// IRoomRecipeEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<RecipeElement> IMutableRoomRecipe.OptionallyRequiredPerimeterBlocks
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(OptionallyRequiredPerimeterBlocks), new Collection<RecipeElement>())
                : (ICollection<RecipeElement>)OptionallyRequiredPerimeterBlocks;
        #endregion
    }
}
