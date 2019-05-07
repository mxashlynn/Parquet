using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Parquets;

namespace ParquetCSVImporter.Shims
{
    /// <summary>
    /// Parent class for all shims of parquet definitions.
    /// </summary>
    public abstract class ParquetParentShim
    {
        /// <summary>Unique identifier of the parquet.</summary>
        public EntityID ID;

        /// <summary>Player-facing name of the parquet.</summary>
        public string Name;

        /// <summary>
        /// If a <see cref="BiomeMask"/> flag is set, this parquet helps generate the corresponding <see cref="Biome"/>.
        /// </summary>
        public BiomeMask AddsToBiome;

        /// <summary>
        /// Converts a shim into the class is corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="ParquetParent"/>.</returns>
        public abstract T To<T>() where T : ParquetParent;
    }
}
