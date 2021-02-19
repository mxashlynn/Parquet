using System.Collections.Generic;
using Parquet.Beings;

namespace Parquet.EditorSupport
{
    /// <summary>
    /// Facilitates editing of a <see cref="BeingModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    public interface IMutableBeingModel : IMutableModel
    {
        /// <summary>The <see cref="ModelID"/> of the <see cref="Biomes.BiomeRecipe"/> in which this character is at home.</summary>
        public ModelID NativeBiomeID { get; set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> governing the way this being acts.</summary>
        public ModelID PrimaryBehaviorID { get; set; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> avoids, if any.</summary>
        public ICollection<ModelID> AvoidsIDs { get; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> seeks out, if any.</summary>
        public ICollection<ModelID> SeeksIDs { get; }
    }
}
