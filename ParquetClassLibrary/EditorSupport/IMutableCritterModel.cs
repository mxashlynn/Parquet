#if DESIGN
using Parquet.Beings;

namespace Parquet.EditorSupport
{
    /// <summary>
    /// Facilitates editing of a <see cref="CritterModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, subtypes of <see cref="CritterModel"/> should never themselves use <see cref="IMutableCritterModel"/>.
    /// ICritterModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IMutableCritterModel : IMutableBeingModel
    {
        // This class is intentionally left empty.
        // Currently, everything needed for editing CritterModels is provided by IBeingModelEdit.
        // However, that may change in the future.  This class exists to simplify external code
        // and to allow for future expansion of CritterModel.
    }
}
#endif
