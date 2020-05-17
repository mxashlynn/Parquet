using System;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Models details of a portion of a <see cref="MapRegion"/>,
    /// either directly composed of parquets or generated from <see cref="ChunkDetail"/>s.
    /// </summary>
    /// <remarks>
    /// For more information, read the remarks given in <see cref="MapRegionSketch"/>.
    /// </remarks>
    public sealed class MapChunk : MapModel
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static MapChunk Empty { get; } = new MapChunk(ModelID.None, "Empty", "", "", 0, false);

        /// <summary>The length of each <see cref="MapChunk"/> dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The chunk's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(ParquetsPerChunkDimension,
                                                                              ParquetsPerChunkDimension);

        /// <summary>The set of values that are allowed for <see cref="MapChunk"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.MapChunkIDs;
        #endregion

        #region Characteristics
        /// <summary>If <c>true</c>, the <see cref="MapChunk"/> is created at design time instead of procedurally generated.</summary>
        [Index(5)]
        // TODO Change this name since it is being used for non-handmadeness now.
        public bool IsHandmade { get; private set; }

        /// <summary>A description of the type and arrangement of parquets to generate at runtime.</summary>
        [Index(6)]
        public ChunkDetail Details { get; private set; }

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        [Index(13)]
        public override ParquetStackGrid ParquetDefinitions { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="MapModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the map.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        /// <param name="inRevision">An option revision count.</param>
        /// <param name="inIsHandmade">
        /// If <c>true</c>, the <see cref="MapChunk"/> is created at design time;
        /// otherwise, it is procedurally generated on load in-game.
        /// </param>
        /// <param name="inDetails">Cues to the generation routines if generated at runtime.</param>
        /// <param name="inParquetDefinitions">The definitions of the collected parquets if designed by hand.</param>
        public MapChunk(ModelID inID, string inName, string inDescription, string inComment, int inRevision,
                        bool inIsHandmade,
                        ChunkDetail inDetails = null,
                        ParquetStackGrid inParquetDefinitions = null)
            : base(Bounds, inID, inName, inDescription, inComment, inRevision)
        {
            IsHandmade = inIsHandmade;

            if (IsHandmade)
            {
                Details = ChunkDetail.None;
                ParquetDefinitions = inParquetDefinitions ?? new ParquetStackGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);
            }
            else
            {
                Details = inDetails ?? ChunkDetail.None;
                // TODO Replace this with a Grid.Empty
                ParquetDefinitions = new ParquetStackGrid();
            }
        }
        #endregion

        /// <summary>
        /// Transforms the current <see cref="MapChunk"/> so that it is ready to be stitched together
        /// with others into a playable <see cref="MapRegion"/>.
        /// </summary>
        /// <remarks>
        /// If a chunk <see cref="IsHandmade"/>, it is ready to go.
        /// Chunks that are not handmade will need to undergo procedural generation based on their <see cref="ChunkDetail"/>s.
        /// </remarks>
        public void Generate()
        {
            if (IsHandmade)
            {
                return;
            }

            // TODO Replace this pass-through implementation.
            #region Pass-Through Implementation
            Details = ChunkDetail.None;
            for (var x = 0; x < ParquetsPerChunkDimension; x++)
            {
                for (var y = 0; y < ParquetsPerChunkDimension; y++)
                {
                    ParquetDefinitions[y, x].Floor = All.FloorIDs.Minimum;
                }
                ParquetDefinitions[0, x].Block = All.BlockIDs.Minimum;
                ParquetDefinitions[ParquetsPerChunkDimension, 1].Block = All.BlockIDs.Minimum;
            }
            for (var y = 0; y < MapRegion.ParquetsPerRegionDimension; y++)
            {
                ParquetDefinitions[y, 0].Block = All.BlockIDs.Minimum;
                ParquetDefinitions[y, MapRegion.ParquetsPerRegionDimension - 1].Block = All.BlockIDs.Minimum;
            }
            ParquetDefinitions[2, 1].Furnishing = All.FurnishingIDs.Minimum;
            ParquetDefinitions[3, 3].Collectible = All.CollectibleIDs.Minimum;
            #endregion

            IsHandmade = true;
        }

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapChunk"/> as a <see cref="string"/> containing basic information.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="MapChunk"/>.</returns>
        public override string ToString()
            => IsHandmade
                ? $"Chunk {Name} handmade {base.ToString()}"
                : $"Chunk {Name} generated {Details}";
        #endregion
    }
}
