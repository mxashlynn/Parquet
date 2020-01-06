using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="NPC"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="NPC"/> from this class.
    /// </summary>
    public class NPCShim : CharacterShim
    {
        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="TargetType">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override TargetType To<TargetType>()
        {
            Precondition.IsOfType<TargetType, NPC>(typeof(TargetType).ToString());

            return (TargetType)(Entity)new NPC(ID, Name, FamilyName, Description, Comment, NativeBiome, PrimaryBehavior,
                                               Avoids, Seeks, Pronoun, StoryCharacterID, StartingQuests, Dialogue, StartingInventory);
        }
    }
}
