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

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        ModelID RegionToTheNorth { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        ModelID RegionToTheEast { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        ModelID RegionToTheSouth { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        ModelID RegionToTheWest { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        ModelID RegionAbove { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region below this one.</summary>
        ModelID RegionBelow { get; set; }
    }
}
