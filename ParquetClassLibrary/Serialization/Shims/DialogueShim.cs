using ParquetClassLibrary.Dialogues;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="Dialogue"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="Dialogue"/> from this class.
    /// </summary>
    public class DialogueShim : EntityShim
    {
        // TODO This is a stub.

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="TargetType">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override TargetType To<TargetType>()
        {
            Precondition.IsOfType<TargetType, Dialogue>(typeof(TargetType).ToString());

            return (TargetType)(Entity)new Dialogue(ID, Name, Description, Comment);
        }
    }
}
