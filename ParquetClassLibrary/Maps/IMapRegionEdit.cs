using ParquetClassLibrary.Biomes;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Facilitates editing of <see cref="MapRegion"/> characteristics from design tools while maintaining a read-only face for use during play.
    /// </summary>
    internal interface IMapRegionEdit
    {
        /// <summary>What the region is called in-game.</summary>
        string Name { get; set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        string BackgroundColor { get; set; }
    }
}
