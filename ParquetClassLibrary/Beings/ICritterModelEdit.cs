namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Facilitates editing of a <see cref="CritterModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, children of <see cref="CritterModel"/> should never themselves use <see cref="ICritterModelEdit"/>.
    /// ICritterModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface ICritterModelEdit : IBeingModelEdit
    {
        // This class is intentionally left empty.
        // Currently, everything needed for editing CritterModels is provided by IBeingModelEdit.
        // However, that may change in the future.  This class exists to simplify external code
        // and to allow for future expansion of CritterModel.
    }
}
