using System.Collections.Generic;

namespace Parquet
{
    /// <summary>
    /// Facilitates editing of a <see cref="Model"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// <see cref="Model"/> and its subtypes are not editable once created.  This is because during play, these classes serve
    /// as definitions, which need to remain fixed.  Any state that changes during runtime is instead housed in a corresponding
    /// State class.
    ///
    /// However, at design time even definitions need to be changeable.  To support this easily while still preserving the fixedness
    /// of Model and company during play, <see cref="IMutableModel"/> and its subtypes provide interfaces that may be used to safely
    /// make changes to the properties of their corresponding models.
    /// 
    /// By design, subtypes of <see cref="Model"/> should never themselves use their <see cref="IMutableModel"/> interface.
    /// IMutableModel is for use only by external types (such as those in a design-time tool) that require read/write access to model
    /// properties.
    /// </remarks>
    public interface IMutableModel : IVisibleData
    {
        /// <summary>Game-wide unique identifier.</summary>
        /// <remarks>Be cautious editing this.</remarks>
        public ModelID ID { get; set; }

        /// <summary>Player-facing name.</summary>
        public string Name { get; set; }

        /// <summary>Player-facing description.</summary>
        public string Description { get; set; }

        /// <summary>Optional comment.</summary>
        /// <remarks>Could be used for designer's notes or to implement an in-game dialogue with or on the <see cref="Model"/>.</remarks>
        public string Comment { get; set; }

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.BiomeRecipe"/>.</summary>
        public ICollection<ModelTag> Tags { get; }
    }
}
