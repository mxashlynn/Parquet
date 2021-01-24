using System;
using CsvHelper.Configuration.Attributes;
using Parquet.Parquets;

namespace Parquet.Maps
{
    /// <summary>
    /// Models details of a portion of a <see cref="MapRegionModel"/>,
    /// either directly composed of parquets or generated from <see cref="ChunkDetail"/>s.
    /// </summary>
    /// <remarks>
    /// For more information, read the remarks given in <see cref="MapRegionSketch"/>.
    /// </remarks>
    public partial class MapChunkModel : MapModel
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static MapChunkModel Empty { get; } = new MapChunkModel(ModelID.None, "Empty", "", "", 0, false);

        /// <summary>The length of each <see cref="MapChunkModel"/> dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The chunk's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(ParquetsPerChunkDimension,
                                                                              ParquetsPerChunkDimension);

        /// <summary>The set of values that are allowed for <see cref="MapChunkModel"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.MapChunkIDs;
        #endregion

        #region Characteristics
        /// <summary>If <c>true</c>, the <see cref="MapChunkModel"/> is created at design time instead of procedurally generated.</summary>
        [Index(5)]
        public bool IsFilledOut { get; private set; }

        /// <summary>A description of the type and arrangement of parquets to generate at runtime.</summary>
        [Index(6)]
        public ChunkDetail Details { get; private set; }

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        [Index(13)]
        public override ParquetPackGrid ParquetDefinitions { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by subtypes of the <see cref="MapModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the map.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        /// <param name="inRevision">An option revision count.</param>
        /// <param name="inIsFilledOut">
        /// If <c>true</c>, the <see cref="MapChunkModel"/> was either created at design time or
        /// has already been procedurally generated on load in-game.
        /// </param>
        /// <param name="inDetails">Cues to the generation routines if generated at runtime.</param>
        /// <param name="inParquetDefinitions">The definitions of the collected parquets if designed by hand.</param>        
        public MapChunkModel(ModelID inID, string inName, string inDescription, string inComment, int inRevision = 0,
                             bool inIsFilledOut = false,
                             ChunkDetail inDetails = null,
                             // TODO Should this accept an IReadOnlyGrid<ParquetPack>s instead?
                             ParquetPackGrid inParquetDefinitions = null)
            : base(Bounds, inID, inName, inDescription, inComment, inRevision)
        {
            IsFilledOut = inIsFilledOut;

            if (IsFilledOut)
            {
                Details = ChunkDetail.None;
                ParquetDefinitions = inParquetDefinitions ?? new ParquetPackGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);
            }
            else
            {
                Details = inDetails ?? ChunkDetail.None;
                ParquetDefinitions = ParquetPackGrid.Empty;
            }
        }
        #endregion

        #region Procedural Generation
        /// <summary>
        /// Transforms the current <see cref="MapChunkModel"/> so that it is ready to be stitched together
        /// with others in its <see cref="MapRegionSketch"/> into a playable <see cref="MapRegionModel"/>.
        /// </summary>
        /// <remarks>
        /// If a chunk <see cref="IsFilledOut"/>, it is ready to go.
        /// Chunks that are not handmade at design time need to undergo procedural generation based on their <see cref="ChunkDetail"/>s.
        /// </remarks>
        /// <returns>The generated <see cref="MapChunkModel"/>.</returns>
        public MapChunkModel Generate()
        {
            // If this chunk has already been generated, no work is needed.
            if (IsFilledOut)
            {
                return this;
            }
            IsFilledOut = true;

            // Create a subregion to hold the generated parquets.
            var newParquetDefinitions = new ParquetPackGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);

            // TODO Replace this pass-through implementation.
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
            var newChunk = new MapChunkModel(ID, Name, Description, Comment, Revision + 1, true, null, newParquetDefinitions);

            // TODO: Fix this section.
            /*
            // If the current chunk is contained in the game-wide database, replace it with the newly generated chunk.
            if (All.Maps.Contains(ID))
            {
                IModelCollectionEdit<MapModel> allMaps = All.Maps;
                allMaps.Replace(newChunk);
            }
            */

            return newChunk;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapChunkModel"/> as a <see cref="string"/> containing basic information.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="MapChunkModel"/>.</returns>
        public override string ToString()
            => IsFilledOut
                ? $"Chunk {Name} filled out {base.ToString()}"
                : $"Chunk {Name} sketched as {Details}";
        #endregion
    }
}
