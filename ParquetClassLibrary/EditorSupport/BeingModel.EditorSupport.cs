#if DESIGN
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Scripts;

namespace ParquetClassLibrary.Beings
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public abstract partial class BeingModel : IMutableBeingModel
    {
        #region IBeingModelEdit Implementation
        /// <summary>The <see cref="ModelID"/> of the <see cref="Biomes.BiomeRecipe"/> in which this character is at home.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableBeingModel.NativeBiomeID { get => NativeBiomeID; set => NativeBiomeID = value; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="ScriptModel"/> governing the way this being acts.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableBeingModel.PrimaryBehaviorID { get => PrimaryBehaviorID; set => PrimaryBehaviorID = value; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> avoids, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IMutableBeingModel.AvoidsIDs => (IList<ModelID>)AvoidsIDs;

        /// <summary>Types of parquets this <see cref="BeingModel"/> seeks out, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IMutableBeingModel.SeeksIDs => (IList<ModelID>)SeeksIDs;
        #endregion
    }
}
#endif
