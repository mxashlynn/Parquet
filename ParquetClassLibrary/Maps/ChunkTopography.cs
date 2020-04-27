namespace ParquetClassLibrary.Maps
{
    /// <summary>Indicates the basic form that the parquets in a <see cref="MapChunk"/> take.</summary>
    public enum ChunkTopography
    {
        /// <summary>Indicates there are no parquets in this topography.</summary>
        Empty,
        /// <summary>Indicates parquets entirely fill this topography.</summary>
        Solid,
        /// <summary>Indicates parquets are spread evenly throughout this topography.</summary>
        Scattered,
        /// <summary>Indicates parquets appear in clumps throughout this topography.</summary>
        Clustered,
        /// <summary>Indicates a central grouping of parquets in this topography.</summary>
        Central,
        /// <summary>Indicates parquets are grouped to the north end of this topography.</summary>
        North,
        /// <summary>Indicates parquets are grouped on both the north and east end of this topography.</summary>
        NorthEast,
        /// <summary>Indicates parquets are grouped to the east end of this topography.</summary>
        East,
        /// <summary>Indicates parquets are grouped on both the south and east end of this topography.</summary>
        SouthEast,
        /// <summary>Indicates parquets are grouped to the south end of this topography.</summary>
        South,
        /// <summary>Indicates parquets are grouped on both the south and west end of this topography.</summary>
        SouthWest,
        /// <summary>Indicates parquets are grouped to the west end of this topography.</summary>
        West,
        /// <summary>Indicates parquets are grouped on both the north and west end of this topography.</summary>
        NorthWest,
    }
}
