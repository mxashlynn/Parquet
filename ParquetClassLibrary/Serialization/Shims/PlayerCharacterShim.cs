using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="PlayerCharacterModel"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="PlayerCharacterModel"/> from this class.
    /// </summary>
    public class PlayerCharacterShim : CharacterShim
    {
        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override T ToEntity<T>()
        {
            Precondition.IsOfType<T, PlayerCharacterModel>(typeof(T).ToString());

            return (T)(EntityModel)new PlayerCharacterModel(ID, PersonalName, FamilyName, Description, Comment,
                                                       Pronoun, StoryCharacterID, StartingQuests, StartingInventory);
        }
    }
}
