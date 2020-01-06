using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Utilities;

namespace ParquetCLITool.Shims
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
        public int MinimumWalkableSpaces { get; }

        /// <summary>An optional list of <see cref="Parquets.Floor"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public List<RecipeElement> RequiredFloors { get; }

        /// <summary>An optional list of <see cref="Parquets.Block"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        public List<RecipeElement> RequiredPerimeterBlocks { get; }

        /// <summary>A list of <see cref="Parquets.Furnishing"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public List<RecipeElement> RequiredFurnishings { get; }

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="TargetType">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override TargetType To<TargetType>()
        {
            Precondition.IsOfType<TargetType, RoomRecipe>(typeof(TargetType).ToString());

            return (TargetType)(Entity)new RoomRecipe(ID, Name, Description, Comment, RequiredFloors,
                                                      MinimumWalkableSpaces, RequiredPerimeterBlocks, RequiredFurnishings);
        }
    }
}
