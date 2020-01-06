using ParquetClassLibrary.Biomes;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Parent class for all shims of parquet definitions.
    /// </summary>
    public abstract class ParquetParentShim : EntityShim
    {
        /// <summary>The <see cref="EntityID"/> of the item that corresponds to this parquet.</summary>
        public EntityID ItemID;

        /// <summary>The <see cref="Biome"/>(s) this parquet helps form.</summary>
        public EntityTag AddsToBiome;

        /// <summary>The <see cref="ParquetClassLibrary.Rooms.RoomRecipe"/>(s) this parquet helps form.</summary>
        public EntityTag AddsToRoom;
    }
}
