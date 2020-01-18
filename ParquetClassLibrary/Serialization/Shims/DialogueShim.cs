using ParquetClassLibrary.Interactions;
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
        // TODO Derive this from InteractionStub
        // TODO This is a stub.

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="InteractionModel"/>.</returns>
        public override T ToEntity<T>()
        {
            Precondition.IsOfType<T, DialogueModel>(typeof(T).ToString());

            return (T)(EntityModel)new DialogueModel(ID, Name, Description, Comment, null, null, null); // TODO fill in these nulls.
        }
    }
}
