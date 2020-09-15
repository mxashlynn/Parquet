#if DESIGN
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Rooms
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public partial class RoomRecipe : IRoomRecipeEdit
    {
        #region IRoomRecipeEdit Implementation
        /// <summary>Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IRoomRecipeEdit"/>.
        /// IRoomRecipeEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        int IRoomRecipeEdit.MinimumWalkableSpaces { get => MinimumWalkableSpaces; set => MinimumWalkableSpaces = value; }

        /// <summary>A list of <see cref="Parquets.FurnishingModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IRoomRecipeEdit"/>.
        /// IRoomRecipeEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<RecipeElement> IRoomRecipeEdit.OptionallyRequiredFurnishings => (IList<RecipeElement>)OptionallyRequiredFurnishings;

        /// <summary>An optional list of <see cref="Parquets.FloorModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IRoomRecipeEdit"/>.
        /// IRoomRecipeEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<RecipeElement> IRoomRecipeEdit.OptionallyRequiredWalkableFloors => (IList<RecipeElement>)OptionallyRequiredWalkableFloors;

        /// <summary>An optional list of <see cref="Parquets.BlockModel"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IRoomRecipeEdit"/>.
        /// IRoomRecipeEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<RecipeElement> IRoomRecipeEdit.OptionallyRequiredPerimeterBlocks => (IList<RecipeElement>)OptionallyRequiredPerimeterBlocks;
        #endregion
    }
}
#endif
