using System.Collections.Generic;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Facilitates editing of a <see cref="BeingModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    public interface IBeingModelEdit : IModelEdit
    {
        /// <summary>The <see cref="ModelID"/> of the <see cref="Biomes.BiomeRecipe"/> in which this character is at home.</summary>
        public ModelID NativeBiome { get; set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> governing the way this being acts.</summary>
        public ModelID PrimaryBehavior { get; set; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> avoids, if any.</summary>
        public IList<ModelID> Avoids { get; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> seeks out, if any.</summary>
        public IList<ModelID> Seeks { get; }
    }
}
