using Parquet.Parquets;

namespace Parquet.Regions
{
    /// <summary>
    /// Models details of a portion of a <see cref="RegionModel"/>,
    /// either directly composed of parquets or generated from <see cref="ChunkDetail"/>s.
    /// Instances of this class are mutable during play.
    /// </summary>
    public class MapChunk
    {
        #region Class Defaults
        /// <summary>Used to indicate an uninitialized chunk.</summary>
        public static MapChunk Empty { get; } = new MapChunk(null, false);

        /// <summary>The length of each <see cref="MapChunk"/> dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The chunk's dimensions in parquets.</summary>
        public Vector2D DimensionsInParquets { get; } = new Vector2D(ParquetsPerChunkDimension,
                                                                     ParquetsPerChunkDimension);
        #endregion

        #region Characteristics
        /// <summary>If <c>true</c>, the <see cref="MapChunk"/> is created at design time instead of procedurally generated.</summary>
        public bool IsFilledOut { get; private set; }

        /// <summary>A description of the type and arrangement of parquets to generate at runtime.</summary>
        public ChunkDetail Details { get; set; }

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        public ParquetModelPackGrid ParquetDefinitions { get; set;  }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes an instance of the <see cref="MapChunk"/> class.
        /// </summary>
        /// <param name="inIsFilledOut">
        /// If <c>true</c>, the <see cref="MapChunk"/> was either created at design time or
        /// has already been procedurally generated on load in-game.
        /// </param>
        /// <param name="inDetails">Cues to the generation routines if generated at runtime.</param>
        /// <param name="inParquetDefinitions">The definitions of the collected parquets if designed by hand.</param>        
        public MapChunk(bool inIsFilledOut = false, ChunkDetail inDetails = null,
                        // TODO [MAP EDITOR] [API] Should this accept an IReadOnlyGrid<ParquetPack>s instead?
                        ParquetModelPackGrid inParquetDefinitions = null)
        {
            IsFilledOut = inIsFilledOut;

            if (IsFilledOut)
            {
                Details = ChunkDetail.None;
                ParquetDefinitions = inParquetDefinitions ?? new ParquetModelPackGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);
            }
            else
            {
                Details = inDetails ?? ChunkDetail.None;
                ParquetDefinitions = ParquetModelPackGrid.Empty;
            }
        }
        #endregion

        #region Procedural Generation
        /// <summary>
        /// Transforms the current <see cref="MapChunk"/> so that it is ready to be stitched together
        /// with others in its <see cref="MapRegionSketch"/> into a playable <see cref="RegionModel"/>.
        /// </summary>
        /// <remarks>
        /// If a chunk <see cref="IsFilledOut"/>, it is ready to go.
        /// Chunks that are not handmade at design time need to undergo procedural generation based on their <see cref="ChunkDetail"/>s.
        /// </remarks>
        /// <returns>The generated <see cref="MapChunk"/>.</returns>
        public MapChunk Generate()
        {
            // If this chunk has already been generated, no work is needed.
            if (IsFilledOut)
            {
                return this;
            }

            // Create a subregion to hold the generated parquets.
            var newParquetDefinitions = new ParquetModelPackGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);

            // TODO [MAP EDITOR] Replace this pass-through implementation.
            #region Pass-Through Implementation
            Details = ChunkDetail.None;
            for (var x = 0; x < ParquetsPerChunkDimension; x++)
            {
                for (var y = 0; y < ParquetsPerChunkDimension; y++)
                {
                    newParquetDefinitions[y, x].FloorID = All.FloorIDs.Minimum;
                }
                newParquetDefinitions[0, x].BlockID = All.BlockIDs.Minimum;
                newParquetDefinitions[ParquetsPerChunkDimension - 1, 1].BlockID = All.BlockIDs.Minimum;
            }
            for (var y = 0; y < ParquetsPerChunkDimension; y++)
            {
                newParquetDefinitions[y, 0].BlockID = All.BlockIDs.Minimum;
                newParquetDefinitions[y, ParquetsPerChunkDimension - 1].BlockID = All.BlockIDs.Minimum;
            }
            newParquetDefinitions[2, 1].FurnishingID = All.FurnishingIDs.Minimum;
            newParquetDefinitions[3, 3].CollectibleID = All.CollectibleIDs.Minimum;
            #endregion

            // Create a new MapChunkModel with the new subregion.
            var newChunk = new MapChunk(true, null, newParquetDefinitions);

            return newChunk;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapChunk"/> as a <see cref="string"/> containing basic information.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="MapChunk"/>.</returns>
        public override string ToString()
            => IsFilledOut
                ? $"{nameof(MapChunk)}: {ParquetDefinitions.Count}"
                : $"{nameof(MapChunk)}: {Details}";
        #endregion
    }
}
