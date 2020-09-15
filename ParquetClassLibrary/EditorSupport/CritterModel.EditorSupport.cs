#if DESIGN
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a simple in-game actor, such as a friendly mob with limited interaction.
    /// </summary>
    public partial class CritterModel : ICritterModelEdit
    {
        #region ICritterModelEdit Implementation
        // Currently, everything needed for editing CritterModels is provided by IBeingModelEdit.
        #endregion
    }
}
#endif
