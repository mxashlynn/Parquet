using System.Collections.Generic;

namespace Parquet.Rooms
{
    /// <summary>
    /// Facilitates editing of a <see cref="RoomRecipe"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, subtypes of <see cref="RoomRecipe"/> should never themselves use <see cref="IMutableRoomRecipe"/>.
    /// IRoomRecipeEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IMutableRoomRecipe : IMutableModel
    {
        /// <summary>Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.</summary>
        public int MinimumWalkableSpaces { get; set; }

        /// <summary>A list of <see cref="Parquets.FurnishingModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public ICollection<RecipeElement> OptionallyRequiredFurnishings { get; }

        /// <summary>An optional list of <see cref="Parquets.FloorModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public ICollection<RecipeElement> OptionallyRequiredWalkableFloors { get; }

        /// <summary>An optional list of <see cref="Parquets.BlockModel"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        public ICollection<RecipeElement> OptionallyRequiredPerimeterBlocks { get; }
    }
}
