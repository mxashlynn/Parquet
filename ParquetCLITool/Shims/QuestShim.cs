using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Quests;
using ParquetClassLibrary.Utilities;

namespace ParquetCLITool.Shims
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
        public List<EntityTag> CompletionRequirements { get; }

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="TargetType">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override TargetType To<TargetType>()
        {
            Precondition.IsOfType<TargetType, Quest>(typeof(TargetType).ToString());

            return (TargetType)(Entity)new Quest(ID, Name, Description, Comment, CompletionRequirements);
        }
    }
}
