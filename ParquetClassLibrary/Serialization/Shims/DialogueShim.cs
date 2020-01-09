using ParquetClassLibrary.Dialogues;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="DialogueModel"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="DialogueModel"/> from this class.
    /// </summary>
    public class DialogueShim : EntityShim
    {
        // TODO This is a stub.

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override T ToEntity<T>()
        {
            Precondition.IsOfType<T, DialogueModel>(typeof(T).ToString());

            return (T)(EntityModel)new DialogueModel(ID, Name, Description, Comment);
        }
    }
}