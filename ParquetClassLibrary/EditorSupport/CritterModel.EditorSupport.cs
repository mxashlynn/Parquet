using Parquet.EditorSupport;

namespace Parquet.Beings
{
    /// <summary>
    /// Models the definition for a simple in-game actor, such as a friendly mob with limited interaction.
    /// </summary>
    public partial class CritterModel : IMutableCritterModel
    {
        #region ICritterModelEdit Implementation
        // Currently, everything needed for editing CritterModels is provided by IBeingModelEdit.
        #endregion
    }
}
