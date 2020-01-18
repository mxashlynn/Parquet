using System.Collections.Generic;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="RoomRecipe"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="RoomRecipe"/> from this class.
    /// </summary>
    public class RoomRecipeShim : EntityShim
    {
        /// <summary>Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.</summary>
        public int MinimumWalkableSpaces;

        /// <summary>An optional list of <see cref="Parquets.FloorModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public List<RecipeElement> RequiredFloors;

        /// <summary>An optional list of <see cref="Parquets.BlockModel"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        public List<RecipeElement> RequiredPerimeterBlocks;

        /// <summary>A list of <see cref="Parquets.FurnishingModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public List<RecipeElement> RequiredFurnishings;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="EnityModel"/>.</returns>
        public override T ToEntity<T>()
        {
            Precondition.IsOfType<T, RoomRecipe>(typeof(T).ToString());

            return (T)(EntityModel)new RoomRecipe(ID, Name, Description, Comment, RequiredFloors,
                                                  MinimumWalkableSpaces, RequiredPerimeterBlocks, RequiredFurnishings);
        }
    }
}
