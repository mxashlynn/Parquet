using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Quests;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="Quest"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="Quest"/> from this class.
    /// </summary>
    public class QuestShim : EntityShim
    {
        /// <summary>Describes the criteria for completing this <see cref="Quest"/>.</summary>
        public List<EntityTag> CompletionRequirements;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override T ToEntity<T>()
        {
            Precondition.IsOfType<T, Quest>(typeof(T).ToString());

            return (T)(Entity)new Quest(ID, Name, Description, Comment, CompletionRequirements);
        }
    }
}
