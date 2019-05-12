using System.Collections.Generic;
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
        /// The <see cref="EntityID"/> of the item awarded to the player when a character gathers or collects this parquet.
        /// </summary>
        public EntityID ItemID;

        /// <summary>Player-facing description.</summary>
        public string Description { get; }

        /// <summary>Optional comment.</summary>
        public string Comment { get; }

        /// <summary>
        /// Describing the <see cref="Biome"/>(s) this parquet helps form.
        /// </summary>
        public EntityTag AddsToBiome;

        /// <summary>
        /// Describes the <see cref="ParquetClassLibrary.Rooms.RoomRecipe"/>(s) this parquet helps form.
        /// </summary>
        public EntityTag AddsToRoom;

        /// <summary>
        /// Converts a shim into the class is corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="ParquetParent"/>.</returns>
        public abstract T To<T>() where T : ParquetParent;
    }
}
